using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.DI;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.Misc;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class MeetingController : Controller
    {
        private readonly MISContext misContext;
        private readonly List<UserApplication> userApplicationList;
        private readonly List<LookupExpenseItem> expenseLookupList;
        private readonly UserApplication currentUser;
        private readonly long stockholmLocationId;
        //private readonly string meetingManagerEmail;


        public MeetingController([FromServices]MISContext misContext, ILookupUser lookupUser, ILookupExpense lookupExpense)
        {
            this.misContext = misContext;
            this.expenseLookupList = lookupExpense.ExpenseLookupList;
            this.userApplicationList = lookupUser.UserApplicationList;
            this.currentUser = lookupUser.CurrentUser;
            this.stockholmLocationId = misContext.Location.Where(p => p.LocationName == "Stockholm").Select(p => p.LocationId).FirstOrDefault();
        }

        #region Meeting list

        /// <summary>
        /// Get list of meeting for an awpId
        /// </summary>
        /// <param name="awpId">The apwid</param>
        /// <returns>The list of meetings</returns>
        [HttpGet]
        [Route("{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<MeetingTransfer> Get(long awpId)
        {
            var query = misContext.Expense.AsNoTracking()
                         .Include(p => p.Meeting)
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
               //.Where(p => p.Activity.ActivityIsApproved == true)
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
                   expense.Meeting
               });

            List<MeetingTransfer> meetingList = new List<MeetingTransfer>();

            foreach (var item in query.ToList())
            {
                meetingList.Add(new MeetingTransfer
                {
                    ExpenseId = item.ExpenseId,
                    MeetingCode = item.MeetingCode,
                    ExpenseName = item.ExpenseName,
                    BudgetLineCode = item.BudgetLine.BudgetLineName.Substring(0, 4),
                    Organiser = SetUserFullName(item.UserIdOwner),
                    OrganiserEmail = SetUserEmail(item.UserIdOwner, item.ExpenseId),
                    MeetingLocation = item.Location != null ? item.Location.LocationName : "",
                    MeetingStartDate = item.ExpenseStartDate,
                    MeetingEndDate = item.ExpenseEndDate,
                    MeetingStartMonth = item.ExpenseStartDate != null ? item.ExpenseStartDate.Value.Month.ToString("d2") : "",
                    MeetingEndMonth = item.ExpenseEndDate != null ? item.ExpenseEndDate.Value.Month.ToString("d2") : "",
                    MeetingComment = item.MeetingComment != null ? item.MeetingComment : "",
                    Amount = item.ExpenseAmount,
                    AmountCommitted = item.ExpenseBudgetAbac.Where(P => P.ExpenseBudgetAbacType.ToLower() != "c8").Sum(p => p.ExpenseBudgetAbacCommitted),

                    StatusName = item.MeetingStatus != null ? item.MeetingStatus.MeetingStatusName : "",
                    StatusIcon = SetStatusIcon(item.expense),
                    StatusTooltip = SetTooltipStatus(item.expense),
                    ApprovalStatusName = SetApprovalStatusLabel(item.expense),
                    UnitCode = expenseLookupList.Where(p => p.ExpenseId == item.ExpenseId).Select(p => p.UnitCode).FirstOrDefault(),
                    SectionCode = expenseLookupList.Where(p => p.ExpenseId == item.ExpenseId).Select(p => p.SectionCode).FirstOrDefault(),
                    DPCode = expenseLookupList.Where(p => p.ExpenseId == item.ExpenseId).Select(p => p.DPCode).FirstOrDefault(),
                    MeetingInitiationDate = CalculateInitationDate(item.expense),
                    MeetingShouldBeInitiated = CalculateInitationBool(item.expense),
                    SubMeetingNumber = item.Meeting.Count(),
                   // SubMeetingList = GetSubMeetingList(item.Meeting),
                });
            };
      
            return meetingList;
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

        private string SetStatusIcon(Expense expense)
        {
            if (expense.MeetingStatus == null)
            {
                return @"\Images\GrayDot.png";
            }
            if (expense.MeetingStatus.MeetingStatusName.Replace(" ", "") == Misc.MeetingSatus.Initiated.ToString())
            {
                return @"\Images\GrayDot.png";
            }
            if (expense.MeetingStatus.MeetingStatusName == Misc.MeetingSatus.Cancelled.ToString())
            {
                return @"\Images\Delete.png";
            }
            if (expense.MeetingStatus.MeetingStatusName == Misc.MeetingSatus.Executed.ToString())
            {
                return @"\Images\BlueDot.png";
            }
            //Meeting coming in less than 15 days
            if (DateTime.Now.CompareTo(expense.ExpenseStartDate.GetValueOrDefault()) < 0 && DateTime.Now.AddDays(15).CompareTo(expense.ExpenseStartDate.GetValueOrDefault()) >= 0)
            {
                return @"\Images\OrangeDot.png"; ;
            }
            //Meeting delay
            if (DateTime.Now.CompareTo(expense.ExpenseEndDate.GetValueOrDefault()) > 0)
            {
                return @"\Images\RedDot.png";
            }
            //Meeting Running
            if (DateTime.Now.CompareTo(expense.ExpenseStartDate.GetValueOrDefault()) > 0
                && DateTime.Now.CompareTo(expense.ExpenseEndDate.GetValueOrDefault()) < 0
                && (expense.MeetingStatus.MeetingStatusName.Replace(" ", "").ToLower() == Misc.MeetingSatus.CarryForward.ToString().ToLower()
                    || expense.MeetingStatus.MeetingStatusName.Replace(" ", "").ToLower() == Misc.MeetingSatus.Outsourced.ToString().ToLower()
                    || expense.MeetingStatus.MeetingStatusName.Replace(" ", "").ToLower() == Misc.MeetingSatus.Committed.ToString().ToLower()))
            {

                return @"\Images\GreenDot.png";
            }
            else return @"\Images\GrayDot.png";
        }

        private string SetTooltipStatus(Expense expense)
        {
            if (expense.MeetingStatus == null)
            {
                return "No status";
            }
            if (expense.MeetingStatus.MeetingStatusName.Replace(" ", "") == MeetingSatus.Initiated.ToString())
            {
                return expense.MeetingStatus.MeetingStatusName;
            }
            if (expense.MeetingStatus.MeetingStatusName == MeetingSatus.Cancelled.ToString())
            {
                return expense.MeetingStatus.MeetingStatusName;
            }
            if (expense.MeetingStatus.MeetingStatusName == MeetingSatus.Executed.ToString())
            {
                return expense.MeetingStatus.MeetingStatusName;
            }
            //Meeting coming in less than 15 days
            if (DateTime.Now.CompareTo(expense.ExpenseStartDate.GetValueOrDefault()) < 0 && DateTime.Now.AddDays(15).CompareTo(expense.ExpenseStartDate.GetValueOrDefault()) >= 0)
            {
                return "Remain less than 15 days before the start day";
            }
            //Meeting delay
            if (DateTime.Now.CompareTo(expense.ExpenseEndDate.GetValueOrDefault()) > 0)
            {
                return "The start day passed and the meeting didn't take place";
            }
            //Meeting Running
            if (DateTime.Now.CompareTo(expense.ExpenseStartDate.GetValueOrDefault()) > 0
                && DateTime.Now.CompareTo(expense.ExpenseEndDate.GetValueOrDefault()) < 0
                && (expense.MeetingStatus.MeetingStatusName.Replace(" ", "").ToLower() == MeetingSatus.CarryForward.ToString().ToLower()
                    || expense.MeetingStatus.MeetingStatusName.Replace(" ", "").ToLower() == MeetingSatus.Outsourced.ToString().ToLower()
                    || expense.MeetingStatus.MeetingStatusName.Replace(" ", "").ToLower() == MeetingSatus.Committed.ToString().ToLower()))
            {

                return "Meeting running";
            }
            else return expense.MeetingStatus.MeetingStatusName;
        }

        private string SetApprovalStatusLabel(Expense expense)
        {
            if (expense.MeetingApprovalStatus == null) return "";

            if (expense.MeetingApprovalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.BasicChange.ToString())
            {
                return "";
            }
            if (expense.MeetingApprovalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.CriticalChange.ToString() && !expense.MeetingIsHoUapproval.GetValueOrDefault()) 
            {
                return "Wait head of unit approval";
            }
            if (expense.MeetingApprovalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.CriticalChange.ToString() && expense.MeetingIsHoUapproval.GetValueOrDefault())
            {
                return "Wait SMT approval";
            }
            if (expense.MeetingApprovalStatus.MeetingApprovalStatusDescription == MeetingTypeOfApproval.NotCriticalChange.ToString())
            {
                return "Wait head of section approval";
            }
            return "";
        }

        #endregion
    }
}
