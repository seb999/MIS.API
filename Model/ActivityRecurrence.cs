using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityRecurrence
    {
        public ActivityRecurrence()
        {
            Activity = new HashSet<Activity>();
        }

        public long ActivityReccurenceId { get; set; }
        public string ActivityReccurenceName { get; set; }
        public string ActivityReccurenceDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }
}
