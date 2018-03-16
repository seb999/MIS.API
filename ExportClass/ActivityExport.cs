using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.ExportClass
{
    public class ActivityExport
    {
        public long ActivityId { get; internal set; }
        public string ActivityCode { get; internal set; }
        public string ActivityName { get; internal set; }
        public string StrategyCode { get; internal set; }
        public string UnitCode { get; internal set; }
        public string DpCode { get; internal set; }
        public string SectionCode { get; internal set; }
        public string ActivityLeader { get; internal set; }
        public decimal? Amount { get; internal set; }
        public string StatusName { get; internal set; }
    }
}
