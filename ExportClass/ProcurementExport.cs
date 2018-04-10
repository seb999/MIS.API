using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.ExportClass
{
    public class ProcurementExport
    {
        public long ExpenseId { get; internal set; }
        public string BudgetLineCode { get; internal set; }
        public string ActivityCode { get; internal set; }
        public string ProcurementName { get; internal set; }
        public string ProjectManager { get; internal set; }
        public string AuthOfficer { get; internal set; }
        public string ProcOfficer { get; internal set; }
        public decimal? Amount { get; internal set; }
        public string ProcurementType { get; internal set; }
        public string ContractType { get; internal set; }
        public string Status { get; internal set; }
        public string Comment { get; internal set; }
        public DateTime NextDeadline { get; internal set; }
    }
}
