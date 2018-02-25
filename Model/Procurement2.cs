using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Procurement2
    {
        public long ProcId { get; set; }
        public long? ExpenseId { get; set; }
        public long? ProcParentId { get; set; }
        public DateTime? ProcDeadline { get; set; }
        public long? ProcTypeId { get; set; }
        public long? ProcConTypeId { get; set; }
        public long? ProcTimingStatusId { get; set; }
        public long? UserIdOwner { get; set; }
        public long? ProcFrameworkTypeId { get; set; }
        public long? ProcFinancingDecisionId { get; set; }
        public bool? ProcImplementationIsProc { get; set; }
        public bool? ProcImplementationIsGrant { get; set; }
        public bool? ProcTypeIsOpen { get; set; }
        public bool? ProcTypeIsNegociated { get; set; }
        public bool? ProcCpcgIsYes { get; set; }
        public bool? ProcCpcgIsNo { get; set; }
        public decimal? ProcContractedAmount { get; set; }
        public int? ProcNumberFwc { get; set; }
        public string ProcComment { get; set; } 
        public DateTime? ProcExpectedSubmissionDocCpcg { get; set; }
        public DateTime? ProcPlannedKickoffDate { get; set; }
        public DateTime? ProcCurrentKickoffDate { get; set; }
        public DateTime? ProcPlannedExpectedLaunch { get; set; }
        public DateTime? ProcCurrentExpectedLaunch { get; set; }
        public DateTime? ProcPlannedExpectedContractSignature { get; set; }
        public DateTime? ProcCurrentExpectedContractSignature { get; set; }
        public DateTime? ProcActualLaunchDate { get; set; }
        public DateTime? ProcSignatureContract { get; set; }

        public string DmsUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public Expense Expense { get; set; }
        public ProcurementContractType ProcConType { get; set; }
        public ProcurementFinancingDecision ProcFinancingDecision { get; set; }
        public ProcurementFrameworkType ProcFrameworkType { get; set; }
        public ProcurementTimingStatus ProcTimingStatus { get; set; }
        public ProcurementType ProcType { get; set; }
        public UserApplication UserIdOwnerNavigation { get; set; }

    }
}
