using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class PlatoStatus
    {
        public PlatoStatus()
        {
            Activity = new HashSet<Activity>();
        }

        public long PlatoStatusId { get; set; }
        public string PlatoStatusName { get; set; }
        public string PlatoStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }
}
