using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementStatus : ILookupData
    {
        public ProcurementStatus()
        {
            Expense = new HashSet<Expense>();
        }

        public long ProcStatusId { get; set; }
        public string ProcStatusName { get; set; }
        public string ProcStatusDescription { get; set; }
        public int? ProcStatusOrder { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public bool? IgnoreRules { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<ProcurementStage> ProcurementStage { get; set; }
        public ICollection<ProcurementStatusWorkflow> ProcurementStatusWorkflow { get; set; }

        #region Lookup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return ProcStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return ProcStatusId; }
            set { Value = value; }
        }
        #endregion
    }
}
