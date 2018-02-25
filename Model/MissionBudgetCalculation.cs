using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class MissionBudgetCalculation
    {
        public long MissionBudgetId { get; set; }
        public long? LocationId { get; set; }
        public int? MissionBudgetDuration { get; set; }
        public decimal? MissionBudgetCostPerDay { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Location Location { get; set; }
    }
}
