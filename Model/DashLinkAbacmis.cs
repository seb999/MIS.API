using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashLinkAbacmis
    {
        public string DashAbaclinkMisofficialBudgetItem { get; set; }
        public string DashAbaclinkMisfundSource { get; set; }
        public string DashAbaclinkMisofficialBudgetItemDesc { get; set; }
        public string DashAbaclinkMislocalPosition { get; set; }
        public string DashAbaclinkMisdsp { get; set; }
        public string DashAbaclinkMisunit { get; set; }
        public string DashAbaclinkMisunitBo { get; set; }
        public long? UnitId { get; set; }
        public long? Dspid { get; set; }

        public Dsp Dsp { get; set; }
        public Unit Unit { get; set; }
    }
}
