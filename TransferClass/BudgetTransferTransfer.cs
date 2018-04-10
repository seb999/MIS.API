using System;
using ECDC.MIS.API.Misc;

namespace ECDC.MIS.API.TransferClass
{
    public class BudgetTransferTransfer
    {
        public long PetId { get; set; }
        public decimal? Amount { get; set; }
        public long? PetStatusId { get; set; }
        public bool? PetStatusIsPending { get; set; }
        public bool? PetStatusIsExecuted { get; set; }
        public bool? PetStatusIsRejected { get; set; }
        public string PetStatusName { get; set; }
        public string PetStatusIcon { get; set; }
        public string PetStatusTooltip { get; set; }
        public string RejectedFullName { get; set; }

        public string SourceActivityCode { get; set; }
        public long? SourceActivityId { get; set; }
        public string SourceBudgetLine { get; set; }
        public object SourceBudgetLineCode { get; set; }
        public string SourceActivityName { get; set; }
        public string SourceExpenseName { get; set; }
        public decimal? SourceAmount { get; set; }
        public string SourceMotivation { get; set; }
        public string SourceExpenseType { get; set; }
        public DateTime? SourceHoUAutorizedDate { get; set; }
        public bool? SourceIsHoUAutorized { get; set; }
        public bool? SourceIsHoURejected { get; set; }
        public DateTime? SourceHoURejectedDate { get; set; }
        public string SourceHoUFullNameAutorize { get; set; }
        public bool SourceIsTitle1 { get; set; }
        public bool SourceIsTitle2 { get; set; }

        public string TargetActivityCode { get; set; }
        public long? TargetActivityId { get; set; }
        public string TargetBudgetLine { get; set; }
        public string TargetBudgetLineCode { get; set; }
        public string TargetActivityName { get; set; }
        public string TargetExpenseName { get; set; }
        public decimal? TargetAmount { get; set; }
        public string TargetMotivation { get; set; }
        public string TargetExpenseType { get; set; }
        public bool? TargetIsHoUAutorized { get; set; }
        public DateTime? TargetHoUAutorizedDate { get; set; }
        public bool? TargetIsHoURejected { get; set; }
        public DateTime? TargetHoURejectedDate { get; set; }
        public string TargetHoUFullNameAutorize { get; set; }
        public bool TargetIsTitle1 { get; set; }
        public bool TargetIsTitle2 { get; set; }

        public bool? FinanceInitiatorRejected { get; internal set; }
        public DateTime? FinanceInitiatorRejectedDate { get; internal set; }
        public bool IsFinanceInitiatorNeeded { get; set; }
        public string FinanceInitiatorAutorizeFullName { get; internal set; }
        public DateTime? FinanceInitiatorAutorizeDate { get; internal set; }

        public bool? FinanceRejected { get; set; }
        public DateTime? FinanceRejectedDate { get; set; }
        public bool IsFinanceNeeded { get; set; }
        public string FinanceAutorizeFullName { get; set; }
        public DateTime? FinanceAutorizeDate { get; set; }

        public long? UserIdAdded { get; set; }
        public long SourceExpenseId { get; set; }
        public long TargetExpenseId { get; set; }
        public string UserModFullName { get; set; }
        public DateTime? DateMod { get; set; }
        public string PetType { get; set; }
        public long? SourceActivityUnitId { get; set; }
        public long? SourceActivityDpId { get; set; }
        public long? TargetActivityUnitId { get; set; }
        public long? TargetActivityDpId { get; set; }
        public string PetNote { get; set; }
        public long? SourceActivityAwpId { get; set; }
        public long? TargetActivityAwpId { get; set; }

        //Worflow boolean
        public bool WorkflowIsEditEnable { get; set; }
        public bool WorkflowIsApproveSourceEnable { get; set; }
        public bool WorkflowIsApprovalTargetEnable { get; set; }
        public bool WorkflowIsApprovalFinanceEnable { get; set; }
        public BudgetTransferValidationType ValidationType { get; set; }
        public string AbacReference { get; set; }
        public bool? FinanceInitiatorAutorized { get; set; }
        public bool? FinanceAutorized { get; set; }

        //For budget transfer summary in activityDetail
        public decimal? SourceInitialAmount { get; internal set; }
        public decimal? TargetInitialAmount { get; internal set; }
    }
}
