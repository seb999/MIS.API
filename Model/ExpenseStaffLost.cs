using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseStaffLost
    {
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
        public DateTime? ExpenseStaffHoUvalidationDate { get; set; }
        public DateTime? ExpenseStaffHoDpvalidationDate { get; set; }
        public bool? ExpenseStaffIsHoUvalidation { get; set; }
        public bool? ExpenseStaffIsHoDpvalidation { get; set; }
        public bool? ExpenseStaffIsRejected { get; set; }
        public long? ExpenseStaffStatusId { get; set; }
        public string ExpenseStaffNote { get; set; }
        public bool? ExpenseStaffIsPriority { get; set; }
        public bool? ExpenseStaffIsRequested { get; set; }
    }
}
