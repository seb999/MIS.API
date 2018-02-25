using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class BudgetLine : ILookupData
    {
        public BudgetLine()
        {
            ActivityBudgetAbac = new HashSet<ActivityBudgetAbac>();
            Expense = new HashSet<Expense>();
            ExpenseBudgetAbac = new HashSet<ExpenseBudgetAbac>();
            MeetingBudgetAbac = new HashSet<MeetingBudgetAbac>();
        }

        public long BudgetLineId { get; set; }
        public long? Mawpid { get; set; }
        public string BudgetLineName { get; set; }
        public string BudgetLineDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public MultiAnnualWorkPlan Mawp { get; set; }
        public ICollection<ActivityBudgetAbac> ActivityBudgetAbac { get; set; }
        public ICollection<Expense> Expense { get; set; }
        public ICollection<ExpenseBudgetAbac> ExpenseBudgetAbac { get; set; }
        public ICollection<MeetingBudgetAbac> MeetingBudgetAbac { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return BudgetLineId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return BudgetLineName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
