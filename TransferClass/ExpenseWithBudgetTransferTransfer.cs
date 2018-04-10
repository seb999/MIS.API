using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.TransferClass
{
    public class ExpenseWithBudgetTransferTransfer
    {
        public long ExpenseId { get; set; }
        public String ExpenseName { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public decimal? ExpenseInitialAmount { get; set; }
        public List<BudgetTransferTransfer> BudgetTransferList { get; set; }
    }
}