using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Hosting;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.DI;
using Microsoft.AspNetCore.Cors;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class MonitoringController : Controller
    {
        //private readonly ILookupUser lookupUser;
        private readonly UserApplication currentUser;
        //private readonly string defaultUserPictureUrl;
        //private readonly IHostingEnvironment hostingEnvironement;
        //private readonly LogService logService;
        private readonly MISContext misContext;

        //public MonitoringController([FromServices]MISContext misContext, LogService logService, ILookupUser lookupUser, IHostingEnvironment server)
        public MonitoringController([FromServices]MISContext misContext, ILookupUser lookupUser, IHostingEnvironment server)
        {
            this.misContext = misContext;
            //this.lookupUser = lookupUser;
            this.currentUser = lookupUser.CurrentUser;
            //this.defaultUserPictureUrl = server.WebRootPath + @"\images\DefaultUser.png";
            //this.hostingEnvironement = server;
            //this.logService = logService;
        }

        internal MonitoringController(MISContext misContext)
        {
            this.misContext = misContext;
        }

        internal class HistoryEntry
        {
            public string ChangeArea { get; set; }
            public string FromValue { get; set; }
            public string ToValue { get; set; }
        }

        /// <summary>
        /// Get Activity detail (not used by plato anymore)
        /// </summary>
        /// <param name="expenseId">The id of the activity</param>
        /// <returns></returns>
        [HttpGet]
        [Route("activityId/{activityId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActivityTransfer GetMonitoringData(long activityId)
        {
            try
            {
                var activity = misContext.Activity
                .Include(p => p.Awp)
                .Include(p => p.ActStatus)
                .Include(p=>p.ActivityHistory)
               .FirstOrDefault(p => p.ActivityId == activityId);
                    
                if (activity == null)
                    throw new Exception("Invalid Activity Id");

                var transfer = new ActivityTransfer()
                {
                    ActivityId = activity.ActivityId,
                    LastMonitorDate = activity.ActivityHistory == null ? null : activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).Select(p => p.ActHistoryDate).FirstOrDefault(),
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = activity.ActivityId, ActivityCodeSequence = activity.ActivityCodeSequence, Strategy = activity.Strategy, Unit = activity.Unit, Awp = activity.Awp, Dsp = activity.Dsp }),
                    ReasonForDelay = activity.ActivityDelayReason,
                    ImmeadiateAction = activity.ActivityImmediateAction,
                    ProgressNote = activity.ActivityProgress,
                    NewTimeFrame = activity.ActivityNewTimeframeDate,
                    StatusName = activity.ActStatus == null ? "" : activity.ActStatus.ActStatusName,
                    StatusId = activity.ActStatusId,
                };

                long? lastMonitoredById = activity.ActivityHistory == null ? null : activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).Select(p => p.UserId).FirstOrDefault();
                transfer.LastMonitoredByUserName = lastMonitoredById == null ? null : misContext.UserApplication.Where(p => p.UserId == lastMonitoredById).Select(p => string.Format("{0} {1}", p.UserFirstName, p.UserLastName)).FirstOrDefault();
                transfer.MonitoringHistoryList = misContext.ActivityHistory.Include(p => p.User).Where(p => p.ActivityId == activityId).OrderByDescending(p => p.ActHistoryDate).ToList();

                return transfer;
            }
            catch(Exception ex)
            {
                //logService.SaveLog(lookupUser.CurrentUser.UserId, LogType.Error, MISPage.ActivityPage, ex, Method.SaveActivity);
                return null;    
            }
        }

        #region save

        /// <summary>
        /// Save an activity, used by plato and should be used by Activity detail as well
        /// </summary>
        /// <param name="activityTransfer">The activity transfer to be saved</param>
        [HttpPost]
        public long Post([FromBody]ActivityTransfer activityTransfer)
        {
            return 1;
            try
            {
                Activity activity = misContext.Activity
                    .Include(p => p.ActStatus)
                    .Where(p => p.ActivityId == activityTransfer.ActivityId).FirstOrDefault();

                bool isAdd = false;
                if (activity == null)
                {
                    isAdd = true;
                    activity = new Activity()
                    {
                        UserAdded = currentUser.UserId,
                        DateAdded = DateTime.Now,
                        ActivityIsRequested = false,
                        ActivityIsValidated = false,
                        ActivityIsForReview = false,
                        ActStatusId = 5,
                        ActAppStatusId = 5,
                        ActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1),
                        ActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31)
                    };
                }
                else
                {
                    activity.DateMod = DateTime.Now;
                    activity.UserMod = currentUser.UserId;
                }

                //Save history data
                Dictionary<string, HistoryEntry> historyList = GetUpdateHistoryList(activityTransfer, isAdd, activity);
                if (!isAdd)
                {
                    AddActivityHistoryEntry(activity, historyList, activity.UserMod);
                }

                //LastMonitorDate = activity.ActivityHistory == null ? null : activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).Select(p => p.ActHistoryDate).FirstOrDefault(),
                //LastMonitoredByUserName = activity.ActivityHistory == null ? null : activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).Select(p => string.Format("{0} {1}", p.User.UserFirstName, p.User.UserLastName)).FirstOrDefault(),

                activity.ActivityDelayReason = activity.ActivityDelayReason = activityTransfer.ReasonForDelay;
                activity.ActivityImmediateAction = activityTransfer.ImmeadiateAction;
                activity.ActivityProgress = activityTransfer.ProgressNote;
                activity.ActivityNewTimeframeDate = activityTransfer.NewTimeFrame;
                activity.ActStatusId = activityTransfer.StatusId;

                if (isAdd)
                {
                    misContext.Entry(activity).State = EntityState.Added;
                    misContext.Add(activity);
                }
                else
                {
                    misContext.Entry(activity).State = EntityState.Modified;
                }

                misContext.SaveChanges();
                return activity.ActivityId;
            }
            catch (Exception ex)
            {
                //logService.SaveLog(lookupUser.CurrentUser.UserId, LogType.Error, MISPage.ActivityPage, ex, Method.MonitorActivity);
                return 0;
            }
        }

        /// <summary>
        /// Gets the history list comparing one found on db and the intended update data
        /// </summary>
        /// <param name="activityTransfer"></param>
        /// <param name="isAdd"></param>
        /// <param name="activityRow"></param>
        /// <returns></returns>
        private Dictionary<string, HistoryEntry> GetUpdateHistoryList(ActivityTransfer activityTransfer, bool isAdd, Activity activityRow)
        {
            Dictionary<string, HistoryEntry> historyList = new Dictionary<string, HistoryEntry>();
            if (!isAdd)
            {
                historyList = GetHistoryList(activityTransfer, activityRow, isAdd);
            }
            return historyList;
        }

        /// <summary>
        /// Gets a history list which shows the values of monitoring fields before the new changes (if any) are made
        /// </summary>
        /// <param name="activityTransfer">The transfer item with new data</param>
        /// <param name="activityRow">The row being modified or added to db</param>
        /// <param name="isAdd">The current save mode for the activity</param>
        /// <returns>A dic with changes catergorised by what changed</returns>
        private Dictionary<string, HistoryEntry> GetHistoryList(ActivityTransfer activityTransfer, Activity activityRow, bool isAdd)
        {
            Dictionary<string, HistoryEntry> historyList = new Dictionary<string, HistoryEntry>();
            if (isAdd)
            {
                return historyList;
            }

            if ((activityRow.ActStatusId == null || activityRow.ActStatusId == 0))
            {
                string historyElementType = "Status";
                HistoryEntry entry = new HistoryEntry() { FromValue = "", ToValue = activityTransfer.StatusName, ChangeArea = historyElementType };
                historyList.Add(historyElementType, entry);
            }
            else
            {
                if (activityRow.ActStatusId != activityTransfer.StatusId)
                {
                    string historyElementType = "Status";
                    HistoryEntry entry = new HistoryEntry() { FromValue = activityRow.ActStatus.ActStatusName, ToValue = activityTransfer.StatusName, ChangeArea = historyElementType };
                    historyList.Add(historyElementType, entry);
                }
            }

            if (activityRow.ActivityImmediateAction != activityTransfer.ImmeadiateAction)
            {
                string historyElementType = "Immediate Action";
                HistoryEntry entry = new HistoryEntry() { FromValue = activityRow.ActivityImmediateAction, ToValue = activityTransfer.ImmeadiateAction, ChangeArea = historyElementType };
                historyList.Add(historyElementType, entry);
            }
            activityRow.ActivityImmediateAction = activityTransfer.ImmeadiateAction;

            if (!isAdd && activityRow.ActivityNewTimeframeDate != activityTransfer.NewTimeFrame)
            {
                string historyElementType = "New start Date";
                HistoryEntry entry = new HistoryEntry()
                {
                    FromValue = activityRow.ActivityNewTimeframeDate == null ? "--" : activityRow.ActivityNewTimeframeDate.GetValueOrDefault().ToShortDateString(),
                    ToValue = activityTransfer.NewTimeFrame.GetValueOrDefault().ToShortDateString(),
                    ChangeArea = historyElementType
                };
                historyList.Add(historyElementType, entry);
            }
            activityRow.ActivityNewTimeframeDate = activityTransfer.NewTimeFrame;

            if (!isAdd && activityRow.ActivityDelayReason != activityTransfer.ReasonForDelay)
            {
                string historyElementType = "Reason for Delay";
                HistoryEntry entry = new HistoryEntry() { FromValue = activityRow.ActivityDelayReason, ToValue = activityTransfer.ReasonForDelay, ChangeArea = historyElementType };
                historyList.Add(historyElementType, entry);
            }
            activityRow.ActivityDelayReason = activityTransfer.ReasonForDelay;

            if (!isAdd && activityRow.ActivityProgress != activityTransfer.ProgressNote)
            {
                string historyElementType = "Progress";
                HistoryEntry entry = new HistoryEntry() { FromValue = activityRow.ActivityProgress, ToValue = activityTransfer.ProgressNote, ChangeArea = historyElementType };
                historyList.Add(historyElementType, entry);
            }
            activityRow.ActivityProgress = activityTransfer.ProgressNote;

            return historyList;
        }

        /// <summary>
        /// Adds an entry to the Activity History Data table
        /// </summary>
        /// <param name="activity">The activity row</param>
        /// <param name="historyList">The list of elements changesd to add tot he table</param>
        /// <param name="userId">The user id that made the changes</param>
        private void AddActivityHistoryEntry(Activity activity, Dictionary<string, HistoryEntry> historyList, long? userId)
        {
            if (historyList.Count == 0)
            {
                return;
            }

            foreach (KeyValuePair<string, HistoryEntry> item in historyList)
            {
                ActivityHistory history = new ActivityHistory()
                {
                    Activity = misContext.Activity.SingleOrDefault(c => c.ActivityId == activity.ActivityId),
                    ActHistoryDate = DateTime.Now,
                    ActHistoryElement = item.Key,
                    ActiHistoryPreviousValue = item.Value.FromValue,
                    ActiHistoryNewValue = item.Value.ToValue,
                    UserId = userId,
                    DateAdded = DateTime.Now,
                    UserAdded = userId
                };
                misContext.Entry(history).State = EntityState.Added;
                misContext.Add(history);
            }

            misContext.SaveChanges();
        }

        #endregion


    }
}