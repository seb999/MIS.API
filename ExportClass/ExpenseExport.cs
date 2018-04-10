using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.ExportClass
{
    public class ExpenseExport
    {
        public long ExpenseId { get; internal set; }
        public string ExpenseName { get; internal set; }
        public string ExpenseTypeName { get; internal set; }
        public string BudgetLineName { get; internal set; }
        public decimal? InitialAmount { get; internal set; }
        public decimal? Amount { get; internal set; }
        public DateTime? StartDate { get; internal set; }
        public DateTime? EndDate { get; internal set; }
        public decimal? AmountCommitted { get; internal set; }
        public decimal? AmountPaid { get; internal set; }
        public string Organiser { get; internal set; }
    }
}
