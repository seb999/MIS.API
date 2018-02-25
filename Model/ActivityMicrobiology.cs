using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityMicrobiology
    {
        public long ActivityMicroId { get; set; }
        public long? ActivityId { get; set; }
        public long? MicroId { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public Microbiology Micro { get; set; }
    }
}
