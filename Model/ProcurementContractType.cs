using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementContractType : ILookupData
    {
        public ProcurementContractType()
        {
            Expense = new HashSet<Expense>();
        }

        public long ProcConTypeId { get; set; }
        public string ProcConTypeName { get; set; }
        public string ProcConTypeDescription { get; set; }
        public bool? ProcConIsSubList { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<Procurement2> Procurement2 { get; set; }

        #region lookup

        [NotMapped]
        public bool IsInactive
        {
            get { return !ProcConIsSubList.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ProcConTypeName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return ProcConTypeId; }
            set { Value = value; }
        }

        #endregion
    }
}
