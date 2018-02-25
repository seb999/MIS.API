using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class MeetingBudgetAbac
    {
        public long MeetingBudgetAbacId { get; set; }
        public long? BudgetLineId { get; set; }
        public long? AwpId { get; set; }
        public string AbacId { get; set; }
        public string MeetingBudgetAbacName { get; set; }
        public string MeetingBudgetAbacDescription { get; set; }
        public decimal? MeetingBudgetAbacCommitted { get; set; }
        public decimal? MeetingBudgetAbacPaid { get; set; }
        public string MeetingBudgetAbacType { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public BudgetLine BudgetLine { get; set; }
    }
}
