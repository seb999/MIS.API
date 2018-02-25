using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcessProject
    {
        public ProcessProject()
        {
            Expense = new HashSet<Expense>();
            ProcessProjectSub = new HashSet<ProcessProjectSub>();
        }

        public long ProcessProjectId { get; set; }
        public string ProcessProjectName { get; set; }
        public string ProcessProjectDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<ProcessProjectSub> ProcessProjectSub { get; set; }
    }
}
