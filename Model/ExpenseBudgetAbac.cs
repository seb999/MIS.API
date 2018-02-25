using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseBudgetAbac
    {
        public long ExpenseBudgetAbacId { get; set; }
        public long? ExpenseId { get; set; }
        public long? BudgetLineId { get; set; }
        public string AbacId { get; set; }
        public string ExpenseBudgetAbacComLocalKey { get; set; }
        public string ExpenseBudgetAbacName { get; set; }
        public string ExpenseBudgetAbacDescription { get; set; }
        public decimal? ExpenseBudgetAbacCommitted { get; set; }
        public decimal? ExpenseBudgetAbacPaid { get; set; }
        public string ExpenseBudgetAbacType { get; set; }
        public bool? ExpenseBudgetAbacIsDeleted { get; set; }
        public string ExpenseBudgetAbacPayCentralKey { get; set; }
        public string ExpenseBudgetAbacPayLocalKey { get; set; }
        public DateTime? ExpenseBudgetAbacFirstComDate { get; set; }
        public DateTime? ExpenseBudgetAbacLastPayDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public BudgetLine BudgetLine { get; set; }
        public Expense Expense { get; set; }
    }
}
