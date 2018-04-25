using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.DI;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.ExportClass;
using Microsoft.AspNetCore.Hosting;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class MeetingController : Controller
    {
        private readonly MISContext misContext;
        private readonly string defaultUserPictureUrl;
        private readonly List<UserApplication> userApplicationList;
        private readonly List<LookupExpenseItem> expenseLookupList;
        private readonly UserApplication currentUser;
        private readonly long stockholmLocationId;
        //private readonly string meetingManagerEmail;


        public MeetingController([FromServices]MISContext misContext, ILookupUser lookupUser, ILookupExpense lookupExpense, IHostingEnvironment server)
        {
            this.misContext = misContext;
            this.expenseLookupList = lookupExpense.ExpenseLookupList;
            this.userApplicationList = lookupUser.UserApplicationList;
            this.currentUser = lookupUser.CurrentUser;
            this.stockholmLocationId = misContext.Location.Where(p => p.LocationName == "Stockholm").Select(p => p.LocationId).FirstOrDefault();
            this.defaultUserPictureUrl = server.WebRootPath + @"\images\DefaultUser.png";
        }

        #region Meeting list

        [HttpGet]
        [Route("{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<MeetingTransfer> Get(long awpId)
        {
            var query = misContext.Expense.AsNoTracking()
               .Include(p => p.Meeting).AsNoTracking()
               .Include(p => p.BudgetLine).AsNoTracking()
               .Include(p => p.ExpenseType).AsNoTracking()
               .Include(p => p.ExpenseBudgetAbac).AsNoTracking()
               .Include(p => p.Location).AsNoTracking()
               .Include(p => p.MeetingStatus).AsNoTracking()
               .Include(p => p.MeetingApprovalStatus).AsNoTracking()
               .Where(p => p.Activity.AWPId.GetValueOrDefault() == awpId)
               .Where(p => p.ExpenseType.ExpenseTypeIsMeeting.GetValueOrDefault())
               .Where(p=>p.ExpenseIsApproved == true)
               .Where(p => p.Activity.ActivityIsDeleted != true)
               .Where(p => p.Activity.ActivityIsValidated == true)
               .Where(p => p.Activity.ActivityIsApproved == true)
               .Select(expense => new {
                   expense.ExpenseId,
                   expense.MeetingCode,
                   expense.ExpenseName,
                   expense.BudgetLine.BudgetLineName,
                   expense.BudgetLineId,
                   expense.UserIdOwner,
                   expense.Location,
                   expense.ExpenseStartDate,
                   expense.ExpenseEndDate,
                   expense.MeetingComment,
                   expense.ExpenseAmount,
                   expense.MeetingStatus,
                   expense.MeetingStatusId,
                   expense.Activity.Unit,
                   expense.Activity.Dsp,
                   expense.MeetingApprovalStatus,
                   expense.MeetingIsHoUapproval,
                   expense.Activity.Section,

                   //expense.Meeting
                   //expense.ExpenseBudgetAbac
               }).ToList();

               List<MeetingTransfer> result = new List<MeetingTransfer>();

               foreach (var expense in query.ToList())
               {
                   result.Add(new MeetingTransfer{

                    ExpenseId = expense.ExpenseId,
                    MeetingCode = expense.MeetingCode,
                    ExpenseName = expense.ExpenseName,
                    BudgetLineCode = expense.BudgetLineName.Substring(0, 4),
                    BudgetLineId = expense.BudgetLineId,
                    Organiser = SetUserFullName(expense.UserIdOwner),
                    OwnerId = expense.UserIdOwner,
                    OrganiserEmail = SetUserEmail(expense.UserIdOwner, expense.ExpenseId),
                    MeetingLocation = expense.Location != null ? expense.Location.LocationName : "",
                    MeetingStartDate = expense.ExpenseStartDate,
                    MeetingEndDate = expense.ExpenseEndDate,
                    MeetingStartMonth = expense.ExpenseStartDate != null ? expense.ExpenseStartDate.Value.Month.ToString("d2") : "",
                    MeetingEndMonth = expense.ExpenseEndDate != null ? expense.ExpenseEndDate.Value.Month.ToString("d2") : "",
                    MeetingComment = expense.MeetingComment != null ? expense.MeetingComment : "",
                    Amount = expense.ExpenseAmount,
                    StatusName = expense.MeetingStatus != null ? expense.MeetingStatus.MeetingStatusName : "",
                    MeetingStatusId = expense.MeetingStatusId,
                    StatusIcon = SetStatusIcon(expense.MeetingStatus, expense.ExpenseStartDate, expense.ExpenseEndDate),
                    StatusTooltip = SetTooltipStatus(expense.MeetingStatus, expense.ExpenseStartDate, expense.ExpenseEndDate),
                    ApprovalStatusName = SetApprovalStatusLabel(expense.MeetingApprovalStatus, expense.MeetingIsHoUapproval),
                    UnitCode = expense.Unit.UnitCode,
                    UnitId = expense.Unit.UnitId,
                    DPCode = expense.Dsp.DspCode,
                    DpId = expense.Dsp.DspId,
                    SectionCode = expense.Section.SectionCode,
                    SectionId = expense.Section.SectionId,
                    MeetingInitiationDate = CalculateInitationDate(misContext.Expense.Where(p=>p.ExpenseId == expense.ExpenseId).First()),
                    MeetingShouldBeInitiated = CalculateInitationBool(misContext.Expense.Where(p=>p.ExpenseId == expense.ExpenseId).First()),
                    SubMeetingNumber =misContext.Meeting.Where(p=>p.ExpenseId == expense.ExpenseId).Count(),
                    AmountCommitted = misContext.ExpenseBudgetAbac.Where(p => p.ExpenseBudgetAbacType.ToLower() != "c8" && p.ExpenseId == expense.ExpenseId).Sum(p => p.ExpenseBudgetAbacCommitted),
                   });
                   
               };
            return result;
        }

        #endregion

        #region Meeting

        /// <summary>
        /// Get meeting detail
        /// </summary>
        /// <param name="expenseId">The id of the meeting</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Id/{expenseId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public MeetingTransfer GetMeeting(long expenseId)
        {
            var expense = (from result in misContext.Expense
             .Include(p=>p.Meeting).AsNoTracking()
             .Include(p => p.Activity).AsNoTracking()
             .Include(p => p.Activity.Strategy).AsNoTracking()
             .Include(p => p.Activity.Unit).AsNoTracking()
             .Include(p => p.Activity.Dsp).AsNoTracking()
             .Include(p => p.Activity.Awp).AsNoTracking()
             .Include(p => p.ExpenseType).AsNoTracking()
             .Include(p => p.BudgetLine).AsNoTracking()
             .Include(p => p.UserIdOwnerNavigation).AsNoTracking()
             .Include(p => p.ExpenseBudgetAbac).AsNoTracking()
             .Include(p => p.Location).AsNoTracking()
             .Include(p => p.MeetingStatus).AsNoTracking()
             .Include(p => p.MeetingApprovalStatus).AsNoTracking()
             .Where(p => p.ExpenseId == expenseId).AsNoTracking()
                           select result).FirstOrDefault();

            if (expense != null)
            {
                var meetingTransfer = new MeetingTransfer()
                {
                    ExpenseId = expense.ExpenseId,
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = expense.Activity.ActivityId, ActivityCodeSequence = expense.Activity.ActivityCodeSequence, Strategy = expense.Activity.Strategy, Unit = expense.Activity.Unit, Awp = expense.Activity.Awp, Dsp = expense.Activity.Dsp }),
                    UnitId = expense.Activity.UnitId,
                    StatusName = expense.MeetingStatus == null ? "" : expense.MeetingStatus.MeetingStatusName,
                   // StatusId = expense.MeetingStatusId,
                    MeetingCode = expense.MeetingCode,
                    ExpenseName = expense.ExpenseName,
                    BudgetLineName = expense.BudgetLine == null ? "" : expense.BudgetLine.BudgetLineName,
                    BudgetLineId = expense.BudgetLineId,
                    Organiser = SetUserFullName(expense.UserIdOwner),
                    OrganiserPicture = Helper.SetUserPicture(expense.UserIdOwnerNavigation, defaultUserPictureUrl),
                   // OrganiserId = expense.UserIdOwner,
                    InitialAmount = expense.ExpenseInitialAmount,
                    Amount = expense.ExpenseAmount,
                    AmountCommitted = expense.ExpenseBudgetAbac.Where(P => P.ExpenseBudgetAbacType.ToLower() != "c8").Sum(p => p.ExpenseBudgetAbacCommitted),
                    AmountPaid = expense.ExpenseBudgetAbac.Sum(p => p.ExpenseBudgetAbacPaid),
                    MeetingStartDate = expense.ExpenseStartDate,
                    MeetingEndDate = expense.ExpenseEndDate,
                    MeetingDuration = expense.MeetingDuration,
                    MeetingNumIntParticipants = expense.MeetingNumIntParticipants,
                    MeetingNumExtParticipants = expense.MeetingNumExtParticipants,
                    MeetingNumIntParticipantsActual = expense.MeetingNumIntParticipantsActual,
                    MeetingNumExtParticipantsActual = expense.MeetingNumExtParticipantsActual,
                    MeetingComment = expense.MeetingComment,
                    Location = expense.Location == null ? "" : expense.Location.LocationName,
                    LocationId = expense.LocationId,
                    LocationCity = expense.LocationCity,
                    MeetingOutsideSwedenNote = expense.MeetingOutsideSwedenNote,
                    MeetingInitiationDate = CalculateInitationDate(expense),

                    IsOutsourced = expense.MeetingIsOutsourced.GetValueOrDefault(),
                    IsDeclarationOfInterest = expense.MeetingIsDeclarationInterest.GetValueOrDefault(),
                    IsNonEUCountry = expense.MeetingIsNonEnlargementCountries.GetValueOrDefault(),

                    IsEndDatePending = expense.MeetingIsEndDatePending.GetValueOrDefault(),
                    IsStartDatePending = expense.MeetingIsStartDatePending.GetValueOrDefault(),
                    IsNumExtParticipantsPending = expense.MeetingIsNumExtParticipantsPending.GetValueOrDefault(),
                    IsNumIntParticipantsPending = expense.MeetingIsNumIntParticipantsPending.GetValueOrDefault(),
                    IsLocationPending = expense.MeetingIsLocationPending.GetValueOrDefault(),
                    IsAmountPending = expense.MeetingIsAmountPending.GetValueOrDefault(),
                    IsHoUApproval = expense.MeetingIsHoUapproval.GetValueOrDefault(),
                    IsNamePending = expense.MeetingIsNamePending.GetValueOrDefault(),

                   // ApprovalStatusName = SetApprovalStatusLabel(expense),
                    ApprovalStatusDescription = expense.MeetingApprovalStatus != null ? expense.MeetingApprovalStatus.MeetingApprovalStatusDescription : "",
                    UserWithEditRight = expense.Activity.ActivityUserApplicationCoreStaff != null ? expense.Activity.ActivityUserApplicationCoreStaff.Select(p => p.UserId).ToList() : null,

                    SubMeetingNumber = expense.Meeting.Count(),
                };

                //SetUserRight(meetingTransfer);

                return meetingTransfer;
            }
            else
                return new MeetingTransfer();
        }

        /// <summary>
        /// Save the changes in the selected meeting
        /// </summary>
        /// <param name="meetingTransfer">The meeting to change</param>
        [HttpPost]
        public void Post([FromBody]MeetingTransfer meetingTransfer)
        {
            try
            {
                Expense expense = misContext.Expense.Where(p => p.ExpenseId == meetingTransfer.ExpenseId).FirstOrDefault();

                if (expense == null)
                {
                    return;
                }

                expense.DateMod = DateTime.Now;
                expense.UserMod = currentUser.UserId;
               // expense.MeetingStatusId = meetingTransfer.StatusId;
                expense.MeetingCode = meetingTransfer.MeetingCode;
                expense.ExpenseName = meetingTransfer.ExpenseName;
                expense.BudgetLineId = meetingTransfer.BudgetLineId;
               // expense.UserIdOwner = meetingTransfer.OrganiserId;
                expense.ExpenseStartDate = meetingTransfer.MeetingStartDate;
                expense.ExpenseEndDate = meetingTransfer.MeetingEndDate;
                expense.MeetingDuration = meetingTransfer.MeetingDuration;
                expense.MeetingNumIntParticipants = meetingTransfer.MeetingNumIntParticipants;
                expense.MeetingNumExtParticipants = meetingTransfer.MeetingNumExtParticipants;
                expense.MeetingNumIntParticipantsActual = meetingTransfer.MeetingNumIntParticipantsActual;
                expense.MeetingNumExtParticipantsActual = meetingTransfer.MeetingNumExtParticipantsActual;
                expense.MeetingComment = meetingTransfer.MeetingComment;
                expense.LocationId = meetingTransfer.LocationId;
                expense.LocationCity = meetingTransfer.LocationCity;
                expense.MeetingOutsideSwedenNote = meetingTransfer.MeetingOutsideSwedenNote;
                expense.MeetingIsOutsourced = meetingTransfer.IsOutsourced;
                expense.MeetingIsDeclarationInterest = meetingTransfer.IsDeclarationOfInterest;
                expense.MeetingIsNonEnlargementCountries = meetingTransfer.IsNonEUCountry;
                expense.MeetingIsEndDatePending = meetingTransfer.IsEndDatePending;
                expense.MeetingIsStartDatePending = meetingTransfer.IsStartDatePending;
                expense.MeetingIsNumExtParticipantsPending = meetingTransfer.IsNumExtParticipantsPending;
                expense.MeetingIsNumIntParticipantsPending = meetingTransfer.IsNumIntParticipantsPending;
                expense.MeetingIsLocationPending = meetingTransfer.IsLocationPending;
                expense.MeetingIsNamePending = meetingTransfer.IsNamePending;

                expense.MeetingApprovalStatus = misContext.MeetingApprovalStatus.Where(p => p.MeetingApprovalStatusDescription == meetingTransfer.ApprovalStatusDescription).Select(p => p).FirstOrDefault();

                misContext.Entry(expense).State = EntityState.Modified;
                misContext.SaveChanges();

               // if (meetingTransfer.IsEndDatePending || meetingTransfer.IsStartDatePending) SendNotification(expense);
            }
            catch (Exception ex)
            {
                var ttt = ex;
              //  logService.SaveLog(currentUser.UserId, LogType.Error, MISPage.MeetingDetailPage, ex, Method.SaveExpense);
            }
        }

        #endregion

        #region helper

        /// <summary>
        /// Calculate if meeting should be initiated
        /// </summary>
        /// <param name="expense">The meeting data</param>
        /// <returns>A boolean value</returns>
        private bool? CalculateInitationBool(Expense expense)
        {
            DateTime? initiationDate = CalculateInitationDate(expense);

            if (initiationDate == null) return true;

            //if the meeting is not initiated 15 days before the deadline
            if (initiationDate.Value.Month <= DateTime.Now.Month && expense.MeetingStatusId == null) return true;

            return false;
        }

        /// <summary>
        /// Calculate Initiation date for the gantt
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        private DateTime? CalculateInitationDate(Expense expense)
        {
            if (expense.LocationId == null || expense.ExpenseStartDate == null) return null;

            DateTime initiationDate;

            if (expense.MeetingNumExtParticipants.GetValueOrDefault() + expense.MeetingNumIntParticipants.GetValueOrDefault() < 5)
            {
                //Meeting date is 6 weeks before event so 30 days
                initiationDate = expense.ExpenseStartDate.Value.Subtract(TimeSpan.FromDays(30));
            }
            else
            {
                if (expense.LocationId == stockholmLocationId)
                {
                    //Meeting date is 10 weeks before event so 50 days
                    initiationDate = expense.ExpenseStartDate.Value.Subtract(TimeSpan.FromDays(50));
                }
                else
                {
                    //Meeting date is 12 weeks before event so 70 days
                    initiationDate = expense.ExpenseStartDate.Value.Subtract(TimeSpan.FromDays(60));
                }
            }

            return initiationDate;
        }

        /// <summary>
        /// Calculate Initiation date for sub meeting
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        private DateTime? CalculateInitationDate(Meeting meeting)
        {
            if (meeting.LocationId == null || meeting.MeetingStartDate == null || meeting.MeetingName==null) return null;
            DateTime initiationDate;

            if (meeting.MeetingNumExtParticipants.GetValueOrDefault() + meeting.MeetingNumIntParticipants.GetValueOrDefault() < 5)
            {
                //Meeting date is 6 weeks before event so 30 days
                initiationDate = meeting.MeetingStartDate.Value.Subtract(TimeSpan.FromDays(30));
            }
            else
            {
                if (meeting.LocationId == stockholmLocationId)
                {
                    //Meeting date is 10 weeks before event so 50 days
                    initiationDate = meeting.MeetingStartDate.Value.Subtract(TimeSpan.FromDays(50));
                }
                else
                {
                    //Meeting date is 12 weeks before event so 60 days
                    initiationDate = meeting.MeetingStartDate.Value.Subtract(TimeSpan.FromDays(60));
                }
            }

            return initiationDate;
        }

        private string SetUserFullName(long? userIdOwner)
        {
            if (userIdOwner == null) return "";
            return userApplicationList.Where(p => p.UserId == userIdOwner).Select(p => p.UserFullName).FirstOrDefault();
        }

        private string SetUserEmail(long? userIdOwner, long expenseId)
        {
            if (userIdOwner == null) return "";
            return string.Format("mailto:{0}?Subject={1}&body={2}"
                , userApplicationList.Where(p => p.UserId == userIdOwner).Select(p => p.UserEmail).FirstOrDefault()
                , "MIS Inquiry"
                , new Uri("http://" + Request.Host.ToString() + "/Meeting/MeetingDetail/" + expenseId));
        }

        private string SetStatusIcon(MeetingStatus status, DateTime? startDate, DateTime? endDate)
        {
            if (status == null)
            {
                return @"\Images\GrayDot.png";
            }
            if (status.MeetingStatusName.Replace(" ", "") == Misc.MeetingSatus.Initiated.ToString())
            {
                return @"\Images\GrayDot.png";
            }
            if (status.MeetingStatusName == Misc.MeetingSatus.Cancelled.ToString())
            {
                return @"\Images\Delete.png";
            }
            if (status.MeetingStatusName == Misc.MeetingSatus.Executed.ToString())
            {
                return @"\Images\BlueDot.png";
            }
            //Meeting coming in less than 15 days
            if (DateTime.Now.CompareTo(startDate.GetValueOrDefault()) < 0 && DateTime.Now.AddDays(15).CompareTo(startDate.GetValueOrDefault()) >= 0)
            {
                return @"\Images\OrangeDot.png"; ;
            }
            //Meeting delay
            if (DateTime.Now.CompareTo(endDate.GetValueOrDefault()) > 0)
            {
                return @"\Images\RedDot.png";
            }
            //Meeting Running
            if (DateTime.Now.CompareTo(startDate.GetValueOrDefault()) > 0
                && DateTime.Now.CompareTo(endDate.GetValueOrDefault()) < 0
                && (status.MeetingStatusName.Replace(" ", "").ToLower() == Misc.MeetingSatus.CarryForward.ToString().ToLower()
                    || status.MeetingStatusName.Replace(" ", "").ToLower() == Misc.MeetingSatus.Outsourced.ToString().ToLower()
                    || status.MeetingStatusName.Replace(" ", "").ToLower() == Misc.MeetingSatus.Committed.ToString().ToLower()))
            {

                return @"\Images\GreenDot.png";
            }
            else return @"\Images\GrayDot.png";
        }

        private string SetTooltipStatus(MeetingStatus status, DateTime? startDate, DateTime? endDate)
        {
            if (status == null)
            {
                return "No status";
            }
            if (status.MeetingStatusName.Replace(" ", "") == MeetingSatus.Initiated.ToString())
            {
                return status.MeetingStatusName;
            }
            if (status.MeetingStatusName == MeetingSatus.Cancelled.ToString())
            {
                return status.MeetingStatusName;
            }
            if (status.MeetingStatusName == MeetingSatus.Executed.ToString())
            {
                return status.MeetingStatusName;
            }
            //Meeting coming in less than 15 days
            if (DateTime.Now.CompareTo(startDate.GetValueOrDefault()) < 0 && DateTime.Now.AddDays(15).CompareTo(startDate.GetValueOrDefault()) >= 0)
            {
                return "Remain less than 15 days before the start day";
            }
            //Meeting delay
            if (DateTime.Now.CompareTo(endDate.GetValueOrDefault()) > 0)
            {
                return "The start day passed and the meeting didn't take place";
            }
            //Meeting Running
            if (DateTime.Now.CompareTo(startDate.GetValueOrDefault()) > 0
                && DateTime.Now.CompareTo(endDate.GetValueOrDefault()) < 0
                && (status.MeetingStatusName.Replace(" ", "").ToLower() == MeetingSatus.CarryForward.ToString().ToLower()
                    || status.MeetingStatusName.Replace(" ", "").ToLower() == MeetingSatus.Outsourced.ToString().ToLower()
                    || status.MeetingStatusName.Replace(" ", "").ToLower() == MeetingSatus.Committed.ToString().ToLower()))
            {

                return "Meeting running";
            }
            else return status.MeetingStatusName;
        }

        private string SetApprovalStatusLabel(MeetingApprovalStatus approvalStatus, bool? isHoUapproval)
        {
            if (approvalStatus == null) return "";

            if (approvalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.BasicChange.ToString())
            {
                return "";
            }
            if (approvalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.CriticalChange.ToString() && !isHoUapproval.GetValueOrDefault()) 
            {
                return "Wait head of unit approval";
            }
            if (approvalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.CriticalChange.ToString() && isHoUapproval.GetValueOrDefault())
            {
                return "Wait SMT approval";
            }
            if (approvalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.NotCriticalChange.ToString())
            {
                return "Wait head of section approval";
            }
            return "";
        }

        #endregion
    
        #region Export to Csv

        /// <summary>
        /// Get data to export to csv file
        /// </summary>
        /// <param name="awpId">The awpid</param>
        /// <returns>List of ProcurementExport for the awpid selected</returns>
        [HttpGet]
        [Route("ExportData/{awpId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<MeetingExport> ExportData(long awpId)
        {
            misContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

             var query = misContext.Expense.AsNoTracking()
               .Include(p => p.Meeting).AsNoTracking()
               .Include(p => p.BudgetLine).AsNoTracking()
               .Include(p => p.ExpenseType).AsNoTracking()
               .Include(p => p.ExpenseBudgetAbac).AsNoTracking()
               .Include(p => p.Location).AsNoTracking()
               .Include(p => p.MeetingStatus).AsNoTracking()
               .Include(p => p.MeetingApprovalStatus).AsNoTracking()
               .Where(p => p.Activity.AWPId.GetValueOrDefault() == awpId)
               .Where(p => p.ExpenseType.ExpenseTypeIsMeeting.GetValueOrDefault())
               .Where(p=>p.ExpenseIsApproved == true)
               .Where(p => p.Activity.ActivityIsDeleted != true)
               .Where(p => p.Activity.ActivityIsValidated == true)
               .Where(p => p.Activity.ActivityIsApproved == true)
               .Select(expense => new
               {
                   expense,
                   expense.ExpenseId,
                   expense.MeetingCode,
                   expense.ExpenseName,
                   expense.BudgetLine,
                   expense.UserIdOwner,
                   expense.Location,
                   expense.ExpenseStartDate,
                   expense.ExpenseEndDate,
                   expense.MeetingComment,
                   expense.ExpenseAmount,
                   expense.ExpenseBudgetAbac,
                   expense.MeetingStatus,
                   expense.Meeting,
                   expense.MeetingApprovalStatus,
                   expense.MeetingIsHoUapproval,
               });

            List<MeetingExport> meetingList = new List<MeetingExport>();

            foreach (var item in query.ToList())
            {
                meetingList.Add(new MeetingExport
                {
                    Id = item.ExpenseId,
                    Code = item.MeetingCode,
                    ExpenseName = item.ExpenseName,
                    BudgetLine = item.BudgetLine.BudgetLineName.Substring(0, 4),
                    Organiser = SetUserFullName(item.UserIdOwner),
                    Location = item.Location != null ? item.Location.LocationName : "",
                    StartDate = item.ExpenseStartDate,
                    EndDate = item.ExpenseEndDate,                   
                    InitiationDate = CalculateInitationDate(item.expense),
                    Amount = item.ExpenseAmount,
                    Committed = item.ExpenseBudgetAbac.Where(P => P.ExpenseBudgetAbacType.ToLower() != "c8").Sum(p => p.ExpenseBudgetAbacCommitted),
                    Status = item.MeetingStatus != null ? item.MeetingStatus.MeetingStatusName : "",
                    ChangeRequested = SetApprovalStatusLabel(item.MeetingApprovalStatus, item.MeetingIsHoUapproval),
                    MeetingComment = item.MeetingComment != null ? item.MeetingComment : "",
                });
            };

            return meetingList;
        }

        #endregion
    }
}
