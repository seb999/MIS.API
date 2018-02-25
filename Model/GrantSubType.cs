using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class GrantSubType
    {
        public GrantSubType()
        {
            Expense = new HashSet<Expense>();
        }

        public long GrantSubTypeId { get; set; }
        public long? GrantTypeId { get; set; }
        public string GrantSubTypeName { get; set; }
        public string GrantSubTypeDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public GrantType GrantType { get; set; }
        public ICollection<Expense> Expense { get; set; }
    }
}
