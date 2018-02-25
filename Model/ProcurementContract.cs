using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementContract
    {
        public long ProcContractId { get; set; }
        public long? ProcId { get; set; }
        public string ProcTenderName { get; set; }
        public string ProcContractDescription { get; set; }
        public string ProcContractNumber { get; set; }
        public string ProcContractLot { get; set; }
        public DateTime? ProcContractSignature { get; set; }
        public DateTime? ProcContractArrival { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Procurement Proc { get; set; }
    }
}
