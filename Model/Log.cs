using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Log
    {
        public long LogId { get; set; }
        public long? UserId { get; set; }
        public long? LogEntryTypeId { get; set; }
        public string LogNote { get; set; }
        public string LogNote2 { get; set; }
        public string LogDateTime { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public long? ParentLogId { get; set; }

        public LogEntryType LogEntryType { get; set; }
        public UserApplication User { get; set; }
    }
}
