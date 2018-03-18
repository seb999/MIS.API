using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.Misc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using ECDC.MIS.API.Model; 
using ECDC.MIS.API.DI;  
using ECDC.MIS.API.ExportClass;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly MISContext misContext;
        private readonly string defaultUserPictureUrl;
        private readonly UserApplication currentUser;
        private readonly IHostingEnvironment hostingEnvironement;
        private readonly ILookupUser lookupUser;


        public ActivityController([FromServices]MISContext misContext, ILookupUser lookupUser, IHostingEnvironment server)
        {
            this.misContext = misContext;
            this.defaultUserPictureUrl = server.WebRootPath + @"\images\DefaultUser.png";
            this.currentUser = lookupUser.CurrentUser;
            this.hostingEnvironement = server;
            this.lookupUser = lookupUser;
        }

        #region Activity list and Expense list related for Activity page

        [HttpGet]
        [Route("{awpId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<ActivityTransfer> Get(long awpId)
        {
            misContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var query = misContext.Activity
                .Include(p => p.Strategy)
                .Include(p => p.Unit)
                .Include(p => p.Dsp)
                .Include(p => p.Section)
                .Include(p => p.Awp)
                .Include(p => p.ActStatus)
                .Include(p => p.Expense).ThenInclude(e => e.BudgetLine)
                .Include(p => p.Expense).ThenInclude(e => e.ExpenseType)
                .Where(p => p.AWPId == awpId)
                .Where(p => p.ActivityIsDeleted.GetValueOrDefault() != true)
                .Where(p => p.ActivityIsValidated == true)
                //.Where(p => p.ActivityIsApproved == true)
                .Select(activity => new {
                    activity.ActivityId,
                    activity.ActivityName,
                    activity.ActStatusId,
                    activity.ActivityCodeSequence,
                    activity.SectionId,
                    activity.AWPId,
                    activity.UnitId,
                    activity.StrategyId,
                    activity.DSPId,
                    activity.UserIdActivityLeader,
                    activity.Section,
                    activity.Awp,
                    activity.Strategy,
                    activity.Unit,
                    activity.Expense,
                    activity.ActStatus,
                    activity.Dsp,
                    activity.UserIdActivityLeaderNavigation.UserLastName,
                    activity.UserIdActivityLeaderNavigation.UserFirstName
                });

            List<ActivityTransfer> activities = new List<ActivityTransfer>();

            foreach (var activity in query.ToList())
            {
                activities.Add(new ActivityTransfer
                {
                    ActivityId = activity.ActivityId,
                    ActivityIdName = activity.ActivityId.ToString(),
                    ActivityName = activity.ActivityName,
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = activity.ActivityId, ActivityCodeSequence = activity.ActivityCodeSequence, Strategy = activity.Strategy, Unit = activity.Unit, Awp = activity.Awp, Dsp = activity.Dsp }),
                    AwpName = activity.Awp == null ? "" : activity.Awp.AWPName,
                    AwpId = activity.AWPId.GetValueOrDefault(),
                    StrategyCode = activity.Strategy == null ? "" : activity.Strategy.StartegyName,
                    StrategyId = activity.StrategyId.GetValueOrDefault(),
                    UnitCode = activity.Unit == null ? "" : activity.Unit.UnitCode,
                    UnitId = activity.UnitId.GetValueOrDefault(),
                    DpCode = activity.Dsp == null ? "" : activity.Dsp.DspCode,
                    DpId = activity.DSPId.GetValueOrDefault(),
                    SectionCode = activity.Section == null ? "" : activity.Section.SectionCode,
                    SectionId = activity.SectionId.GetValueOrDefault(),
                    ActivityLeader = activity.UserFirstName + " " + activity.UserLastName,
                    ActivityLeaderId = activity.UserIdActivityLeader.GetValueOrDefault(),
                    StatusName = activity.ActStatus == null ? "" : activity.ActStatus.ActStatusName,
                    StatusIcon = activity.ActStatus == null ? "" : activity.ActStatus.ActStatusImgPath.Replace("gif", "png").Replace("~", "").ToLower(),
                    StatusId = activity.ActStatusId,
                    Amount = activity.Expense.Sum(p => p.ExpenseAmount),
                    ExpenseList = GetExpenseList(activity.Expense)
                });
            }

            return activities;
        }

        /// <summary>
        /// Return basic expense list for an activity. Used only in for the activity grid for performance reason
        /// </summary>
        /// <param name="expenseList">The basic expense list</param>
        /// <returns></returns>
        private List<ExpenseTransfer> GetExpenseList(ICollection<Expense> expenseList)
        {
            var query = (from expense in expenseList
                    
                         select new ExpenseTransfer()
                         {
                             ExpenseId = expense.ExpenseId,
                             ExpenseName = expense.ExpenseName,
                             BudgetLineId = expense.BudgetLineId.GetValueOrDefault(),
                             BudgetLineName = expense.BudgetLine == null ? "" : expense.BudgetLine.BudgetLineName,
                             InitialAmount = expense.ExpenseInitialAmount,
                             Amount = expense.ExpenseAmount,
                             ExpenseTypeName = expense.ExpenseType == null ? "" : expense.ExpenseType.ExpenseTypeName,
                             //OrganiserPicture = expense.UserIdOwnerNavigation == null ? SetUserPicture2(null) : SetUserPicture2(expense.UserIdOwnerNavigation.UserPicture),
                         }).ToList();
            return query;
        }

        /// <summary>
        /// Get data to export to csv file
        /// </summary>
        /// <param name="awpId">The awpid</param>
        /// <returns>List of activity for the awpid selected</returns>
        [HttpGet]
        [Route("ExportData/{awpId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<ActivityExport> ExportData(long awpId)
        {
            misContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var query = misContext.Activity
                .Include(p => p.Strategy)
                .Include(p => p.Unit)
                .Include(p => p.Dsp)
                .Include(p => p.Section)
                .Include(p => p.Awp)
                .Include(p => p.ActStatus)
                .Include(p => p.Expense).ThenInclude(e => e.BudgetLine)
                .Include(p => p.Expense).ThenInclude(e => e.ExpenseType)
                .Where(p => p.AWPId == awpId)
                .Where(p => p.ActivityIsDeleted.GetValueOrDefault() != true)
                .Where(p => p.ActivityIsValidated == true)
                //.Where(p => p.ActivityIsApproved == true)
                .Select(activity => new {
                    activity.ActivityId,
                    activity.ActivityName,
                    activity.ActStatusId,
                    activity.ActivityCodeSequence,
                    activity.SectionId,
                    activity.AWPId,
                    activity.UnitId,
                    activity.StrategyId,
                    activity.DSPId,
                    activity.UserIdActivityLeader,
                    activity.Section,
                    activity.Awp,
                    activity.Strategy,
                    activity.Unit,
                    activity.Expense,
                    activity.ActStatus,
                    activity.Dsp,
                    activity.UserIdActivityLeaderNavigation.UserLastName,
                    activity.UserIdActivityLeaderNavigation.UserFirstName
                });

            List<ActivityExport> activities = new List<ActivityExport>();

            foreach (var activity in query.ToList())
            {
                activities.Add(new ActivityExport
                {
                    ActivityId = activity.ActivityId,
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = activity.ActivityId, ActivityCodeSequence = activity.ActivityCodeSequence, Strategy = activity.Strategy, Unit = activity.Unit, Awp = activity.Awp, Dsp = activity.Dsp }),
                    ActivityName = activity.ActivityName,
                    StrategyCode = activity.Strategy == null ? "" : activity.Strategy.StartegyName,
                    UnitCode = activity.Unit == null ? "" : activity.Unit.UnitCode,
                    DpCode = activity.Dsp == null ? "" : activity.Dsp.DspCode,
                    SectionCode = activity.Section == null ? "" : activity.Section.SectionCode,
                    ActivityLeader = activity.UserFirstName + " " + activity.UserLastName,
                    Amount = activity.Expense.Sum(p => p.ExpenseAmount),
                    StatusName = activity.ActStatus == null ? "" : activity.ActStatus.ActStatusName,
                });
            }

            return activities;
        }

        #endregion

        #region Get activity detail

        [HttpGet]
        [Route("GetActivity/{activityId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActivityTransfer GetActivity(long activityId)
        {
            try
            {
                var activity = misContext.Activity
                .Include(p => p.Strategy)
                .Include(p => p.Unit)
                .Include(p => p.Dsp)
                .Include(p => p.Section)
                .Include(p => p.Awp)
                .Include(p => p.ActStatus)
                .Include(p => p.UserIdActivityLeaderNavigation)
                .Include(p => p.Priority)
                .Include(p => p.GroupActivity)
                .Include(p => p.Project)
                .Include(p => p.Expense)
                .ThenInclude(e => e.BudgetLine)
                .Include(p => p.Expense)
                .ThenInclude(e => e.ExpenseType)
               .FirstOrDefault(p => p.ActivityId == activityId);

                if (activity == null)
                    throw new Exception("Invalid Activity Id");

                long awpId = activity.AWPId.GetValueOrDefault();

                var transfer = new ActivityTransfer()
                {
                    ActivityCode = Helper.GetCode(activity),
                    ActivityName = activity.ActivityName,
                    ActivityId = activity.ActivityId,
                    DateAdded = activity.DateAdded,
                    StatusIcon = activity.ActStatus.ActStatusImgPath.Replace("gif", "png").Replace("~", ""),
                    StatusName = activity.ActStatus == null ? "" : activity.ActStatus.ActStatusName,
                    ActivityLeader = activity.UserIdActivityLeaderNavigation == null ? "" : activity.UserIdActivityLeaderNavigation.UserFirstName + " " + activity.UserIdActivityLeaderNavigation.UserLastName,
                    ActivityLeaderId = activity.UserIdActivityLeader.GetValueOrDefault(),

                    ActivityDescription = activity.ActivityDescription,
                    AwpName = activity.Awp == null ? "" : activity.Awp.AWPName,
                    AwpId = activity.AWPId.GetValueOrDefault(),
                    StrategyCode = activity.Strategy == null ? "" : activity.Strategy.StartegyName,
                    StrategyId = activity.StrategyId.GetValueOrDefault(),
                    UnitCode = activity.Unit == null ? "" : activity.Unit.UnitCode,
                    UnitId = activity.UnitId.GetValueOrDefault(),
                    DpCode = activity.Dsp == null ? "" : activity.Dsp.DspCode,
                    DpId = activity.DSPId.GetValueOrDefault(),
                    SectionCode = activity.Section == null ? "" : activity.Section.SectionCode,
                    SectionId = activity.SectionId.GetValueOrDefault(),
                    StartDate = activity.ActivityStartDate,
                    EndDate = activity.ActivityEndDate,
                    CapacityLevelId = activity.PriorityId,
                    CapacityLevel = activity.Priority == null ? "" : activity.Priority.PriorityName,
                    Project = activity.Project == null ? "" : activity.Project.ProjectName,
                    FunctionalGroup = activity.GroupActivity == null ? "" : activity.GroupActivity.GroupActivityName,
                    FunctionalGroupId = activity.GroupActivityId.GetValueOrDefault(),

                    IsPublicHealthTraining = activity.ActivityIsPublicHealthTraining,
                    IsPrepardness = activity.ActivityIsPrepardness,
                    IsICT = activity.ActivityIsIct,
                    IsHealthCom = activity.ActivityIsHealthCom,
                    IsEnlargementCountries = activity.ActivityIsEnlargementCountries,
                    IsEnpCountries = activity.ActivityIsEnpCountries,
                    IsOtherThirdCountries = activity.ActivityIsOtherThirdCountries,
                };

                transfer.ExpenseList = GetExpenseList(activity.ActivityId);
                transfer.ActivityLeaderPicture = Helper.SetUserPicture(activity.UserIdActivityLeaderNavigation, defaultUserPictureUrl);
                return transfer;
            }
            catch (Exception ex)
            {
                var ttt= ex;
                //logService.SaveLog(lookupUser.CurrentUser.UserId, LogType.Error, MISPage.ActivityPage, ex, Method.SaveActivity);
                return null;
            }

          
        }

        /// <summary>
        /// Get list of expenseTransfer attached to activity
        /// </summary>
        /// <param name="activityId">The activity id</param>
        /// <returns>The list of ExpenseTransfer</returns>
        private List<ExpenseTransfer> GetExpenseList(long activityId)
        {
            ExpenseController expenseController = new ExpenseController(misContext, hostingEnvironement, lookupUser);
            return expenseController.GetExpense(activityId);
        }

        #endregion

        #region Get Activity for home page (Activity where current user is staff or leader)

        /// <summary>
        /// Used for home page to display user activities
        /// </summary>
        /// <param name="awpId">The awpId</param>
        /// <returns>The list of activity for a user</returns>
        [HttpGet]
        [Route("user/{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<ActivityTransfer> GetCurrentUserActivity(long awpId)
        {
            var query = (from activity in misContext.Activity
                        .Include(p => p.Strategy).AsNoTracking()
                        .Include(p => p.Unit).AsNoTracking()
                        .Include(p => p.Dsp).AsNoTracking()
                        .Include(p => p.Section).AsNoTracking()
                        .Include(p => p.Awp).AsNoTracking()
                        .Where(p => p.ActivityUserApplicationCoreStaff.Select(p2 => p2.UserId).Contains(currentUser.UserId) || p.UserIdActivityLeader == currentUser.UserId)
                         where activity.AWPId == awpId
                         select new ActivityTransfer()
                         {
                             ActivityId = activity.ActivityId,
                             ActivityCode = Helper.GetCode(activity),
                             ActivityName = activity.ActivityName,
                             StatusIcon = activity.ActStatus.ActStatusImgPath.Replace("gif", "png").Replace("~", ""),
                             StatusName = activity.ActStatus.ActStatusName,
                             ActivityLeader = activity.UserIdActivityLeaderNavigation == null ? "" : activity.UserIdActivityLeaderNavigation.UserFirstName + " " + activity.UserIdActivityLeaderNavigation.UserLastName,
                             ActivityLeaderId = activity.UserIdActivityLeader,
                             //ActivityLeaderPicture = SetUserPicture(activity),
                             AwpName = activity.Awp == null ? "" : activity.Awp.AWPName,
                             AwpId = activity.AWPId.GetValueOrDefault(),
                             StrategyCode = activity.Strategy == null ? "" : activity.Strategy.StartegyName,
                             StrategyId = activity.StrategyId.GetValueOrDefault(),
                             UnitCode = activity.Unit == null ? "" : activity.Unit.UnitCode,
                             UnitId = activity.UnitId.GetValueOrDefault(),
                             DpCode = activity.Dsp == null ? "" : activity.Dsp.DspCode,
                             DpId = activity.DSPId.GetValueOrDefault(),
                             SectionCode = activity.Section == null ? "" : activity.Section.SectionCode,
                             SectionId = activity.SectionId.GetValueOrDefault(),
                             Amount = activity.Expense.Where(p => p.ActivityId == activity.ActivityId).Sum(p => p.ExpenseAmount),
                             //CoreStaffIds = getCoreStaffIds(activity.ActivityUserApplicationCoreStaff),

                         }).ToList();

            return query;
        }

        #endregion

        #region helper

        //[HttpGet]
        //[Route("userPicture/{activityId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        //public string SetUserPicture(long activityId)
        //{
        //    byte[] picture = misContext.Activity.Where(p => p.ActivityId == activityId).Select(p => p.UserIdActivityLeaderNavigation.UserPicture).FirstOrDefault();
        //    if (picture == null)
        //        return Convert.ToBase64String(Helper.ImageToByte(defaultUserPictureUrl)).Substring(1);

        //    return Convert.ToBase64String(picture).Substring(1);
        //}

        ///// <summary>
        ///// Set up the user picture or default picture
        ///// </summary>
        ///// <param name="activity"></param>
        ///// <returns></returns>
        //private string SetUserPicture(Activity activity)
        //{
        //    if (activity.UserIdActivityLeaderNavigation == null)
        //        return Convert.ToBase64String(Helper.ImageToByte(defaultUserPictureUrl));

        //    if (activity.UserIdActivityLeaderNavigation.UserPicture == null)
        //        return Convert.ToBase64String(Helper.ImageToByte(defaultUserPictureUrl));

        //    return Convert.ToBase64String(activity.UserIdActivityLeaderNavigation.UserPicture);
        //}

        #endregion
    }
}