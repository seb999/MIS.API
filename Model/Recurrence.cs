using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Recurrence : ILookupData
    {
        public Recurrence()
        {
            Expense = new HashSet<Expense>();
        }

        public long RecurrenceId { get; set; }
        public string RecurrenceName { get; set; }
        public string RecurrenceDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return RecurrenceId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return RecurrenceName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
