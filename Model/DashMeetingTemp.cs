using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashMeetingTemp
    {
        public int DashMeetingId { get; set; }
        public long? Awpid { get; set; }
        public long? UnitId { get; set; }
        public long? Dpid { get; set; }
        public DateTime? DashMeetingLogDate { get; set; }
        public decimal? DashMeetingCommitments { get; set; }
        public decimal? DashMeetingAllocated { get; set; }
        public bool? DashMeetingVisible { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public Dsp Dp { get; set; }
        public Unit Unit { get; set; }
    }
}
