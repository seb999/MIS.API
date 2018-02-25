using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseHistory
    {
        public long ExpenseHistoryId { get; set; }
        public long? UserId { get; set; }
        public long? ExpenseId { get; set; }
        public string ExpenseHistoryElement { get; set; }
        public string ExpenseHistoryNewValue { get; set; }
        public string ExpenseHistoryPreviousValue { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Expense Expense { get; set; }
        public UserApplication User { get; set; }
    }
}
