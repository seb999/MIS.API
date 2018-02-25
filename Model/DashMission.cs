using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashMission
    {
        public int DashMissionId { get; set; }
        public long? AwpId { get; set; }
        public long? Dpid { get; set; }
        public long? UnitId { get; set; }
        public int? DashMissionOrderNumber { get; set; }
        public string DashMissionFullName { get; set; }
        public string DashMissionDpCore { get; set; }
        public DateTime? DashMissionStartDate { get; set; }
        public decimal? DashMissionBudgetConsumed { get; set; }
        public DateTime? DashMissionDateExport { get; set; }
        public int? DashMissionMonthExport { get; set; }
        public bool? DashMissionVisible { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public Dsp Dp { get; set; }
        public Unit Unit { get; set; }
    }
}
