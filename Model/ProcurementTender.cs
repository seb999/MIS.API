using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementTender
    {
        public long ProcTenderId { get; set; }
        public long? ProcId { get; set; }
        public long? LocationId { get; set; }
        public string ProcTenderName { get; set; }
        public string ProcTenderDescription { get; set; }
        public string ProcTenderAdress { get; set; }
        public string ProcTenderEmail { get; set; }
        public string ProcTenderPhone { get; set; }
        public string ProcTenderEntity { get; set; }
        public string ProcTenderContactPerson { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Location Location { get; set; }
        public Procurement Proc { get; set; }
    }
}
