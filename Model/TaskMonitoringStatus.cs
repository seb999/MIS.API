using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class TaskMonitoringStatus
    {
        public TaskMonitoringStatus()
        {
            Task = new HashSet<Task>();
        }

        public long TaskMonId { get; set; }
        public string TaskMonCode { get; set; }
        public string TaskMonName { get; set; }
        public string TaskMonDescription { get; set; }
        public string TaskMonColor { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
