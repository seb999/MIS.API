using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.TransferClass
{
    public class MeetingTransfer
    {
        public decimal? Amount { get; set; }
        public string BudgetLineCode { get; set; }
        public decimal? AmountCommitted { get; set; }
        public DateTime? MeetingEndDate { get; set; }
        public long ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public string MeetingCode { get; set; }
        public string MeetingLocation { get; set; }
        public string StatusIcon { get; set; }
        public string Organiser { get; set; }
        public byte[] OrganiserPicture { get; set; }
        public DateTime? MeetingStartDate { get; set; }
        public string StatusTooltip { get; set; }
        public string StatusName { get; set; }
        public string UnitCode { get; set; }
        public string SectionCode { get; set; }
        public string DPCode { get; set; }
        public decimal? InitialAmount { get; set; }
        public string BudgetLineName { get; set; }
        public decimal? AmountRequested { get; set; }
        public long? StatusId { get; set; }
        public string ApprovalStatusName { get; set; }
        public string MeetingStartMonth { get; set; }
        public string MeetingEndMonth { get; set; }
        public long? BudgetLineId { get; set; }
        public long? OrganiserId { get; set; }
        public int? MeetingDuration { get; set; }
        public int? MeetingNumExtParticipants { get; set; }
        public int? MeetingNumIntParticipantsActual { get; set; }
        public int? MeetingNumIntParticipants { get; set; }
        public int? MeetingNumExtParticipantsActual { get; set; }
        public string MeetingComment { get; set; }
        public string Location { get; set; }
        public long? LocationId { get; set; }
        public string LocationCity { get; set; }
        public string MeetingOutsideSwedenNote { get; set; }
        public string OrganiserEmail { get; set; }
        public DateTime? MeetingInitiationDate { get; set; }
        public bool? MeetingShouldBeInitiated { get; set; }
        public bool IsOutsourced { get; set; }
        public bool IsDeclarationOfInterest { get; set; }
 
        public bool IsNonEUCountry { get; set; }
        public bool IsEndDatePending { get; set; }
        public bool IsStartDatePending { get; set; }
        public bool IsNumExtParticipantsPending { get; set; }
        public bool IsNumIntParticipantsPending { get; set; }
        public bool IsLocationPending { get; set; }
        public bool IsAmountPending { get; set; }
        public bool IsHoUApproval { get; set; }
        public bool IsNamePending { get; set; }
        public bool IsEditEnable { get; set; }
        public bool IsPartialEditEnable { get; set; }
        public bool IsApprovalEnable { get; set; }
        public long? UnitId { get; set; }
        public string ApprovalStatusDescription { get; set; }
        public List<long?> UserWithEditRight { get; set; }
        public string RequestedApproval { get; set; }
        public string ActivityCode { get; set; }
        public List<MeetingTransfer> SubMeetingList { get; set; }
        public int SubMeetingNumber { get; set; }
        public long MeetingId { get; set; }
    }
}
