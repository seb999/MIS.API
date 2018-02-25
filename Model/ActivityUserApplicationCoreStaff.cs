using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityUserApplicationCoreStaff
    {
        public long AuacoreId { get; set; }
        public long? ActivityId { get; set; }
        public long? UserId { get; set; }
        public decimal? AuacoreFte { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public UserApplication User { get; set; }
    }
}
