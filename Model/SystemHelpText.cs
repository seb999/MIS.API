using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class SystemHelpText
    {
        public long HelpId { get; set; }
        public string HelpField { get; set; }
        public string HelpTitle { get; set; }
        public string HelpText { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
    }
}
