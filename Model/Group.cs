using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Group
    {
        public Group()
        {
            Target = new HashSet<Target>();
        }

        public long GroupId { get; set; }
        public long? SmaplanId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public StrategyMaplan Smaplan { get; set; }
        public ICollection<Target> Target { get; set; }
    }
}
