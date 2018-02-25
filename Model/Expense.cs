using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Expense
    {
        public Expense()
        {
            AllegroImport = new HashSet<AllegroImport>();
            Dmsdocument = new HashSet<Dmsdocument>();
            ExpenseBudgetAbac = new HashSet<ExpenseBudgetAbac>();
            ExpenseDeliverable = new HashSet<ExpenseDeliverable>();
            ExpenseFunctionParticipant = new HashSet<ExpenseFunctionParticipant>();
            ExpenseHistory = new HashSet<ExpenseHistory>();
            ExpenseStaff = new HashSet<ExpenseStaff>();
            Meeting = new HashSet<Meeting>();
            PendingExpenseTransferExpenseIdSourceNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferExpenseIdTargetNavigation = new HashSet<PendingExpenseTransfer>();
            StorageDocument = new HashSet<StorageDocument>();
            Task = new HashSet<Task>();
        }

        public long ExpenseId { get; set; }
        public long? ActivityId { get; set; }
        public long? ExpenseTypeId { get; set; }
        public long? BudgetLineId { get; set; }
        public long? UserIdOwner { get; set; }
        public long? UserIdAuthOfficer { get; set; }
        public long? UserIdFinancialAssistant { get; set; }
        public long? ExpenseStatusId { get; set; }
        public long? ProcFrameworkTypeId { get; set; }
        public long? ProcessProjectId { get; set; }
        public long? ProcessProjectSubId { get; set; }
        public string ExpenseName { get; set; }
        public string ExpenseDescription { get; set; }
        public decimal? ExpenseAmount { get; set; }
        public decimal? ExpenseAmountRequest { get; set; }
        public decimal? ExpenseAmountPaid { get; set; }
        public decimal? ExpenseAmountPayable { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpenseStartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ExpenseEndDate { get; set; }
        public DateTime? ExpenseStartDateActual { get; set; }
        public DateTime? ExpenseEndDateActual { get; set; }
        public string ExpenseNote { get; set; }
        public int? MeetingNumExtParticipants { get; set; }
        public long? LocationId { get; set; }
        public string LocationCity { get; set; }
        public int? MeetingDuration { get; set; }
        public double? MeetingDurationActual { get; set; }
        public int? MeetingNumIntParticipants { get; set; }
        public int? MeetingNumExtParticipantsActual { get; set; }
        public int? MeetingNumIntParticipantsActual { get; set; }
        public string MeetingCode { get; set; }
        public string MeetingComment { get; set; }
        public long? GrantSubTypeId { get; set; }
        public long? GrandTypeId { get; set; }
        public long? ProcTypeId { get; set; }
        public long? ProcSubTypeId { get; set; }
        public long? ProcConTypeId { get; set; }
        public long? ProcId { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public long? OldExpenseId { get; set; }
        public long? LocationActualId { get; set; }
        public int? MeetingNumIntParticipantsRequested { get; set; }
        public int? MeetingNumExtParticipantsRequested { get; set; }
        public long? ProcStatusId { get; set; }
        public string ProcComment { get; set; }
        public long? ContractTypeId { get; set; }
        public decimal? ExpenseInitialAmount { get; set; }
        public long? MeetingStatusId { get; set; }
        public long? MeetingApprovalStatusId { get; set; }
        public string LocationCityActual { get; set; }
        public string MeetingOutsideSwedenNote { get; set; }
        public bool? MeetingIsNamePending { get; set; }
        public bool? MeetingIsLocationPending { get; set; }
        public bool? MeetingIsNumIntParticipantsPending { get; set; }
        public bool? MeetingIsNumExtParticipantsPending { get; set; }
        public bool? MeetingIsStartDatePending { get; set; }
        public bool? MeetingIsEndDatePending { get; set; }
        public bool? MeetingIsAmountPending { get; set; }
        public bool? MeetingIsHoUapproval { get; set; }
        public DateTime? MeetingDateApproval { get; set; }
        public DateTime? LastEmailNotification { get; set; }
        public bool? MeetingIsNonEnlargementCountries { get; set; }
        public bool? MeetingIsDeclarationInterest { get; set; }
        public bool? MeetingIsOutsourced { get; set; }
        public long? UserIdProcurementOfficer { get; set; }
        public long? ProcTimingStatusId { get; set; }
        public long? ExpensePlatoStatusId { get; set; }
        public long? RecurrenceId { get; set; }
        public long? CapacityLevelId { get; set; }
        public bool? ExpenseIsPriority80 { get; set; }
        public bool? ExpenseIsPriority20 { get; set; }
        public bool? ExpenseIsRequested { get; set; }
        public bool? ExpenseIsApproved { get; set; }
        public bool? ExpenseIsRejected { get; set; }
        public bool? ExpenseIsHoUApproved { get; set; }
        public long? UserHoUMod { get; set; }
        public bool? ExpenseIsProcOfficerValidate { get; set; }
        public long? SpdObjectiveId { get; set; }
        public long? SpdKeyOutputId { get; set; }

        public Activity Activity { get; set; }
        public BudgetLine BudgetLine { get; set; }
        public CapacityLevel CapacityLevel { get; set; }
        public ContractType ContractType { get; set; }
        public ExpensePlatoStatus ExpensePlatoStatus { get; set; }
        public ExpenseStatus ExpenseStatus { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public GrantType GrandType { get; set; }
        public GrantSubType GrantSubType { get; set; }
        public Location Location { get; set; }
        public Location LocationActual { get; set; }
        public MeetingApprovalStatus MeetingApprovalStatus { get; set; }
        public MeetingStatus MeetingStatus { get; set; }
        public Procurement Proc { get; set; }
        public ProcurementContractType ProcConType { get; set; }
        public ProcurementFrameworkType ProcFrameworkType { get; set; }
        public ProcurementStatus ProcStatus { get; set; }
        public ProcurementSubType ProcSubType { get; set; }
        public ProcurementTimingStatus ProcTimingStatus { get; set; }
        public ProcurementType ProcType { get; set; }
        public ProcessProject ProcessProject { get; set; }
        public ProcessProjectSub ProcessProjectSub { get; set; }
        public Recurrence Recurrence { get; set; }
        public SpdKeyOutput SpdKeyOutput { get; set; }
        public SpdObjective SpdObjective { get; set; }
        public UserApplication UserIdAuthOfficerNavigation { get; set; }
        public UserApplication UserIdFinancialAssistantNavigation { get; set; }
        public UserApplication UserIdOwnerNavigation { get; set; }
        public UserApplication UserIdProcurementOfficerNavigation { get; set; }
        public ICollection<AllegroImport> AllegroImport { get; set; }
        public ICollection<Dmsdocument> Dmsdocument { get; set; }
        public ICollection<ExpenseBudgetAbac> ExpenseBudgetAbac { get; set; }
        public ICollection<ExpenseDeliverable> ExpenseDeliverable { get; set; }
        public ICollection<ExpenseFunctionParticipant> ExpenseFunctionParticipant { get; set; }
        public ICollection<ExpenseHistory> ExpenseHistory { get; set; }
        public ICollection<ExpenseStaff> ExpenseStaff { get; set; }
        public ICollection<Meeting> Meeting { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferExpenseIdSourceNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferExpenseIdTargetNavigation { get; set; }
        public ICollection<StorageDocument> StorageDocument { get; set; }
        public ICollection<Task> Task { get; set; }

        public ICollection<Procurement2> Procurement2 { get; set; }
        public ICollection<ProcurementStage> ProcurementStage { get; set; }

        #region Not mapped

        [NotMapped]
        public string ActivityCode { get; set; }
        [NotMapped]
        public string MeetingStatusIcon { get; set; }
        [NotMapped]
        public int MeetingStatusValue { get; set; }
        [NotMapped]
        public string MeetingStatusTooltip { get; set; }
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal MeetingCommitted { get; set; }
        [NotMapped]
        public string ProcTimingStatusIcon { get; set; }
        [NotMapped]
        public int ProcTimingStatusValue { get; set; }
        [NotMapped]
        public string ProcTimingStatusTooltip { get; set; }
        [NotMapped]
        public bool AmountVisibility { get; set; }
        [NotMapped]
        public bool StartDateVisibility { get; set; }
        [NotMapped]
        public bool EndDateVisibility { get; set; }
        [NotMapped]
        public bool ProcFieldsVisibility { get; set; }
        [NotMapped]
        public bool MeetingFieldsVisibility { get; set; }
        [NotMapped]
        public bool MeetingMissionFieldsVisibility { get; set; }
        [NotMapped]
        public bool GrantFieldsVisibility { get; set; }
        [NotMapped]
        public bool BudgetlineVisibility { get; set; }
        [NotMapped]
        public bool BudgetOfficerFieldsVisibility { get; set; }
        [NotMapped]
        public string UserAddedFullName { get; set; }
        [NotMapped]
        public string UserModFullName { get; set; }
        [NotMapped]
        public string UserHoUModFullName { get; set; }



        #endregion
    }
}
