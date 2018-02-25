using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProjectManagementPlan
    {
        public ProjectManagementPlan()
        {
            InverseOriginalPmplan = new HashSet<ProjectManagementPlan>();
        }

        public long PmplanId { get; set; }
        public long? OriginalPmplanId { get; set; }
        public long? ApprovedByUserId { get; set; }
        public string Pmpbackground { get; set; }
        public string Pmpscope { get; set; }
        public string PmpchangeManagement { get; set; }
        public string PmpqualityManagement { get; set; }
        public string Pmpassumptions { get; set; }
        public string Pmpconstraints { get; set; }
        public string Pmpresults { get; set; }
        public string PmpmainLessonsLearnt { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ApprovalApplyDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public UserApplication ApprovedByUser { get; set; }
        public ProjectManagementPlan OriginalPmplan { get; set; }
        public ICollection<ProjectManagementPlan> InverseOriginalPmplan { get; set; }
    }
}
