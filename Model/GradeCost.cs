using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class GradeCost
    {
        public long GradeCostId { get; set; }
        public long? Awpid { get; set; }
        public long? UserGradeId { get; set; }
        public decimal? GradeCost1 { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public UserGrade UserGrade { get; set; }
    }
}
