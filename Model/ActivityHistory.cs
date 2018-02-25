using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityHistory
    {
        public long ActHistoryId { get; set; }
        public long? ActivityId { get; set; }
        public long? UserId { get; set; }
        public DateTime? ActHistoryDate { get; set; }
        public string ActHistoryElement { get; set; }
        public string ActiHistoryPreviousValue { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public string ActiHistoryNewValue { get; set; }

        public Activity Activity { get; set; }
        public UserApplication User { get; set; }
    }
}
