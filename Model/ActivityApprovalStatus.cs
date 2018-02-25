using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityApprovalStatus
    {
        public ActivityApprovalStatus()
        {
            Activity = new HashSet<Activity>();
        }

        public long ActAppStatusId { get; set; }
        public string ActAppStatusName { get; set; }
        public string ActAppStatusDescription { get; set; }
        public int? ActAppStatusLevel { get; set; }
        public bool? ActAppStatusIsInDraft { get; set; }
        public bool? ActAppStatusIsDraft { get; set; }
        public bool? ActAppStatusIsHos { get; set; }
        public bool? ActAppStatusIsHou { get; set; }
        public bool? ActAppStatusIsExe { get; set; }
        public bool? ActAppStatusIsMb { get; set; }
        public string ActAppStatusImageLocation { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }
}
