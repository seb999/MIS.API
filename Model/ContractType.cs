using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ContractType
    {
        public ContractType()
        {
            Expense = new HashSet<Expense>();
        }

        public long ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public string ContractTypeDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
    }
}
