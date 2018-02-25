using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class MultiAnnualWorkPlan
    {
        public MultiAnnualWorkPlan()
        {
            BudgetLine = new HashSet<BudgetLine>();
            Strategy = new HashSet<Strategy>();
        }

        public long Mawpid { get; set; }
        public DateTime? MawpstartYear { get; set; }
        public DateTime? MawpendYear { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<BudgetLine> BudgetLine { get; set; }
        public ICollection<Strategy> Strategy { get; set; }
    }
}
