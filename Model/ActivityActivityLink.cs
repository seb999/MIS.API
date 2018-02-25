using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityActivityLink
    {
        public long ActActId { get; set; }
        public long? ActivityId { get; set; }
        public long? ActivityIdLinked { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public Activity ActivityIdLinkedNavigation { get; set; }
    }
}
