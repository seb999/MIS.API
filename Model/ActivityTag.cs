using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityTag
    {
        public long ActivityTagId { get; set; }
        public long? ActivityId { get; set; }
        public long? TagId { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public Tag Tag { get; set; }
    }
}
