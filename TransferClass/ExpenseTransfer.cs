using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.TransferClass
{
    public class ExpenseTransfer
    {
        public long? ActivityId { get; set; }
        public string ActivityCode{ get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountCommitted { get; set; }
        public long? BudgetLineId { get; set; }
        public string BudgetLineName { get; set; }
        public long ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public long ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
        public decimal? InitialAmount { get; set; }
        public List<long?> StaffIdList { get; set; }
        public List<object> StaffList { get; set; }
        public List<string> StaffNameList { get; set; }
        public List<byte[]> StaffPictureList { get; set; }       
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? AmountPaid { get; set; }
        public string Organiser { get; set; }
        public byte[] OrganiserPicture { get; set; }       
        public int? MeetingDuration { get; set; }
        public int? MeetingNumExtParticipants { get; set; }
        public int? MeetingNumIntParticipants { get; set; }
        public string MeetingLocationCity { get; set; }
        public string MeetingLocation { get; set; }
        public string AuthorisingOfficer { get; set; }
        public string ProcType { get; set; }
        public string ProcContractType { get; set; }
        public string ProcOfficerName { get; set; }

        public List<ExpenseStaffTransfer> ExpenseStaffList { get; set; }
        public List<ExpenseDeliverableTransfer> ExpenseDeliverableList { get; set; }
        public DateTime? DateAdded { get; set; }
        public decimal TotalFte { get; set; }
        public string PlatoStatus { get; set; }
        public long PlatoStatusId { get; set; }
        public long? OrganiserId { get; set; }
        public string ExpenseNote { get; set; }
        public long? RecurrenceId { get; set; }
        public long? CapacityLevelId { get; set; }
        public bool? IsPriority20 { get; set; }
        public bool? IsPriority80 { get; set; }
        public long MeetingLocationId { get; set; }
        public long ProcTypeId { get; set; }
        public long ProcContractId { get; set; }
        public decimal TotalRequestedDay { get; set; }
        public decimal TotalPlanDay { get; set; }
        public string UserMod { get; set; }
        public string UserAdded { get; set; }
        public long? SpdKeyOutputId { get; set; }
        public long? SpdObjectiveId { get; set; }
        public string ProcComment { get; set; }
        public decimal TotalRequestedFte { get;  set; }
        public long UnitId{ get;  set; }
        public long DpId{ get;  set; }
    }
}