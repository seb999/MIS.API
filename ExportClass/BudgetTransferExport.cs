using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.ExportClass
{
    public class BudgetTransferExport
    {
        public long PetId { get; internal set; }
        public string SourceActivityCode { get; internal set; }
        public string SourceActivityName { get; internal set; }
        public string SourceExpenseName { get; internal set; }
        public string SourceBudgetLineCode { get; internal set; }
        public string SourceExpenseType { get; internal set; }
        public decimal? SourceAmount { get; internal set; }
        public string SourceMotivation { get; internal set; }
        public string TargetActivityCode { get; internal set; }
        public string TargetActivityName { get; internal set; }
        public string TargetExpenseName { get; internal set; }
        public string TargetBudgetLineCode { get; internal set; }
        public string TargetExpenseType { get; internal set; }
        public decimal? TargetAmount { get; internal set; }
        public string TargetMotivation { get; internal set; }
        public decimal? Amount { get; internal set; }
        public string PetStatusName { get; internal set; }
        
    }
}
