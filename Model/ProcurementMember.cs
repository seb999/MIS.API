using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementMember
    {
        public long ProcMemberId { get; set; }
        public long? ProcId { get; set; }
        public long? UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Procurement Proc { get; set; }
        public UserApplication User { get; set; }
    }
}
