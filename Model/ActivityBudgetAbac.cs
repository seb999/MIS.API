using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ActivityBudgetAbac
    {
        public long ActivityBudgetAbacId { get; set; }
        public long? ActivityId { get; set; }
        public long? BudgetLineId { get; set; }
        public string AbacId { get; set; }
        public string ActivityBudgetAbacComLocalKey { get; set; }
        public string ActivityBudgetAbacName { get; set; }
        public string ActivityBudgetAbacDescription { get; set; }
        public decimal? ActivityBudgetAbacCommitted { get; set; }
        public decimal? ActivityBudgetAbacPaid { get; set; }
        public string ActivityBudgetAbacType { get; set; }
        public bool? ActivityBudgetAbacIsDeleted { get; set; }
        public string ActivityBudgetAbacPayCentralKey { get; set; }
        public string ActivityBudgetAbacPayLocalKey { get; set; }
        public DateTime? ActivityBudgetAbacFirstComDate { get; set; }
        public DateTime? ActivityBudgetAbacLastPayDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Activity Activity { get; set; }
        public BudgetLine BudgetLine { get; set; }
    }
}
