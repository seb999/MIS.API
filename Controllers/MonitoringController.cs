using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Hosting;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.Misc;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class MonitoringController : Controller
    {
        //private readonly ILookupUser lookupUser;
        //private readonly UserApplication currentUser;
        //private readonly string defaultUserPictureUrl;
        //private readonly IHostingEnvironment hostingEnvironement;
        //private readonly LogService logService;
        private readonly MISContext misContext;

        //public MonitoringController([FromServices]MISContext misContext, LogService logService, ILookupUser lookupUser, IHostingEnvironment server)
        public MonitoringController([FromServices]MISContext misContext, IHostingEnvironment server)
        {
            this.misContext = misContext;
            //this.lookupUser = lookupUser;
            //this.currentUser = lookupUser.CurrentUser;
            //this.defaultUserPictureUrl = server.WebRootPath + @"\images\DefaultUser.png";
            //this.hostingEnvironement = server;
            //this.logService = logService;
        }

        internal MonitoringController(MISContext misContext)
        {
            this.misContext = misContext;
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
                    LastMonitorDate = activity.ActivityHistory == null ? null : activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).Select(p => p.ActHistoryDate).FirstOrDefault(),
                    LastMonitoredByUserName = activity.ActivityHistory == null ? null : activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).Select(p => string.Format("{0} {1}", p.User.UserFirstName, p.User.UserLastName)).FirstOrDefault(),

                    ReasonForDelay = activity.ActivityDelayReason,
                    ImmeadiateAction = activity.ActivityImmediateAction,
                    ProgressNote = activity.ActivityProgress,
                    NewTimeFrame = activity.ActivityNewTimeframeDate,
                    StatusName = activity.ActStatus == null ? "" : activity.ActStatus.ActStatusName,
                    StatusId = activity.ActStatusId,
                };

                transfer.MonitoringHistoryList = activity.ActivityHistory.OrderByDescending(p => p.ActHistoryDate).ToList();
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
            try
            {
                Activity activity = misContext.Activity.Where(p => p.ActivityId == activityTransfer.ActivityId).FirstOrDefault();

                bool isAdd = false;
                if (activity == null)
                {
                    isAdd = true;
                    activity = new Activity()
                    {
                       // UserAdded = currentUser.UserId,
                        DateAdded = DateTime.Now,
                        ActivityIsRequested = false,
                        ActivityIsValidated = false,
                        ActivityIsForReview = false,
                        ActStatusId = 5,
                        ActAppStatusId = 5,
                        ActivityStartDate = new DateTime(DateTime.Now.Year, 1, 1),
                        ActivityEndDate = new DateTime(DateTime.Now.Year, 12, 31)
                        //add start to end date 1 jan to 31 dec here
                    };
                }
                else
                {
                    activity.DateMod = DateTime.Now;
                  //  activity.UserMod = currentUser.UserId;
                    activity.ActivityStartDate = activityTransfer.StartDate;
                    activity.ActivityEndDate = activityTransfer.EndDate;
                }

               
                activity.ActivityName = activityTransfer.ActivityName;
                activity.ActivityDescription = activityTransfer.ActivityDescription;
                activity.StrategyId = activityTransfer.StrategyId;
                activity.UnitId = activityTransfer.UnitId;
                activity.DSPId = activityTransfer.DpId;
                activity.SectionId = activityTransfer.SectionId;
                activity.AWPId = activityTransfer.AwpId;
                activity.GroupActivityId = activityTransfer.FunctionalGroupId == 0 ? null : activityTransfer.FunctionalGroupId;
                activity.UserIdActivityLeader = activityTransfer.ActivityLeaderId == 0 ? null : activityTransfer.ActivityLeaderId;
                activity.PriorityId = activityTransfer.CapacityLevelId == 0 ? null : activityTransfer.CapacityLevelId;
                activity.ActivityIsPublicHealthTraining = activityTransfer.IsPublicHealthTraining;
                activity.ActivityIsPrepardness = activityTransfer.IsPrepardness;
                activity.ActivityIsIct = activityTransfer.IsICT;
                activity.ActivityIsHealthCom = activityTransfer.IsHealthCom;
                activity.ActivityIsEnlargementCountries = activityTransfer.IsEnlargementCountries;
                activity.ActivityIsEnpCountries = activityTransfer.IsEnpCountries;
                activity.ActivityIsOtherThirdCountries = activityTransfer.IsOtherThirdCountries;

              

                //that's good
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
                //logService.SaveLog(lookupUser.CurrentUser.UserId, LogType.Error, MISPage.ActivityPage, ex, Method.SaveActivity);
                return 0;
            }
        }

        #endregion

      
    }
}