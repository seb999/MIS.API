using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Location : ILookupData
    {
        public Location()
        {
            ExpenseLocation = new HashSet<Expense>();
            ExpenseLocationActual = new HashSet<Expense>();
            Meeting = new HashSet<Meeting>();
            MissionBudgetCalculation = new HashSet<MissionBudgetCalculation>();
            ProcurementTender = new HashSet<ProcurementTender>();
        }

        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public bool? LocationIsDeleted { get; set; }
        public bool? LocationIsCountry { get; set; }
        public bool? LocationIsSweden { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> ExpenseLocation { get; set; }
        public ICollection<Expense> ExpenseLocationActual { get; set; }
        public ICollection<Meeting> Meeting { get; set; }
        public ICollection<MissionBudgetCalculation> MissionBudgetCalculation { get; set; }
        public ICollection<ProcurementTender> ProcurementTender { get; set; }

        #region lookup

        [NotMapped]
        public bool IsInactive
        {
            get { return LocationIsDeleted.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return LocationName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return LocationId; }
            set { Value = value; }
        }

        #endregion
    }
}
