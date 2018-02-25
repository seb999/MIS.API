using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class BudgetThreeBucket
    {
        public long Btbid { get; set; }
        public long? UnitId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Unit Unit { get; set; }
    }
}
