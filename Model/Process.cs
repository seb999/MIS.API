using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Process
    {
        public long ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
    }
}
