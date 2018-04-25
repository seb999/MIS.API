using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECDC.MIS.API.ExportClass
{
    public class MeetingExport
    {
        public long Id { get; internal set; }
        public string Code { get; internal set; }
        public string ExpenseName { get; internal set; }
        public string BudgetLine { get; internal set; }
        public string Organiser { get; internal set; }
        public string Location { get; internal set; }
        public DateTime? StartDate { get; internal set; }
        public DateTime? EndDate { get; internal set; }
        public DateTime? InitiationDate { get; internal set; }
        public decimal? Amount { get; internal set; }
        public decimal? Committed { get; internal set; }
        public string Status { get; internal set; }
        public string ChangeRequested { get; internal set; }
        public string MeetingComment { get; internal set; }
    }
}
