using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashTempDeliverables
    {
        public long Id { get; set; }
        public long? ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityCode { get; set; }
        public string Strategy { get; set; }
        public string UnitCode { get; set; }
        public string Dspcode { get; set; }
        public string SectionCode { get; set; }
        public long? UnitId { get; set; }
        public long? Dspid { get; set; }
        public long? SectionId { get; set; }
        public long? AwpId { get; set; }
        public string Leader { get; set; }
        public string ActivityStatus { get; set; }
        public string ActStatusName { get; set; }
        public int? DeriverablesNumber { get; set; }
        public int? DeliverableDone { get; set; }
        public string PerIndName { get; set; }
        public DateTime? EndDate { get; set; }
        public string MonthYear { get; set; }
        public bool? IsActPerIndDone { get; set; }
        public string Owner { get; set; }

        public Dsp Dsp { get; set; }
        public Unit Unit { get; set; }
    }
}
