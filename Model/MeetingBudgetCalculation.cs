using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class MeetingBudgetCalculation
    {
        public long MeetingBudgetId { get; set; }
        public bool? MeetingBudgetIsInSweden { get; set; }
        public decimal? MeetingBudgetAmountInternal { get; set; }
        public decimal? MeetingBudgetAmountExternal { get; set; }
        public int? MeetingBudgetDuration { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
    }
}
