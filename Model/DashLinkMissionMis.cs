using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashLinkMissionMis
    {
        public int DashLinkMissionMisid { get; set; }
        public string DashLinkMissionMisdpcore { get; set; }
        public string DashLinkMissionMisdp { get; set; }
        public string DashLinkMissionMisunit { get; set; }
        public long? Dpid { get; set; }
        public long? UnitId { get; set; }

        public Dsp Dp { get; set; }
        public Unit Unit { get; set; }
    }
}
