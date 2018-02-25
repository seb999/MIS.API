using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Task = new HashSet<Task>();
        }

        public long TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }
        public string TaskStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
