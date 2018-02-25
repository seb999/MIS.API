using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementCorrigendum
    {
        public long ProcCorrigendumId { get; set; }
        public long? ProcId { get; set; }
        public DateTime? ProcCorrigendumArrival { get; set; }
        public DateTime? ProcCorrigendumPublicationOj { get; set; }
        public DateTime? ProcCorrigendumPublicationWeb { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Procurement Proc { get; set; }
    }
}
