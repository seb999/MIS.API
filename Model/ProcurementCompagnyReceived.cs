using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementCompagnyReceived
    {
        public long ProcCompagnyReceivedId { get; set; }
        public long? ProcId { get; set; }
        public string ProcCompagnyReceivedName { get; set; }
        public string ProcCompagnyReceivedDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Procurement Proc { get; set; }
    }
}
