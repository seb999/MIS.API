using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECDC.MIS.API.Model
{
    public partial class PendingExpenseTransfer
    {

        public long PetId { get; set; }
        public long? PetStatusId { get; set; }
        public long? ExpenseIdSource { get; set; }
        public long? ExpenseIdTarget { get; set; }
        public bool? PetIsBudgetTitle1 { get; set; }
        public bool? PetIsBudgetTitle2 { get; set; }
        public bool? PetIsBudgetTitle3 { get; set; }
        public long? Btbid { get; set; }
        public decimal? PetAmount { get; set; }
        public long? UserIdHeadOfUnitSourceAutorized { get; set; }
        public long? UserIdHeadOfUnitTargetAutorized { get; set; }
        public long? UserIdAutorized { get; set; }
        public long? UserIdDirectorAutorized { get; set; }
        public long? UserIdCommited { get; set; }
        public long? UserIdRejected { get; set; }
        public long? UserIdDeleted { get; set; }
        public DateTime? PetDateHeadOfUnitSourceApproval { get; set; }
        public DateTime? PetDateHeadOfUnitTargetApproval { get; set; }
        public DateTime? PetDateApproval { get; set; }
        public DateTime? PetDateDirectorApproval { get; set; }
        public DateTime? PetDateCommitted { get; set; }
        public DateTime? PetDateDeleted { get; set; }
        public DateTime? PetDateHeadOfUnitSourceRejected { get; set; }
        public DateTime? PetDateHeadOfUnitTargetRejected { get; set; }
        public DateTime? PetDateFinanceRejected { get; set; }
        public DateTime? PetDateDirectorRejected { get; set; }
        public DateTime? PetDateExcRejected { get; set; }
        public string PetRejectionReason { get; set; }
        public bool? PetIsHeadOfUnitSourceRejected { get; set; }
        public bool? PetIsHeadOfUnitTargetRejected { get; set; }
        public bool? PetIsFinanceRejected { get; set; }
        public bool? PetIsDirectorRejected { get; set; }
        public bool? PetIsExcrejected { get; set; }
        public bool? PetIsDeleted { get; set; }
        public bool? PetIsHeadOfUnitSourceAutorized { get; set; }
        public bool? PetIsHeadOfUnitTargetAutorized { get; set; }
        public bool? PetIsAutorized { get; set; }
        public long? PetApprovalStatusId { get; set; }
        public bool? PetIsDirectorAutorized { get; set; }
        public bool? PetIsCommitted { get; set; }
        public bool? PetIsExecuted { get; set; }
        public string PetMotivation { get; set; }
        public string PetMotivationTarget { get; set; }
        public string PetTransactionNumber { get; set; }
        public bool? PetIsNotificationEnable { get; set; }
        public DateTime? PetDateLastNotification { get; set; }
        public string PetNote { get; set; }
        public string PetAbacReference { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public bool? PetIsFinanceInitAutorized { get; set; }
        public bool? PetIsFinanceInitRejected { get; set; }
        public DateTime? PetDateFinanceInitRejected { get; set; }

        public Expense ExpenseIdSourceNavigation { get; set; }
        public Expense ExpenseIdTargetNavigation { get; set; }
        //public PendingExpenseTransfer Pet { get; set; }
        public PendingTransferApprovalStatus PetApprovalStatus { get; set; }
        public PendingTransferStatus PetStatus { get; set; }
        public UserApplication UserIdAutorizedNavigation { get; set; }
        public UserApplication UserIdCommitedNavigation { get; set; }
        public UserApplication UserIdDeletedNavigation { get; set; }
        public UserApplication UserIdDirectorAutorizedNavigation { get; set; }
        public UserApplication UserIdHeadOfUnitSourceAutorizedNavigation { get; set; }
        public UserApplication UserIdHeadOfUnitTargetAutorizedNavigation { get; set; }
        public UserApplication UserIdRejectedNavigation { get; set; }
        //public PendingExpenseTransfer InversePet { get; set; }
    }
}
