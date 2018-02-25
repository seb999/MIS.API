using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class UserApplication : ILookupData
    {
        public UserApplication()
        {
            ActiivityPerformanceIndicator = new HashSet<ActiivityPerformanceIndicator>();
            ActivityHistory = new HashSet<ActivityHistory>();
            ActivityUserApplicationCoreStaff = new HashSet<ActivityUserApplicationCoreStaff>();
            ActivityUserIdActivityLeaderNavigation = new HashSet<Activity>();
            ActivityUserIdAuthOfficerNavigation = new HashSet<Activity>();
            ActivityUserIdResourceOfficerNavigation = new HashSet<Activity>();
            AllegroImport = new HashSet<AllegroImport>();
            ExpenseDeliverable = new HashSet<ExpenseDeliverable>();
            ExpenseHistory = new HashSet<ExpenseHistory>();
            ExpenseStaffHistory = new HashSet<ExpenseStaffHistory>();
            ExpenseStaffUser = new HashSet<ExpenseStaff>();
            ExpenseStaffUserIdHoDpvalidationNavigation = new HashSet<ExpenseStaff>();
            ExpenseStaffUserIdHoUvalidationNavigation = new HashSet<ExpenseStaff>();
            ExpenseUserIdAuthOfficerNavigation = new HashSet<Expense>();
            ExpenseUserIdFinancialAssistantNavigation = new HashSet<Expense>();
            ExpenseUserIdOwnerNavigation = new HashSet<Expense>();
            ExpenseUserIdProcurementOfficerNavigation = new HashSet<Expense>();
            Log = new HashSet<Log>();
            Meeting = new HashSet<Meeting>();
            Note = new HashSet<Note>();
            PendingExpenseTransferUserIdAutorizedNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferUserIdCommitedNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferUserIdDeletedNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferUserIdDirectorAutorizedNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferUserIdHeadOfUnitSourceAutorizedNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferUserIdHeadOfUnitTargetAutorizedNavigation = new HashSet<PendingExpenseTransfer>();
            PendingExpenseTransferUserIdRejectedNavigation = new HashSet<PendingExpenseTransfer>();
            Procurement2 = new HashSet<Procurement2>();
            ProcurementEvaluationCommittee = new HashSet<ProcurementEvaluationCommittee>();
            ProcurementMember = new HashSet<ProcurementMember>();
            ProcurementPackage = new HashSet<ProcurementPackage>();
            ProjectManagementPlan = new HashSet<ProjectManagementPlan>();
            Task = new HashSet<Task>();
            TaskResourceLink = new HashSet<TaskResourceLink>();
            UserExternalTool = new HashSet<UserExternalTool>();
        }

        public long UserId { get; set; }
        public long? UserRoleId { get; set; }
        public long? UnitId { get; set; }
        public long? Dspid { get; set; }
        public long? SectionId { get; set; }
        public string UserLoginName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneOffice { get; set; }
        public string UserPhoneMobile { get; set; }
        public bool? UserIsInactive { get; set; }
        public string UserOfficeNumber { get; set; }
        public byte[] UserPicture { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public int? OldUserId { get; set; }
        public long? UserGradeId { get; set; }
        public bool? UserIsPlatoMessageDisable { get; set; }
        public long? UserRoleIdBis { get; set; }

        public Dsp Dsp { get; set; }
        public Section Section { get; set; }
        public Unit Unit { get; set; }
        public UserGrade UserGrade { get; set; }
        public UserRole UserRole { get; set; }
        public UserRole UserRoleBis { get; set; }
        public ICollection<ActiivityPerformanceIndicator> ActiivityPerformanceIndicator { get; set; }
        public ICollection<ActivityHistory> ActivityHistory { get; set; }
        public ICollection<ActivityUserApplicationCoreStaff> ActivityUserApplicationCoreStaff { get; set; }
        public ICollection<Activity> ActivityUserIdActivityLeaderNavigation { get; set; }
        public ICollection<Activity> ActivityUserIdAuthOfficerNavigation { get; set; }
        public ICollection<Activity> ActivityUserIdResourceOfficerNavigation { get; set; }
        public ICollection<AllegroImport> AllegroImport { get; set; }
        public ICollection<ExpenseDeliverable> ExpenseDeliverable { get; set; }
        public ICollection<ExpenseHistory> ExpenseHistory { get; set; }
        public ICollection<ExpenseStaffHistory> ExpenseStaffHistory { get; set; }
        public ICollection<ExpenseStaff> ExpenseStaffUser { get; set; }
        public ICollection<ExpenseStaff> ExpenseStaffUserIdHoDpvalidationNavigation { get; set; }
        public ICollection<ExpenseStaff> ExpenseStaffUserIdHoUvalidationNavigation { get; set; }
        public ICollection<Expense> ExpenseUserIdAuthOfficerNavigation { get; set; }
        public ICollection<Expense> ExpenseUserIdFinancialAssistantNavigation { get; set; }
        public ICollection<Expense> ExpenseUserIdOwnerNavigation { get; set; }
        public ICollection<Expense> ExpenseUserIdProcurementOfficerNavigation { get; set; }
        public ICollection<Procurement2> Procurement2 { get; set; }
        public ICollection<Log> Log { get; set; }
        public ICollection<Meeting> Meeting { get; set; }
        public ICollection<Note> Note { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdAutorizedNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdCommitedNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdDeletedNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdDirectorAutorizedNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdHeadOfUnitSourceAutorizedNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdHeadOfUnitTargetAutorizedNavigation { get; set; }
        public ICollection<PendingExpenseTransfer> PendingExpenseTransferUserIdRejectedNavigation { get; set; }
        public ICollection<ProcurementEvaluationCommittee> ProcurementEvaluationCommittee { get; set; }
        public ICollection<ProcurementMember> ProcurementMember { get; set; }
        public ICollection<ProcurementPackage> ProcurementPackage { get; set; }
        public ICollection<ProjectManagementPlan> ProjectManagementPlan { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<TaskResourceLink> TaskResourceLink { get; set; }
        public ICollection<UserExternalTool> UserExternalTool { get; set; }

        //Not mapped-------------------------------
        [NotMapped]
        public string UserFullName
        {
            get { return UserFirstName + " " + UserLastName; }
            set { UserFullName = value; }
        }

        #region lookup

        [NotMapped]
        public long Value
        {
            get { return UserId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return UserFirstName + " " + UserLastName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive
        {
            get { return UserIsInactive.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        #endregion
    }
}
