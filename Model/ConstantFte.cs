using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ConstantFte
    {
        public long ConstantFteId { get; set; }
        public long? Awpid { get; set; }
        public string ConstantFteName { get; set; }
        public decimal? ConstantFteValue { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
    }
}
