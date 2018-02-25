using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcessProjectSub
    {
        public ProcessProjectSub()
        {
            Expense = new HashSet<Expense>();
        }

        public long ProcessProjectSubId { get; set; }
        public long? ProcessProjectId { get; set; }
        public string ProcessProjectSubName { get; set; }
        public string ProcessProjectSubDescription { get; set; }
        public long? Awpid { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public ProcessProject ProcessProject { get; set; }
        public ICollection<Expense> Expense { get; set; }
    }
}
