using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseDeliverable
    {
        public long ExpDeliverableId { get; set; }
        public long? ExpenseId { get; set; }
        public long? DeliverableId { get; set; }
        public long? UserIdOwner { get; set; }
        public DateTime? ExpDeliverableEndDate { get; set; }
        public bool? IsExpDeliverableDone { get; set; }
        public string DeliverableSmap1 { get; set; }
        public string DeliverableSmap2 { get; set; }
        public string DeliverableSmap3 { get; set; }
        public string DeliverableSmap4 { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Deliverable Deliverable { get; set; }
        public Expense Expense { get; set; }
        public UserApplication UserIdOwnerNavigation { get; set; }
    }
}
