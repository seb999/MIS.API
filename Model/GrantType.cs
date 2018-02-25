using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class GrantType
    {
        public GrantType()
        {
            Expense = new HashSet<Expense>();
            GrantSubType = new HashSet<GrantSubType>();
        }

        public long GrantTypeId { get; set; }
        public string GrantTypeName { get; set; }
        public string GrantTypeDescription { get; set; }
        public string GrantTitle { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<GrantSubType> GrantSubType { get; set; }
    }
}
