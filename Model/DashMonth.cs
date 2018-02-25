using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashMonth
    {
        public int DashMonthId { get; set; }
        public string DashMonthName { get; set; }
        public int? DashMonthLastDay { get; set; }
        public string DashMonthShortName { get; set; }
    }
}
