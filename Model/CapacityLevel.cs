using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class CapacityLevel : ILookupData
    {
        public CapacityLevel()
        {
            Expense = new HashSet<Expense>();
        }

        public long CapacityLevelId { get; set; }
        public string CapacityLevelName { get; set; }
        public string CapacityLevelDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return CapacityLevelId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return CapacityLevelName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
