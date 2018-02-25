using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Meeting
    {
        public long MeetingId { get; set; }
        public long? ExpenseId { get; set; }
        public long? LocationId { get; set; }
        public long? UserIdOrganizer { get; set; }
        public string MeetingName { get; set; }
        public string MeetingCode { get; set; }
        public decimal? MeetingAmount { get; set; }
        public DateTime? MeetingStartDate { get; set; }
        public DateTime? MeetingEndDate { get; set; }
        public double? MeetingDuration { get; set; }
        public int? MeetingNumExtParticipants { get; set; }
        public int? MeetingNumIntParticipants { get; set; }
        public string LocationCity { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Expense Expense { get; set; }
        public Location Location { get; set; }
        public UserApplication UserIdOrganizerNavigation { get; set; }
    }
}
