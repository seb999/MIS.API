using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ExpensePlatoStatus : ILookupData
    {
        public ExpensePlatoStatus()
        {
            Expense = new HashSet<Expense>();
        }

        public long ExpensePlatoStatusId { get; set; }
        public string ExpensePlatoStatusName { get; set; }
        public string ExpensePlatoStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return ExpensePlatoStatusId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ExpensePlatoStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
