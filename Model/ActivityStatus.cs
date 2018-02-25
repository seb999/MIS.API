using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityStatus : ILookupData
    {
        public ActivityStatus()
        {
            Activity = new HashSet<Activity>();
        }

        public long ActStatusId { get; set; }
        public string ActStatusName { get; set; }
        public string ActStatusDescription { get; set; }
        public bool? ActStatusIsCanceled { get; set; }
        public bool? ActStatusIsNotStarted { get; set; }
        public bool? ActStatusAchieved { get; set; }
        public bool? ActStatusIsPostponed { get; set; }
        public bool? ActStatusIsDelayed { get; set; }
        public bool? ActStatusIsOnSchedule { get; set; }
        public bool? ActStatusIsNotMonitored { get; set; }
        public string ActStatusColour { get; set; }
        public string ActStatusImgPath { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return ActStatusId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ActStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
