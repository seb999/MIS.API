using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseType : ILookupData
    {
        public ExpenseType()
        {
            Expense = new HashSet<Expense>();
        }

        public long ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
        public string ExpenseTypeDescription { get; set; }
        public bool? ExpenseIsDeleted { get; set; }
        public bool? ExpenseTypeIsProcurement { get; set; }
        public bool? ExpenseTypeIsMeeting { get; set; }
        public bool? ExpenseTypeIsGrant { get; set; }
        public bool? ExpenseTypeIsCountryMission { get; set; }
        public bool? ExpenseTypeIsMission { get; set; }
        public bool? ExpenseTypeIsGeneral { get; set; }
        public bool? ExpenseTypeIsPublication { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }

        #region lookkup

        [NotMapped]
        public bool IsInactive
        {
            get { return ExpenseIsDeleted.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ExpenseTypeName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return ExpenseTypeId; }
            set { Value = value; }
        }

        #endregion

    }
}
