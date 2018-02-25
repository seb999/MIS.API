using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementType : ILookupData
    {
        public ProcurementType()
        {
            Expense = new HashSet<Expense>();
            ProcurementSubType = new HashSet<ProcurementSubType>();
        }

        public long ProcTypeId { get; set; }
        public string ProcTypeName { get; set; }
        public string ProcTypeDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<Procurement2> Procurement2 { get; set; }
        public ICollection<ProcurementSubType> ProcurementSubType { get; set; }

        public ICollection<ProcurementStatusWorkflow> ProcurementStatusWorkflow { get; set; }

        #region lookup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return ProcTypeName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return ProcTypeId; }
            set { Value = value; }
        }

        #endregion
    }
}
