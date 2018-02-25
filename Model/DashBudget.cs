using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashBudget
    {
        public long DashBudgetId { get; set; }
        public long? Awpid { get; set; }
        public long? UnitId { get; set; }
        public long? Dpid { get; set; }
        public string DashBudgetOfficialBudgetItem { get; set; }
        public string DashBudgetOfficialBudgetItemDesc { get; set; }
        public string DashBudgetFundSource { get; set; }
        public string DashBudgetLocalPosition { get; set; }
        public decimal? DashBudgetAllocated { get; set; }
        public decimal? DashBudgetCommitments { get; set; }
        public decimal? DashBudgetPayments { get; set; }
        public string DashBudgetDpUnit { get; set; }
        public string DashBudgetTitle { get; set; }
        public DateTime? DashBudgetDateExport { get; set; }
        public int? DashBudgetMonthExport { get; set; }
        public bool? DashBudgetVisible { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public Dsp Dp { get; set; }
        public Unit Unit { get; set; }
    }
}
