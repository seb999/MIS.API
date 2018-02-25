using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseFunctionParticipant
    {
        public long ExpenseFunctionParticipantId { get; set; }
        public long? ExpenseId { get; set; }
        public long? FunctionParticipantId { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Expense Expense { get; set; }
        public FunctionParticipant FunctionParticipant { get; set; }
    }
}
