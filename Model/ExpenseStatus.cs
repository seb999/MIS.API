using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseStatus
    {
        public ExpenseStatus()
        {
            Expense = new HashSet<Expense>();
        }

        public long ExpenseStatusId { get; set; }
        public string ExpenseStatusName { get; set; }
        public string ExpenseStatusDescription { get; set; }
        public bool? ExpenseStatusIsDone { get; set; }
        public bool? ExpenseStatusIsPostponed { get; set; }
        public bool? ExpenseStatusIsCancelled { get; set; }
        public bool? ExpenseStatusIsCarryOver { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
    }
}
