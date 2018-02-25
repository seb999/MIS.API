using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class KeyObjective
    {
        public KeyObjective()
        {
            Activity = new HashSet<Activity>();
        }

        public long KeyObjId { get; set; }
        public string KeyObjName { get; set; }
        public string KeyObjDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }
}
