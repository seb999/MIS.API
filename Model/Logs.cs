using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Logs
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
        public string LogEvent { get; set; }
        public long? ParentLogId { get; set; }
        public long? UserId { get; set; }
    }
}
