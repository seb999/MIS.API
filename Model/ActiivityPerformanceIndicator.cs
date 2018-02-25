using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActiivityPerformanceIndicator
    {
        public long ActPerIndId { get; set; }
        public long? ActivityId { get; set; }
        public long? PerIndId { get; set; }
        public long? UserIdOwner { get; set; }
        public bool? IsActPerIndDone { get; set; }
        public DateTime? ActPerIndEndDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public PerformanceIndicator PerInd { get; set; }
        public UserApplication UserIdOwnerNavigation { get; set; }
    }
}
