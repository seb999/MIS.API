using ECDC.MIS.API.Misc;
using System;

namespace ECDC.MIS.API.TransferClass
{
    public class ExpenseStaffTransfer
    {
        public long? ExpenseId { get; set; }
        public string ActivityName { get; set; }
        public string ExpenseName { get; set; }
        public string ExpenseTypeName { get; set; }
        public string UnitCode { get; set; }
        public string DPCode { get; set; }
        public string SectionCode { get; set; }
        public string StaffName { get; set; }
        public string StaffUnit { get; set; }
        public decimal? PlanDay { get; set; }
        public decimal? PlanFte { get; set; }
        public decimal? ActualDay { get; set; }
        public decimal? ActualFte { get; set; }
        public long ExpenseStaffId { get; set; }
        public DateTime? DateMod { get; set; }
        public string UserAddedFullName { get; set; }
        public string UserModFullName { get; set; }
        public long? UserAdded { get; set; }
        public long? UserMod { get; set; }
        public string ExpenseType { get; set; }
        public string StaffPicture { get; set; }
        public long AwpId { get; set; }
        public long StaffId { get; set; }
        public long? ActivityId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string StaffSection { get; set; }
        public bool WorkFlowIsButtonShow { get; set; }
        public string WorkFlowStatus { get; set; }
        public bool WorkFlowHoDPApproved { get; set; }
        public long? StatusId { get; set; }
        public bool ExpenseStaffIsHoDPValidation { get; set; }
        public long? DPId { get; set; }
        public string ActivityCode { get; set; }
        public bool? IsCoreActivity { get; set; }
        public decimal? RequestedDay { get; set; }
        public decimal RequestedFte { get; set; }
        public bool? IsPriority { get; set; }
        public decimal ProposedDay { get; set; }
        public string ActivityLeader { get; set; }
        public string UserNameHoUValidation { get; set; }
        public string UserNameHoDPValidation { get; set; }
        public DateTime? DateHoUValidation { get; set; }
        public DateTime? DateHoDPValidation { get; set; }
        public bool IsHoUValidate { get; set; }
        public bool IsHoDPValidate { get; set; }
        public bool IsRejected { get; set; }
        public LookupListItem Staff { get; set; }
        public bool CanRejectFte { get; set; }
        public bool CanApproveFte { get; set; }
        public bool CanResetFte { get; set; }
    }
}