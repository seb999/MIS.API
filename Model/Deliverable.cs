using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Deliverable
    {
        public Deliverable()
        {
            ExpenseDeliverable = new HashSet<ExpenseDeliverable>();
        }

        public long DeliverableId { get; set; }
        public string DeliverableName { get; set; }
        public string DeliverableDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<ExpenseDeliverable> ExpenseDeliverable { get; set; }
    }
}
