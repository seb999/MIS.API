using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.TransferClass
{
    public class ProcurementTransfer
    {
        public string ActivityCode { get; set; }
        public string AuthOfficer { get; set; }
        public decimal? Amount { get; set; }
        public string BudgetLineCode { get; set; }
        public string ContractType { get; set; }
        public string DPCode { get; set; }
        public long ExpenseId { get; set; }
        public long? ExpenseType { get; set; }
        public string ProcOfficer { get; set; }
        public string ProcurementName { get; set; }
        public string ProcurementType { get; set; }
        public string ProjectManager { get; set; }
        public string SectionCode { get; set; }
        public string Status { get; set; }
        public string StatusIcon { get; set; }
        public object StatusTooltip { get; set; }
        public int TotalBudget { get; set; }
        public string UnitCode { get; set; }
        public long ProcId { get; set; }
        public string ActivityName { get; set; }
        public decimal ProcContractedAmount { get; set; }
        public bool? ImplementationIsProc { get; set; }
        public bool? ImplementationIsGrant { get; set; }
        public long? ProcTypeId { get; set; }
        public long? ProcConTypeId { get; set; }
        public bool? TypeIsNegociated { get; set; }
        public bool? TypeIsOpen { get; set; }
        public string Comment { get; set; }
        public string ProcTypeName { get; set; }
        public string ProcConTypeName { get; set; }
        public long? ProcTimingStatusId { get; set; }
        public string ProcTimingStatusName { get; set; }
        public long? OwnerId { get; set; }
        public string OwnerName { get; set; }
        public long? AuthOfficerId { get; set; }
        public string FinanceAssistantName { get; set; }
        public long? ProcOfficerId { get; set; }
        public string AuthOfficerName { get; set; }
        public long? FinanceAssistantId { get; set; }
        public string ProcOfficerName { get; set; }
        public long? ProcStatusId { get; set; }
        public string ProcStatusName { get; set; }
        public DateTime? PlannedKickoffDate { get; set; }
        public DateTime? PlannedExpectedLaunch { get; set; }
        public DateTime? CurrentExpectedLaunch { get; set; }
        public DateTime? CurrentExpectedContractSignature { get; set; }
        public DateTime? PlannedExpectedContractSignature { get; set; }
        public DateTime? AwardNoticeDispatch { get; set; }
        public DateTime? ActualLaunchDate { get; set; }
        public DateTime? SignatureContract { get; set; }
        public DateTime? ExpectedSubmissionDocCpcg { get; set; }
        public int? NumberFwc { get; set; }
        public bool? CpcgIsYes { get; set; }
        public bool? CpcgIsNo { get; set; }
        public long? FrameworkTypeId { get; set; }
        public string FrameworkTypeName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? CurrentKickoffDate { get; set; }

        public string DmsUrl { get; set; }
        public long? ProcFinancingDecisionId { get; set; }
        public string ProcFinancingDecisionName { get; set; }
        public long? UnitId { get; set; }
        public long? DpId { get; set; }
        public long? SectionId { get; set; }

        // public List<ProcurementStageTransfer> ProcurementStages;
    }
}
