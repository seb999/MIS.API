using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ECDC.MIS.API.TransferClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.DI;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class ExpenseController : Controller
    {
        private readonly MISContext misContext;
        private readonly List<UserApplication> userApplicationList;
        private readonly string defaultUserPictureUrl;
        private readonly UserApplication currentUser;
        private readonly ILookupUser lookupUser;

        public ExpenseController([FromServices]MISContext misContext, IHostingEnvironment server, ILookupUser lookupUser)
        {
            this.misContext = misContext;
            this.defaultUserPictureUrl = server.WebRootPath + @"\images\DefaultUser.png";
            this.currentUser = lookupUser.CurrentUser;
            this.lookupUser = lookupUser;
            this.userApplicationList = lookupUser.UserApplicationList;
        }

        [HttpGet]
        [Route("{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<ExpenseTransfer> Get(long awpId)
        {
            var query = (from expense in misContext.Expense.AsNoTracking()
                .Where(p => p.Activity.AWPId.GetValueOrDefault() == awpId)
                         select new ExpenseTransfer
                         {
                             ActivityId = expense.ActivityId,
                             ExpenseId = expense.ExpenseId,
                             ExpenseName = expense.ExpenseName,
                             Amount = expense.ExpenseAmount,
                             ExpenseTypeName = expense.ExpenseType == null ? "" : expense.ExpenseType.ExpenseTypeName,
                             BudgetLineName = expense.BudgetLine.BudgetLineName,
                             //OrganiserPicture = SetUserPicture(expense.UserIdOwnerNavigation),
                         }).ToList();

            return query;
        }

        [HttpGet]
        [Route("ActivityId/{activityId}")]
        public List<ExpenseTransfer> GetExpense(long activityId)
        {
            var query = (from expense in misContext.Expense
             .Include(p => p.ExpenseType)
             .Include(p => p.BudgetLine)
             .Include(p => p.UserIdOwnerNavigation)
             .Include(p => p.ExpenseBudgetAbac)
             .Include(p => p.ExpenseType)
             .Include(p => p.ExpenseStaff)
             .Include(p => p.Location)
             .Include(p => p.ProcConType)
             .Include(p => p.UserIdAuthOfficerNavigation)
             .Include(p => p.UserIdProcurementOfficerNavigation)
             .Include(p => p.ProcType)
             .Where(p => p.ActivityId == activityId).ToList()
                         select new ExpenseTransfer()
                         {
                             ExpenseId = expense.ExpenseId,
                             ActivityId = expense.ActivityId,
                             ExpenseName = expense.ExpenseName,
                             BudgetLineId = expense.BudgetLineId,
                             BudgetLineName = expense.BudgetLine == null ? "" : expense.BudgetLine.BudgetLineName.Substring(0, 4),
                             ExpenseTypeName = expense.ExpenseType.ExpenseTypeName,
                             ExpenseTypeId = expense.ExpenseTypeId.GetValueOrDefault(),
                             InitialAmount = expense.ExpenseInitialAmount,
                             Amount = expense.ExpenseAmount,
                             StartDate = expense.ExpenseStartDate,
                             EndDate = expense.ExpenseEndDate,
                             AmountCommitted = expense.ExpenseBudgetAbac.Where(P => P.ExpenseBudgetAbacType.ToLower() != "c8").Sum(p => p.ExpenseBudgetAbacCommitted),
                             AmountPaid = expense.ExpenseBudgetAbac.Sum(p => p.ExpenseBudgetAbacPaid),
                             StaffIdList = expense.ExpenseStaff.Select(p => p.UserId).ToList(),
                             ExpenseStaffList = GetExpenseStaffList(expense.ExpenseId),
                             //ExpenseDeliverableList = GetExpenseDeliverableList(expense.ExpenseId),
                             Organiser = expense.UserIdOwnerNavigation == null ? "" : expense.UserIdOwnerNavigation.UserFirstName + " " + expense.UserIdOwnerNavigation.UserLastName,
                             OrganiserId = expense.UserIdOwner,
                             //OrganiserPicture = SetUserPicture(expense),
                             AuthorisingOfficer = expense.UserIdAuthOfficerNavigation == null ? "" : expense.UserIdAuthOfficerNavigation.UserFirstName + " " + expense.UserIdAuthOfficerNavigation.UserLastName,
                             DateAdded = expense.DateAdded,
                             ExpenseNote = expense.ExpenseNote,
                             RecurrenceId = expense.RecurrenceId,
                             CapacityLevelId = expense.CapacityLevelId,
                             IsPriority20 = expense.ExpenseIsPriority20,
                             IsPriority80 = expense.ExpenseIsPriority80,
                             SpdKeyOutputId = expense.SpdKeyOutputId,
                             SpdObjectiveId = expense.SpdObjectiveId,

                             //Total FTE
                             TotalFte = expense.ExpenseStaff != null ? Math.Round(expense.ExpenseStaff.Sum(p => p.ExpenseStaffPlanDay / 160).GetValueOrDefault(), 2) : 0,
                             TotalRequestedFte = expense.ExpenseStaff != null ? Math.Round(expense.ExpenseStaff.Sum(p => p.ExpenseStaffRequestedDay / 160).GetValueOrDefault(), 2) : 0,
                             TotalRequestedDay = expense.ExpenseStaff != null ? Math.Round(expense.ExpenseStaff.Sum(p => p.ExpenseStaffRequestedDay).GetValueOrDefault(), 2) : 0,
                             TotalPlanDay = expense.ExpenseStaff != null ? Math.Round(expense.ExpenseStaff.Sum(p => p.ExpenseStaffPlanDay).GetValueOrDefault(), 2) : 0,

                             //meeting fields
                             MeetingLocationCity = expense.LocationCity,
                             MeetingLocation = expense.Location == null ? "" : expense.Location.LocationName,
                             MeetingLocationId = expense.LocationId.GetValueOrDefault(),
                             MeetingNumIntParticipants = expense.MeetingNumIntParticipants,
                             MeetingNumExtParticipants = expense.MeetingNumExtParticipants,
                             MeetingDuration = expense.MeetingDuration,

                             //proc fields
                             ProcType = expense.ProcType == null ? "" : expense.ProcType.ProcTypeName,
                             ProcTypeId = expense.ProcTypeId.GetValueOrDefault(),
                             ProcContractType = expense.ProcConType == null ? "" : expense.ProcConType.ProcConTypeName,
                             ProcContractId = expense.ProcConTypeId.GetValueOrDefault(),
                             ProcOfficerName = expense.UserIdProcurementOfficerNavigation == null ? "" : expense.UserIdProcurementOfficerNavigation.UserFirstName + " " + expense.UserIdProcurementOfficerNavigation.UserLastName,
                             ProcComment = expense.ProcComment,

                             //Check if it is working
                             //HistoryAmount = PlatoHistoryController.GetHistoryList(expense.ExpenseHistory.ToList(), HistoryElement.Amount),
                             //HistoryBudgetLine = PlatoHistoryController.GetHistoryList(expense.ExpenseHistory.ToList(), HistoryElement.BudgetLine),
                             //HistoryName = PlatoHistoryController.GetHistoryList(expense.ExpenseHistory.ToList(), HistoryElement.Name),

                         }).Where(p => AddStaffPicture(p)).ToList();

            return query;
        }

        private List<ExpenseStaffTransfer> GetExpenseStaffList(long expenseId)
        {
            ExpenseStaffController expenseStaffController = new ExpenseStaffController(misContext, null);
            return expenseStaffController.GetExpenseStaffList(expenseId);
        }

        //[HttpGet]
        //[Route("GetExpense/{expenseId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        //public ExpenseTransfer GetExpense(long expenseId)
        //{
        //    var query = (from expense in misContext.Expense.AsNoTracking()
        //                .Include(p=>p.ExpenseStaff).ThenInclude(p=>p.UserApplication)
        //                .Where(p => p.ExpenseId == expenseId)
        //                 select new ExpenseTransfer
        //                 {
        //                     ActivityId = expense.ActivityId,
        //                     ExpenseId = expense.ExpenseId,
        //                     ExpenseTypeName = expense.ExpenseType == null ? "" : expense.ExpenseType.ExpenseTypeName,
        //                     ExpenseName = expense.ExpenseName,
        //                     BudgetLineName = expense.BudgetLine.BudgetLineName,
        //                     StartDate = expense.ExpenseStartDate,
        //                     EndDate = expense.ExpenseEndDate,
        //                     OrganiserPicture = SetUserPicture(expense.UserIdOwnerNavigation),
        //                     ExpenseStaffList = GetStaffList(expense.ExpenseStaff),
        //                 });

        //    return query.FirstOrDefault();
        //}

        //private List<ExpenseStaffTransfer> GetStaffList(ICollection<ExpenseStaff> expenseStaff)
        //{
        //    var query = from staff in expenseStaff
        //                select new ExpenseStaffTransfer
        //                {
        //                    StaffName = staff.UserApplication.UserFirstName + " " + staff.UserApplication.UserLastName,
        //                    PlanDay = staff.ExpenseStaffPlanDay,
        //                    PlanFte = staff.ExpenseStaffPlanFte,
        //                    StaffPicture = SetUserPicture(staff.UserApplication)
        //                };

        //    return query.ToList();
        //}



        #region helper

        private string SetUserPicture(UserApplication owner)
        {
            if (owner == null)
                return Convert.ToBase64String(Helper.ImageToByte(defaultUserPictureUrl));

            if (owner.UserPicture == null)
                return Convert.ToBase64String(Helper.ImageToByte(defaultUserPictureUrl));

            return Convert.ToBase64String(owner.UserPicture);
        }

        private byte[] SetUserPicture(Expense expense)
        {
            if (expense.UserIdOwnerNavigation == null) return Helper.ImageToByte(defaultUserPictureUrl);
            if (expense.UserIdOwnerNavigation.UserPicture == null) return Helper.ImageToByte(defaultUserPictureUrl);
            return expense.UserIdOwnerNavigation.UserPicture;
        }

        /// <summary>
        /// Add for each expense the list of staff attached (name + picture)
        /// </summary>
        /// <param name="expenseTransfer"></param>
        /// <returns></returns>
        private bool AddStaffPicture(ExpenseTransfer expenseTransfer)
        {
            expenseTransfer.StaffList = new List<object>();

            foreach (var item in expenseTransfer.StaffIdList)
            {
                byte[] staffPicture = this.userApplicationList.Where(p => p.UserId == item).Select(p => p.UserPicture).FirstOrDefault();
                string staffName = this.userApplicationList.Where(p => p.UserId == item).Select(p => p.UserFirstName + " " + p.UserLastName).FirstOrDefault();
                expenseTransfer.StaffList.Add(new staff { StaffPicture = staffPicture, StaffName = staffName });
            }
            return true;
        }

        private class staff
        {
            public byte[] StaffPicture { get; set; }
            public string StaffName { get; set; }
        }

        #endregion
    }
}
