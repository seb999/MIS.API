using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class MeetingApprovalStatus
    {
        public MeetingApprovalStatus()
        {
            Expense = new HashSet<Expense>();
        }

        public long MeetingApprovalStatusId { get; set; }
        public string MeetingApprovalStatusName { get; set; }
        public string MeetingApprovalStatusDescription { get; set; }
        public bool? MeetingApprovalStatusIsInitial { get; set; }
        public bool? MeetingApprovalStatusIsNotCritical { get; set; }
        public bool? MeetingApprovalStatusIsCritical { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
    }
}
