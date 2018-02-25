using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class BudgetConstant
    {
        public long BudConId { get; set; }
        public long? Awpid { get; set; }
        public decimal? BudConTotalT1 { get; set; }
        public decimal? BudConTotalT2 { get; set; }
        public int? BudConTotalStaff { get; set; }
        public decimal? BudConT1factor { get; set; }
        public decimal? BudConTotalInitialT1 { get; set; }
        public decimal? BudConTotalInitialT2 { get; set; }
        public decimal? BudConTotalInitialT3 { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
    }
}
