using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseStaff
    {
        public ExpenseStaff()
        {
            ExpenseStaffHistory = new HashSet<ExpenseStaffHistory>();
        }

        public long ExpenseStaffId { get; set; }
        public long? UserId { get; set; }
        public long? ExpenseId { get; set; }
        public decimal? ExpenseStaffPlanDay { get; set; }
        public decimal? ExpenseStaffPlanFte { get; set; }
        public decimal? ExpenseStaffActualDay { get; set; }
        public decimal? ExpenseStaffActualFte { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public decimal? ExpenseStaffRequestedDay { get; set; }
        public decimal? ExpenseStaffProposedDay { get; set; }
        public long? UserIdHoUvalidation { get; set; }
        public long? UserIdHoDpvalidation { get; set; }
        public DateTime? ExpenseStaffHoUValidationDate { get; set; }
        public DateTime? ExpenseStaffHoDpValidationDate { get; set; }
        public bool? ExpenseStaffIsHoUValidation { get; set; }
        public bool? ExpenseStaffIsHoDpValidation { get; set; }
        public bool? ExpenseStaffIsRejected { get; set; }
        public long? ExpenseStaffStatusId { get; set; }
        public string ExpenseStaffNote { get; set; }
        public bool? ExpenseStaffIsPriority { get; set; }
        public bool? ExpenseStaffIsRequested { get; set; }

        public Expense Expense { get; set; }
        public ExpenseStaffStatus ExpenseStaffStatus { get; set; }
        public UserApplication UserApplication { get; set; }
        public UserApplication UserIdHoDpValidationNavigation { get; set; }
        public UserApplication UserIdHoUValidationNavigation { get; set; }
        public ICollection<ExpenseStaffHistory> ExpenseStaffHistory { get; set; }
    }
}
