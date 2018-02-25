using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class StrategyMaplan
    {
        public StrategyMaplan()
        {
            Group = new HashSet<Group>();
        }

        public long SmaplanId { get; set; }
        public string SmaplanName { get; set; }
        public string SmaplanDescription { get; set; }
        public DateTime? SmaplanStartYear { get; set; }
        public DateTime? SmaplanEndYear { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Group> Group { get; set; }
    }
}
