using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseStaffStatus : ILookupData
    {
        public ExpenseStaffStatus()
        {
            ExpenseStaff = new HashSet<ExpenseStaff>();
        }

        public long ExpenseStaffStatusId { get; set; }
        public string ExpenseStaffStatusName { get; set; }
        public string ExpenseStaffStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<ExpenseStaff> ExpenseStaff { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return ExpenseStaffStatusId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ExpenseStaffStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
