using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class PerformanceIndicator
    {
        public PerformanceIndicator()
        {
            ActiivityPerformanceIndicator = new HashSet<ActiivityPerformanceIndicator>();
        }

        public long PerIndId { get; set; }
        public string PerIndName { get; set; }
        public string PerIndDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<ActiivityPerformanceIndicator> ActiivityPerformanceIndicator { get; set; }
    }
}
