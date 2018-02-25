using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementSubType
    {
        public ProcurementSubType()
        {
            Expense = new HashSet<Expense>();
        }

        public long ProcSubTypeId { get; set; }
        public long? ProcTypeId { get; set; }
        public string ProcSubTypeName { get; set; }
        public string ProcSubTypeDescription { get; set; }
        public bool? ProcSubTypeIsContract { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ProcurementType ProcType { get; set; }
        public ICollection<Expense> Expense { get; set; }
    }
}
