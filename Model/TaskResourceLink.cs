using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class TaskResourceLink
    {
        public long TaskResId { get; set; }
        public long? TaskId { get; set; }
        public long? UserId { get; set; }
        public int? TaskResPercentage { get; set; }
        public string TaskResNote { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Task Task { get; set; }
        public UserApplication User { get; set; }
    }
}
