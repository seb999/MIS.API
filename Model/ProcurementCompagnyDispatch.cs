using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementCompagnyDispatch
    {
        public long ProcCompagnyDispatchId { get; set; }
        public long? ProcId { get; set; }
        public string ProcCompagnyDispatchName { get; set; }
        public string ProcCompagnyDispatchDescription { get; set; }
        public string ProcCompagnyDispatchAdress { get; set; }
        public string ProcCompagnyDispatchEmail { get; set; }
        public string ProcCompagnyDispatchContactPerson { get; set; }
        public string ProcCompagnyDispatchPhone { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Procurement Proc { get; set; }
    }
}
