using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Task
    {
        public Task()
        {
            InverseParentTask = new HashSet<Task>();
            TaskResourceLink = new HashSet<TaskResourceLink>();
        }

        public long TaskId { get; set; }
        public long? ActivityId { get; set; }
        public long? ExpenseId { get; set; }
        public long? TaskStatusId { get; set; }
        public long? UserIdAlocated { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskGroupName { get; set; }
        public bool? TaskIsMilestone { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public int? TaskOrder { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public long? ParentTaskId { get; set; }
        public long? TaskMonId { get; set; }
        public int? TaskLevel { get; set; }
        public string TaskNote { get; set; }
        public string TaskMonitorStatusNote { get; set; }
        public decimal? TaskAmount { get; set; }
        public int? TaskDuration { get; set; }

        public Activity Activity { get; set; }
        public Expense Expense { get; set; }
        public Task ParentTask { get; set; }
        public TaskMonitoringStatus TaskMon { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public UserApplication UserIdAlocatedNavigation { get; set; }
        public ICollection<Task> InverseParentTask { get; set; }
        public ICollection<TaskResourceLink> TaskResourceLink { get; set; }
    }
}
