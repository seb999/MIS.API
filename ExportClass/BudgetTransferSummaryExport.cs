using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.ExportClass
{
    public class BudgetTransferSummaryExport
    {
        public long ExpenseId { get; internal set; }
        public string ExpenseName { get; internal set; }
        public decimal? InitialAmount { get; internal set; }
        public decimal? CurrentAmount { get; internal set; }
        public long PetId { get; internal set; }
        public decimal? TransferAmount { get; internal set; }
        public string Source { get; internal set; }
        public string Target { get; internal set; }
    }
}
