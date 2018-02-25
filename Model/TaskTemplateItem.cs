using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class TaskTemplateItem
    {
        public TaskTemplateItem()
        {
            InverseParentTtitem = new HashSet<TaskTemplateItem>();
        }

        public long TtitemId { get; set; }
        public long? TaskTemplateId { get; set; }
        public long? ParentTtitemId { get; set; }
        public string TtitemName { get; set; }
        public int? TtitemLevel { get; set; }
        public int? TtitemDuration { get; set; }
        public decimal? TtitemBudget { get; set; }
        public int? TtitemSequence { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public TaskTemplateItem ParentTtitem { get; set; }
        public TaskTemplate TaskTemplate { get; set; }
        public ICollection<TaskTemplateItem> InverseParentTtitem { get; set; }
    }
}
