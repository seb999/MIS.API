using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityDocument
    {
        public long DocLinkId { get; set; }
        public long? ActivityId { get; set; }
        public string DocLinkName { get; set; }
        public string DocLinkPath { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
    }
}
