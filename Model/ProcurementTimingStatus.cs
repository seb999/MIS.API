using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementTimingStatus : ILookupData
    {
        public ProcurementTimingStatus()
        {
            Expense = new HashSet<Expense>();
            Procurement2 = new HashSet<Procurement2>();
        }

        public long ProcTimingStatusId { get; set; }
        public string ProcTimingStatusName { get; set; }
        public string ProcTimingStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<Procurement2> Procurement2 { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return ProcTimingStatusId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ProcTimingStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
