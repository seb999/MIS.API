using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class SpdKeyOutput : ILookupData
    {
        public SpdKeyOutput()
        {
            Expense = new HashSet<Expense>();
        }

        public long SpdKeyOutputId { get; set; }
        public long? Awpid { get; set; }
        public string SpdKeyOutputName { get; set; }
        public string SpdKeyOutputDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public ICollection<Expense> Expense { get; set; }
        #region lookkup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return SpdKeyOutputName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return SpdKeyOutputId; }
            set { Value = value; }
        }

        #endregion

    }
}
