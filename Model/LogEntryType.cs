using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class LogEntryType
    {
        public LogEntryType()
        {
            Log = new HashSet<Log>();
        }

        public long LogEntryTypeId { get; set; }
        public string LogEntryTypeCode { get; set; }
        public string LogEntryTypeName { get; set; }
        public string LogEntryTypeDescription { get; set; }
        public bool? LogEntryIsError { get; set; }
        public bool? LogEntryIsWarn { get; set; }
        public bool? LogEntryIsApp { get; set; }
        public bool? LogEntryIsNote { get; set; }
        public bool? LogEntryIsMisc { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Log> Log { get; set; }
    }
}
