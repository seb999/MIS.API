using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashVacRate
    {
        public long DashVacRateLogId { get; set; }
        public int? DashVacRateMonthId { get; set; }
        public long? Awpid { get; set; }
        public decimal? DashVacRateValue { get; set; }
        public decimal? DashVacRateExpectedVacancy { get; set; }
        public decimal? DashVacRateAverageToR { get; set; }
        public decimal? DashVacRateExpectedAverageToR { get; set; }
        public string DashVacRateComments { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
    }
}
