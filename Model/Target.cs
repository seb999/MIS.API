using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Target
    {
        public Target()
        {
            Strategy = new HashSet<Strategy>();
        }

        public long TargetId { get; set; }
        public string TargetCode { get; set; }
        public string TargetName { get; set; }
        public string TragetNameShort { get; set; }
        public string TargetDescription { get; set; }
        public long? GroupId { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Group Group { get; set; }
        public ICollection<Strategy> Strategy { get; set; }
    }
}
