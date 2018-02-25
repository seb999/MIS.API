using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECDC.MIS.API.Model
{
    public partial class MISContext : DbContext
    {
        public MISContext(DbContextOptions<MISContext> options) : base(options)
        {

        }

        public virtual DbSet<ActiivityPerformanceIndicator> ActiivityPerformanceIndicator { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityActivityLink> ActivityActivityLink { get; set; }
        public virtual DbSet<ActivityApprovalStatus> ActivityApprovalStatus { get; set; }
        public virtual DbSet<ActivityBudgetAbac> ActivityBudgetAbac { get; set; }
        public virtual DbSet<ActivityDocument> ActivityDocument { get; set; }
        public virtual DbSet<ActivityHistory> ActivityHistory { get; set; }
        public virtual DbSet<ActivityMicrobiology> ActivityMicrobiology { get; set; }
        public virtual DbSet<ActivityRecurrence> ActivityRecurrence { get; set; }
        public virtual DbSet<ActivityStatus> ActivityStatus { get; set; }
        public virtual DbSet<ActivityTag> ActivityTag { get; set; }
        public virtual DbSet<ActivityUserApplicationCoreStaff> ActivityUserApplicationCoreStaff { get; set; }
        public virtual DbSet<AllegroImport> AllegroImport { get; set; }
        public virtual DbSet<AnnualWorkPlan> AnnualWorkPlan { get; set; }
        public virtual DbSet<BudgetConstant> BudgetConstant { get; set; }
        public virtual DbSet<BudgetLine> BudgetLine { get; set; }
        public virtual DbSet<BudgetThreeBucket> BudgetThreeBucket { get; set; }
        public virtual DbSet<CapacityLevel> CapacityLevel { get; set; }
        public virtual DbSet<ConstantFte> ConstantFte { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<DashBudget> DashBudget { get; set; }
        public virtual DbSet<DashExternalPath> DashExternalPath { get; set; }
        public virtual DbSet<DashLinkAbacmis> DashLinkAbacmis { get; set; }
        public virtual DbSet<DashLinkMissionMis> DashLinkMissionMis { get; set; }
        public virtual DbSet<DashMeeting> DashMeeting { get; set; }
        public virtual DbSet<DashMeetingTemp> DashMeetingTemp { get; set; }
        public virtual DbSet<DashMission> DashMission { get; set; }
        public virtual DbSet<DashMonth> DashMonth { get; set; }
        public virtual DbSet<DashTempDeliverables> DashTempDeliverables { get; set; }
        public virtual DbSet<DashVacRate> DashVacRate { get; set; }
        public virtual DbSet<Deliverable> Deliverable { get; set; }
        public virtual DbSet<Dmsdocument> Dmsdocument { get; set; }
        public virtual DbSet<Dsp> Dsp { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<ExpenseBudgetAbac> ExpenseBudgetAbac { get; set; }
        public virtual DbSet<ExpenseDeliverable> ExpenseDeliverable { get; set; }
        public virtual DbSet<ExpenseFunctionParticipant> ExpenseFunctionParticipant { get; set; }
        public virtual DbSet<ExpenseHistory> ExpenseHistory { get; set; }
        public virtual DbSet<ExpensePlatoStatus> ExpensePlatoStatus { get; set; }
        public virtual DbSet<ExpenseStaff> ExpenseStaff { get; set; }
        public virtual DbSet<ExpenseStaffHistory> ExpenseStaffHistory { get; set; }
        public virtual DbSet<ExpenseStaffLost> ExpenseStaffLost { get; set; }
        public virtual DbSet<ExpenseStaffStatus> ExpenseStaffStatus { get; set; }
        public virtual DbSet<ExpenseStatus> ExpenseStatus { get; set; }
        public virtual DbSet<ExpenseType> ExpenseType { get; set; }
        public virtual DbSet<ExternalToolsRole> ExternalToolsRole { get; set; }
        public virtual DbSet<FunctionParticipant> FunctionParticipant { get; set; }
        public virtual DbSet<GlobalSetting> GlobalSetting { get; set; }
        public virtual DbSet<GradeCost> GradeCost { get; set; }
        public virtual DbSet<GrantSubType> GrantSubType { get; set; }
        public virtual DbSet<GrantType> GrantType { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupActivity> GroupActivity { get; set; }
        public virtual DbSet<KeyObjective> KeyObjective { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogEntryType> LogEntryType { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<MeetingApprovalStatus> MeetingApprovalStatus { get; set; }
        public virtual DbSet<MeetingBudgetAbac> MeetingBudgetAbac { get; set; }
        public virtual DbSet<MeetingBudgetCalculation> MeetingBudgetCalculation { get; set; }
        public virtual DbSet<MeetingStatus> MeetingStatus { get; set; }
        public virtual DbSet<Microbiology> Microbiology { get; set; }
        public virtual DbSet<MissionBudgetCalculation> MissionBudgetCalculation { get; set; }
        public virtual DbSet<MultiAnnualWorkPlan> MultiAnnualWorkPlan { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<PendingExpenseTransfer> PendingExpenseTransfer { get; set; }
        public virtual DbSet<PendingTransferApprovalStatus> PendingTransferApprovalStatus { get; set; }
        public virtual DbSet<PendingTransferStatus> PendingTransferStatus { get; set; }
        public virtual DbSet<PerformanceIndicator> PerformanceIndicator { get; set; }
        public virtual DbSet<PlatoStatus> PlatoStatus { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessProject> ProcessProject { get; set; }
        public virtual DbSet<ProcessProjectSub> ProcessProjectSub { get; set; }
        public virtual DbSet<Procurement> Procurement { get; set; }
        public virtual DbSet<Procurement2> Procurement2 { get; set; }
        public virtual DbSet<ProcurementCompagnyDispatch> ProcurementCompagnyDispatch { get; set; }
        public virtual DbSet<ProcurementCompagnyReceived> ProcurementCompagnyReceived { get; set; }
        public virtual DbSet<ProcurementContract> ProcurementContract { get; set; }
        public virtual DbSet<ProcurementContractType> ProcurementContractType { get; set; }
        public virtual DbSet<ProcurementCorrigendum> ProcurementCorrigendum { get; set; }
        public virtual DbSet<ProcurementEvaluationCommittee> ProcurementEvaluationCommittee { get; set; }
        public virtual DbSet<ProcurementFinancingDecision> ProcurementFinancingDecision { get; set; }
        public virtual DbSet<ProcurementFrameworkType> ProcurementFrameworkType { get; set; }
        public virtual DbSet<ProcurementMember> ProcurementMember { get; set; }
        public virtual DbSet<ProcurementPackage> ProcurementPackage { get; set; }
        public virtual DbSet<ProcurementStage> ProcurementStage { get; set; }
        public virtual DbSet<ProcurementStatus> ProcurementStatus { get; set; }
        public virtual DbSet<ProcurementStatusWorkflow> ProcurementStatusWorkflow { get; set; }
        public virtual DbSet<ProcurementSubType> ProcurementSubType { get; set; }
        public virtual DbSet<ProcurementTender> ProcurementTender { get; set; }
        public virtual DbSet<ProcurementTimingStatus> ProcurementTimingStatus { get; set; }
        public virtual DbSet<ProcurementType> ProcurementType { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectManagementPlan> ProjectManagementPlan { get; set; }
        public virtual DbSet<Recurrence> Recurrence { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<SettingType> SettingType { get; set; }
        public virtual DbSet<SpdKeyOutput> SpdKeyOutput { get; set; }
        public virtual DbSet<SpdObjective> SpdObjective { get; set; }
        public virtual DbSet<StorageDocument> StorageDocument { get; set; }
        public virtual DbSet<StorageDocumentType> StorageDocumentType { get; set; }
        public virtual DbSet<Strategy> Strategy { get; set; }
        public virtual DbSet<StrategyMaplan> StrategyMaplan { get; set; }
        public virtual DbSet<SystemHelpText> SystemHelpText { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskMonitoringStatus> TaskMonitoringStatus { get; set; }
        public virtual DbSet<TaskResourceLink> TaskResourceLink { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<TaskTemplate> TaskTemplate { get; set; }
        public virtual DbSet<TaskTemplateItem> TaskTemplateItem { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UserApplication> UserApplication { get; set; }
        public virtual DbSet<UserExternalTool> UserExternalTool { get; set; }
        public virtual DbSet<UserGrade> UserGrade { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=NSQDMIS;Initial Catalog=ECDCNewMIS2017;User ID=MISV2AppUser;Password=Ethics01;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiivityPerformanceIndicator>(entity =>
            {
                entity.HasKey(e => e.ActPerIndId);

                entity.Property(e => e.ActPerIndEndDate).HasColumnType("datetime");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActiivityPerformanceIndicator)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActiivityPerformanceIndicator_Activity");

                entity.HasOne(d => d.PerInd)
                    .WithMany(p => p.ActiivityPerformanceIndicator)
                    .HasForeignKey(d => d.PerIndId)
                    .HasConstraintName("FK_ActiivityPerformanceIndicator_PerformanceIndicator");

                entity.HasOne(d => d.UserIdOwnerNavigation)
                    .WithMany(p => p.ActiivityPerformanceIndicator)
                    .HasForeignKey(d => d.UserIdOwner)
                    .HasConstraintName("FK_ActiivityPerformanceIndicator_UserApplication");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityAddedEuroValue).HasColumnType("text");

                entity.Property(e => e.ActivityBudgetCommitted).HasColumnType("money");

                entity.Property(e => e.ActivityBudgetNote).HasColumnType("text");

                entity.Property(e => e.ActivityBudgetPaid).HasColumnType("money");

                entity.Property(e => e.ActivityCodeSequence).HasMaxLength(10);

                entity.Property(e => e.ActivityDelayReason).HasColumnType("text");

                entity.Property(e => e.ActivityDescription).HasColumnType("text");

                entity.Property(e => e.ActivityEndDate).HasColumnType("date");

                entity.Property(e => e.ActivityFtecat1).HasColumnName("ActivityFTECat1");

                entity.Property(e => e.ActivityFtecat2).HasColumnName("ActivityFTECat2");

                entity.Property(e => e.ActivityFtecat3).HasColumnName("ActivityFTECat3");

                entity.Property(e => e.ActivityFtecat4).HasColumnName("ActivityFTECat4");

                entity.Property(e => e.ActivityFtecat5).HasColumnName("ActivityFTECat5");

                entity.Property(e => e.ActivityFtecat6).HasColumnName("ActivityFTECat6");

                entity.Property(e => e.ActivityFtecat7).HasColumnName("ActivityFTECat7");

                entity.Property(e => e.ActivityFtecat8).HasColumnName("ActivityFTECat8");

                entity.Property(e => e.ActivityHighHighNote).HasColumnType("text");

                entity.Property(e => e.ActivityHighLowNote).HasColumnType("text");

                entity.Property(e => e.ActivityHighMediumNote).HasColumnType("text");

                entity.Property(e => e.ActivityIdBf).HasColumnName("ActivityIdBF");

                entity.Property(e => e.ActivityImmediateAction).HasColumnType("text");

                entity.Property(e => e.ActivityIsIct).HasColumnName("ActivityIsICT");

                entity.Property(e => e.ActivityLowHighNote).HasColumnType("text");

                entity.Property(e => e.ActivityLowLowNote).HasColumnType("text");

                entity.Property(e => e.ActivityLowMediumNote).HasColumnType("text");

                entity.Property(e => e.ActivityMediumHighNote).HasColumnType("text");

                entity.Property(e => e.ActivityMediumLowNote).HasColumnType("text");

                entity.Property(e => e.ActivityMediumMediumNote).HasColumnType("text");

                entity.Property(e => e.ActivityMonitorNote).HasColumnType("text");

                entity.Property(e => e.ActivityName).HasMaxLength(500);

                entity.Property(e => e.ActivityNewTimeframeDate).HasColumnType("date");

                entity.Property(e => e.ActivityNoteNote).HasColumnType("text");

                entity.Property(e => e.ActivityProgress).HasColumnType("text");

                entity.Property(e => e.ActivityProposedMethod).HasColumnType("text");

                entity.Property(e => e.ActivityResourceNote).HasColumnType("text");

                entity.Property(e => e.ActivityRiskNote).HasColumnType("text");

                entity.Property(e => e.ActivityStartDate).HasColumnType("date");

                entity.Property(e => e.ActivitySummaryNote).HasColumnType("text");

                entity.Property(e => e.ActivityTaskNote).HasColumnType("text");

                entity.Property(e => e.AWPId).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.DSPId).HasColumnName("DSPId");

                entity.Property(e => e.OldDspid).HasColumnName("OldDSPId");

                entity.HasOne(d => d.ActAppStatus)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ActAppStatusId)
                    .HasConstraintName("FK_Activity_ActivityApprovalStatus");

                entity.HasOne(d => d.ActStatus)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ActStatusId)
                    .HasConstraintName("FK_Activity_ActivityStatus");

                entity.HasOne(d => d.ActivityIdBfNavigation)
                    .WithMany(p => p.InverseActivityIdBfNavigation)
                    .HasForeignKey(d => d.ActivityIdBf)
                    .HasConstraintName("FK_Activity_Activity");

                entity.HasOne(d => d.ActivityReccurence)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ActivityReccurenceId)
                    .HasConstraintName("FK_Activity_ActivityRecurrence");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.AWPId)
                    .HasConstraintName("FK_Activity_AnnualWorkPlan");

                entity.HasOne(d => d.Dsp)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.DSPId)
                    .HasConstraintName("FK_Activity_DSP");

                entity.HasOne(d => d.GroupActivity)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.GroupActivityId)
                    .HasConstraintName("FK_Activity_GroupActivity");

                entity.HasOne(d => d.KeyObj)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.KeyObjId)
                    .HasConstraintName("FK_Activity_KeyObjective");

                entity.HasOne(d => d.PlatoStatus)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.PlatoStatusId)
                    .HasConstraintName("FK_Activity_PlatoStatus");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK_Activity_Priority");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Activity_Project");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Activity_Section");

                entity.HasOne(d => d.Strategy)
                    .WithMany(p => p.ActivityStrategy)
                    .HasForeignKey(d => d.StrategyId)
                    .HasConstraintName("FK_Activity_Strategy");

                entity.HasOne(d => d.StrategyIdSecondaryNavigation)
                    .WithMany(p => p.ActivityStrategyIdSecondaryNavigation)
                    .HasForeignKey(d => d.StrategyIdSecondary)
                    .HasConstraintName("FK_Activity_Strategy1");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Activity_Unit");

                entity.HasOne(d => d.UserIdActivityLeaderNavigation)
                    .WithMany(p => p.ActivityUserIdActivityLeaderNavigation)
                    .HasForeignKey(d => d.UserIdActivityLeader)
                    .HasConstraintName("FK_Activity_UserApplication");

                entity.HasOne(d => d.UserIdAuthOfficerNavigation)
                    .WithMany(p => p.ActivityUserIdAuthOfficerNavigation)
                    .HasForeignKey(d => d.UserIdAuthOfficer)
                    .HasConstraintName("FK_Activity_UserApplicationAuthOfficer");

                entity.HasOne(d => d.UserIdResourceOfficerNavigation)
                    .WithMany(p => p.ActivityUserIdResourceOfficerNavigation)
                    .HasForeignKey(d => d.UserIdResourceOfficer)
                    .HasConstraintName("FK_Activity_UserApplicationResourceOfficer");
            });

            modelBuilder.Entity<ActivityActivityLink>(entity =>
            {
                entity.HasKey(e => e.ActActId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityActivityLinkActivity)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActivityActivityLink_Activity");

                entity.HasOne(d => d.ActivityIdLinkedNavigation)
                    .WithMany(p => p.ActivityActivityLinkActivityIdLinkedNavigation)
                    .HasForeignKey(d => d.ActivityIdLinked)
                    .HasConstraintName("FK_ActivityActivityLink_Activity1");
            });

            modelBuilder.Entity<ActivityApprovalStatus>(entity =>
            {
                entity.HasKey(e => e.ActAppStatusId);

                entity.Property(e => e.ActAppStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ActAppStatusImageLocation).HasMaxLength(100);

                entity.Property(e => e.ActAppStatusIsExe).HasColumnName("ActAppStatusIsEXE");

                entity.Property(e => e.ActAppStatusIsHos).HasColumnName("ActAppStatusIsHOS");

                entity.Property(e => e.ActAppStatusIsHou).HasColumnName("ActAppStatusIsHOU");

                entity.Property(e => e.ActAppStatusIsMb).HasColumnName("ActAppStatusIsMB");

                entity.Property(e => e.ActAppStatusName).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");
            });

            modelBuilder.Entity<ActivityBudgetAbac>(entity =>
            {
                entity.Property(e => e.AbacId).HasMaxLength(50);

                entity.Property(e => e.ActivityBudgetAbacComLocalKey).HasMaxLength(50);

                entity.Property(e => e.ActivityBudgetAbacCommitted).HasColumnType("money");

                entity.Property(e => e.ActivityBudgetAbacDescription).HasColumnType("text");

                entity.Property(e => e.ActivityBudgetAbacFirstComDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityBudgetAbacLastPayDate).HasColumnType("datetime");

                entity.Property(e => e.ActivityBudgetAbacName).HasMaxLength(500);

                entity.Property(e => e.ActivityBudgetAbacPaid).HasColumnType("money");

                entity.Property(e => e.ActivityBudgetAbacPayCentralKey).HasMaxLength(50);

                entity.Property(e => e.ActivityBudgetAbacPayLocalKey).HasMaxLength(50);

                entity.Property(e => e.ActivityBudgetAbacType).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityBudgetAbac)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActivityBudgetAbac_Activity");

                entity.HasOne(d => d.BudgetLine)
                    .WithMany(p => p.ActivityBudgetAbac)
                    .HasForeignKey(d => d.BudgetLineId)
                    .HasConstraintName("FK_ActivityBudgetAbac_BudgetLine");
            });

            modelBuilder.Entity<ActivityDocument>(entity =>
            {
                entity.HasKey(e => e.DocLinkId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.DocLinkName).HasColumnType("text");

                entity.Property(e => e.DocLinkPath).HasColumnType("text");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityDocument)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Activity_ActivityDocument");
            });

            modelBuilder.Entity<ActivityHistory>(entity =>
            {
                entity.HasKey(e => e.ActHistoryId);

                entity.Property(e => e.ActHistoryDate).HasColumnType("datetime");

                entity.Property(e => e.ActHistoryElement).HasMaxLength(50);

                entity.Property(e => e.ActiHistoryNewValue).HasColumnType("text");

                entity.Property(e => e.ActiHistoryPreviousValue).HasColumnType("text");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityHistory)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActivityHistory_Activity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ActivityHistory_UserApplication");
            });

            modelBuilder.Entity<ActivityMicrobiology>(entity =>
            {
                entity.HasKey(e => e.ActivityMicroId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityMicrobiology)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActivityMicrobiology_Activity");

                entity.HasOne(d => d.Micro)
                    .WithMany(p => p.ActivityMicrobiology)
                    .HasForeignKey(d => d.MicroId)
                    .HasConstraintName("FK_ActivityMicrobiology_Microbiology");
            });

            modelBuilder.Entity<ActivityRecurrence>(entity =>
            {
                entity.HasKey(e => e.ActivityReccurenceId);

                entity.Property(e => e.ActivityReccurenceDescription).HasMaxLength(500);

                entity.Property(e => e.ActivityReccurenceName).HasMaxLength(500);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");
            });

            modelBuilder.Entity<ActivityStatus>(entity =>
            {
                entity.HasKey(e => e.ActStatusId);

                entity.Property(e => e.ActStatusColour).HasMaxLength(10);

                entity.Property(e => e.ActStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ActStatusImgPath).HasMaxLength(50);

                entity.Property(e => e.ActStatusName).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");
            });

            modelBuilder.Entity<ActivityTag>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityTag)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActivityTag_Activity");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ActivityTag)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_ActivityTag_Tag");
            });

            modelBuilder.Entity<ActivityUserApplicationCoreStaff>(entity =>
            {
                entity.HasKey(e => e.AuacoreId);

                entity.Property(e => e.AuacoreId).HasColumnName("AUACoreId");

                entity.Property(e => e.AuacoreFte)
                    .HasColumnName("AUACoreFte")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityUserApplicationCoreStaff)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_ActivityUserApplicationCoreStaff_Activity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityUserApplicationCoreStaff)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ActivityUserApplicationCoreStaff_UserApplication");
            });

            modelBuilder.Entity<AllegroImport>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.AllegroImport)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_AllegroImport_AnnualWorkPlan");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.AllegroImport)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_AllegroImport_Expense");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AllegroImport)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AllegroImport_UserApplication");
            });

            modelBuilder.Entity<AnnualWorkPlan>(entity =>
            {
                entity.HasKey(e => e.Awpid);

                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.Awpdescription)
                    .HasColumnName("AWPDescription")
                    .HasMaxLength(150);

                entity.Property(e => e.AWPName)
                    .HasColumnName("AWPName")
                    .HasMaxLength(50);

                entity.Property(e => e.Awpyear)
                    .HasColumnName("AWPYear")
                    .HasColumnType("date");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Mawpid).HasColumnName("MAWPId");
            });

            modelBuilder.Entity<BudgetConstant>(entity =>
            {
                entity.HasKey(e => e.BudConId);

                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.BudConT1factor).HasColumnName("BudConT1Factor");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.BudgetConstant)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_BudgetConstant_AnnualWorkPlan");
            });

            modelBuilder.Entity<BudgetLine>(entity =>
            {
                entity.Property(e => e.BudgetLineDescription).HasMaxLength(150);

                entity.Property(e => e.BudgetLineName).HasMaxLength(70);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Mawpid).HasColumnName("MAWPId");

                entity.HasOne(d => d.Mawp)
                    .WithMany(p => p.BudgetLine)
                    .HasForeignKey(d => d.Mawpid)
                    .HasConstraintName("FK_BudgetLine_MultiAnnualWorkPlan");
            });

            modelBuilder.Entity<BudgetThreeBucket>(entity =>
            {
                entity.HasKey(e => e.Btbid);

                entity.Property(e => e.Btbid).HasColumnName("BTBId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.BudgetThreeBucket)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_BudgetThreeBucket_Unit");
            });

            modelBuilder.Entity<CapacityLevel>(entity =>
            {
                entity.Property(e => e.CapacityLevelDescription).HasMaxLength(150);

                entity.Property(e => e.CapacityLevelName).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConstantFte>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.ConstantFteName).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.ConstantFte)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_Overhead_AnnualWorkPlan");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.Property(e => e.ContractTypeDescription).HasMaxLength(150);

                entity.Property(e => e.ContractTypeName).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");
            });

            modelBuilder.Entity<DashBudget>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DashBudgetAllocated).HasColumnType("money");

                entity.Property(e => e.DashBudgetCommitments).HasColumnType("money");

                entity.Property(e => e.DashBudgetDateExport).HasColumnType("smalldatetime");

                entity.Property(e => e.DashBudgetDpUnit)
                    .HasColumnName("DashBudgetDP_UNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.DashBudgetFundSource).HasMaxLength(255);

                entity.Property(e => e.DashBudgetLocalPosition).HasMaxLength(255);

                entity.Property(e => e.DashBudgetOfficialBudgetItem).HasMaxLength(300);

                entity.Property(e => e.DashBudgetOfficialBudgetItemDesc).HasMaxLength(300);

                entity.Property(e => e.DashBudgetPayments).HasColumnType("money");

                entity.Property(e => e.DashBudgetTitle).HasMaxLength(255);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Dpid).HasColumnName("DPId");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.DashBudget)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_DashBudget_AnnualWorkPlan");

                entity.HasOne(d => d.Dp)
                    .WithMany(p => p.DashBudget)
                    .HasForeignKey(d => d.Dpid)
                    .HasConstraintName("FK_DashBudget_DSP");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DashBudget)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_DashBudget_Unit");
            });

            modelBuilder.Entity<DashExternalPath>(entity =>
            {
                entity.Property(e => e.DashExternalPathAccessType).HasMaxLength(50);

                entity.Property(e => e.DashExternalPathFileName).HasMaxLength(250);

                entity.Property(e => e.DashExternalPathSave).HasMaxLength(500);

                entity.Property(e => e.DashExternalPathSheetName).HasMaxLength(50);

                entity.Property(e => e.DashExternalPathToFile).HasMaxLength(500);
            });

            modelBuilder.Entity<DashLinkAbacmis>(entity =>
            {
                entity.HasKey(e => new { e.DashAbaclinkMisofficialBudgetItem, e.DashAbaclinkMislocalPosition });

                entity.ToTable("DashLinkABACMIS");

                entity.Property(e => e.DashAbaclinkMisofficialBudgetItem)
                    .HasColumnName("DashABACLinkMISOfficialBudgetItem")
                    .HasMaxLength(100);

                entity.Property(e => e.DashAbaclinkMislocalPosition)
                    .HasColumnName("DashABACLinkMISLocalPosition")
                    .HasMaxLength(20);

                entity.Property(e => e.DashAbaclinkMisdsp)
                    .HasColumnName("DashABACLinkMISDSP")
                    .HasMaxLength(255);

                entity.Property(e => e.DashAbaclinkMisfundSource)
                    .HasColumnName("DashABACLinkMISFundSource")
                    .HasMaxLength(255);

                entity.Property(e => e.DashAbaclinkMisofficialBudgetItemDesc)
                    .HasColumnName("DashABACLinkMISOfficialBudgetItemDesc")
                    .HasMaxLength(255);

                entity.Property(e => e.DashAbaclinkMisunit)
                    .HasColumnName("DashABACLinkMISUNIT")
                    .HasMaxLength(255);

                entity.Property(e => e.DashAbaclinkMisunitBo)
                    .HasColumnName("DashABACLinkMISUnitBO")
                    .HasMaxLength(255);

                entity.Property(e => e.Dspid).HasColumnName("DSPId");

                entity.HasOne(d => d.Dsp)
                    .WithMany(p => p.DashLinkAbacmis)
                    .HasForeignKey(d => d.Dspid)
                    .HasConstraintName("FK_DashLinkABACMIS_DSP");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DashLinkAbacmis)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_DashLinkABACMIS_Unit");
            });

            modelBuilder.Entity<DashLinkMissionMis>(entity =>
            {
                entity.ToTable("DashLinkMissionMIS");

                entity.Property(e => e.DashLinkMissionMisid).HasColumnName("DashLinkMissionMISId");

                entity.Property(e => e.DashLinkMissionMisdp)
                    .HasColumnName("DashLinkMissionMISDP")
                    .HasMaxLength(50);

                entity.Property(e => e.DashLinkMissionMisdpcore)
                    .HasColumnName("DashLinkMissionMISDPCORE")
                    .HasMaxLength(50);

                entity.Property(e => e.DashLinkMissionMisunit)
                    .HasColumnName("DashLinkMissionMISUNIT")
                    .HasMaxLength(50);

                entity.Property(e => e.Dpid).HasColumnName("DPId");

                entity.HasOne(d => d.Dp)
                    .WithMany(p => p.DashLinkMissionMis)
                    .HasForeignKey(d => d.Dpid)
                    .HasConstraintName("FK_DashLinkMissionMIS_DSP");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DashLinkMissionMis)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_DashLinkMissionMIS_Unit");
            });

            modelBuilder.Entity<DashMeeting>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DashMeetingAllocated).HasColumnType("money");

                entity.Property(e => e.DashMeetingCommitments).HasColumnType("money");

                entity.Property(e => e.DashMeetingLogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Dpid).HasColumnName("DPId");
            });

            modelBuilder.Entity<DashMeetingTemp>(entity =>
            {
                entity.HasKey(e => e.DashMeetingId);

                entity.ToTable("DashMeetingTEMP");

                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DashMeetingAllocated).HasColumnType("money");

                entity.Property(e => e.DashMeetingCommitments).HasColumnType("money");

                entity.Property(e => e.DashMeetingLogDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Dpid).HasColumnName("DPId");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.DashMeetingTemp)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_DashMeeting_AnnualWorkPlan");

                entity.HasOne(d => d.Dp)
                    .WithMany(p => p.DashMeetingTemp)
                    .HasForeignKey(d => d.Dpid)
                    .HasConstraintName("FK_DashMeeting_DSP");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DashMeetingTemp)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_DashMeeting_Unit");
            });

            modelBuilder.Entity<DashMission>(entity =>
            {
                entity.Property(e => e.DashMissionBudgetConsumed).HasColumnType("money");

                entity.Property(e => e.DashMissionDateExport).HasColumnType("smalldatetime");

                entity.Property(e => e.DashMissionDpCore)
                    .HasColumnName("DashMissionDP_Core")
                    .HasMaxLength(50);

                entity.Property(e => e.DashMissionFullName).HasMaxLength(250);

                entity.Property(e => e.DashMissionStartDate).HasColumnType("datetime");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Dpid).HasColumnName("DPId");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.DashMission)
                    .HasForeignKey(d => d.AwpId)
                    .HasConstraintName("FK_DashMission_AnnualWorkPlan");

                entity.HasOne(d => d.Dp)
                    .WithMany(p => p.DashMission)
                    .HasForeignKey(d => d.Dpid)
                    .HasConstraintName("FK_DashMission_DSP");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DashMission)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_DashMission_Unit");
            });

            modelBuilder.Entity<DashMonth>(entity =>
            {
                entity.Property(e => e.DashMonthId).ValueGeneratedNever();

                entity.Property(e => e.DashMonthName).HasMaxLength(50);

                entity.Property(e => e.DashMonthShortName).HasMaxLength(50);
            });

            modelBuilder.Entity<DashTempDeliverables>(entity =>
            {
                entity.Property(e => e.ActStatusName).HasMaxLength(50);

                entity.Property(e => e.ActivityCode).HasMaxLength(500);

                entity.Property(e => e.ActivityName).HasMaxLength(500);

                entity.Property(e => e.ActivityStatus).HasMaxLength(50);

                entity.Property(e => e.Dspcode)
                    .HasColumnName("DSPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Dspid).HasColumnName("DSPId");

                entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Leader).HasMaxLength(50);

                entity.Property(e => e.MonthYear).HasMaxLength(50);

                entity.Property(e => e.Owner).HasMaxLength(50);

                entity.Property(e => e.PerIndName).HasMaxLength(500);

                entity.Property(e => e.SectionCode).HasMaxLength(50);

                entity.Property(e => e.Strategy).HasMaxLength(50);

                entity.Property(e => e.UnitCode).HasMaxLength(50);

                entity.HasOne(d => d.Dsp)
                    .WithMany(p => p.DashTempDeliverables)
                    .HasForeignKey(d => d.Dspid)
                    .HasConstraintName("FK_DashTempDeliverables_DSP");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.DashTempDeliverables)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_DashTempDeliverables_Unit");
            });

            modelBuilder.Entity<DashVacRate>(entity =>
            {
                entity.HasKey(e => e.DashVacRateLogId);

                entity.Property(e => e.DashVacRateLogId).ValueGeneratedNever();

                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DashVacRateAverageToR).HasColumnType("money");

                entity.Property(e => e.DashVacRateExpectedAverageToR).HasColumnType("money");

                entity.Property(e => e.DashVacRateExpectedVacancy).HasColumnType("money");

                entity.Property(e => e.DashVacRateValue).HasColumnType("money");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.DashVacRate)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_DashVacRate_AnnualWorkPlan");
            });

            modelBuilder.Entity<Deliverable>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.DeliverableDescription).HasMaxLength(150);

                entity.Property(e => e.DeliverableName).HasMaxLength(300);
            });

            modelBuilder.Entity<Dmsdocument>(entity =>
            {
                entity.HasKey(e => e.DmsDocId);

                entity.ToTable("DMSDocument");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.DmsDocCode).HasMaxLength(500);

                entity.Property(e => e.DmsDocDescription).HasMaxLength(500);

                entity.Property(e => e.DmsDocName).HasMaxLength(500);

                entity.Property(e => e.DmsDocUrl).HasMaxLength(500);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Dmsdocument)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_DMSDocument_Activity");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.Dmsdocument)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_DMSDocument_Expense");
            });

            modelBuilder.Entity<Dsp>(entity =>
            {
                entity.ToTable("DSP");

                entity.Property(e => e.DspId).HasColumnName("DSPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.DspCode)
                    .HasColumnName("DSPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.DspDescription)
                    .HasColumnName("DSPDescription")
                    .HasMaxLength(150);

                entity.Property(e => e.DspIsCore).HasColumnName("DSPIsCore");

                entity.Property(e => e.DspIsInactive).HasColumnName("DSPIsInactive");

                entity.Property(e => e.Dspname)
                    .HasColumnName("DSPName")
                    .HasMaxLength(150);

                entity.Property(e => e.DspSortSequence).HasColumnName("DSPSortSequence");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasIndex(e => e.ActivityId)
                    .HasName("IX_ExpenseActivityId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseAmount).HasColumnType("money");

                entity.Property(e => e.ExpenseAmountPaid).HasColumnType("money");

                entity.Property(e => e.ExpenseAmountPayable).HasColumnType("money");

                entity.Property(e => e.ExpenseAmountRequest).HasColumnType("money");

                entity.Property(e => e.ExpenseDescription).HasColumnType("text");

                entity.Property(e => e.ExpenseEndDate).HasColumnType("date");

                entity.Property(e => e.ExpenseEndDateActual).HasColumnType("date");

                entity.Property(e => e.ExpenseInitialAmount).HasColumnType("money");

                entity.Property(e => e.ExpenseIsHoUApproved).HasColumnName("ExpenseIsHoUApproved");

                entity.Property(e => e.ExpenseName).HasMaxLength(1000);

                entity.Property(e => e.ExpenseNote).HasColumnType("text");

                entity.Property(e => e.ExpenseStartDate).HasColumnType("date");

                entity.Property(e => e.ExpenseStartDateActual).HasColumnType("date");

                entity.Property(e => e.LastEmailNotification).HasColumnType("datetime");

                entity.Property(e => e.LocationCity).HasMaxLength(150);

                entity.Property(e => e.LocationCityActual).HasMaxLength(150);

                entity.Property(e => e.MeetingCode).HasMaxLength(150);

                entity.Property(e => e.MeetingComment).HasColumnType("text");

                entity.Property(e => e.MeetingDateApproval).HasColumnType("datetime");

                entity.Property(e => e.MeetingIsHoUapproval).HasColumnName("MeetingIsHoUApproval");

                entity.Property(e => e.MeetingOutsideSwedenNote).HasMaxLength(500);

                entity.Property(e => e.ProcComment).HasColumnType("text");

                entity.Property(e => e.UserHoUMod).HasColumnName("UserHoUMod");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Expense_Activity");

                entity.HasOne(d => d.BudgetLine)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.BudgetLineId)
                    .HasConstraintName("FK_Expense_BudgetLine");

                entity.HasOne(d => d.CapacityLevel)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.CapacityLevelId)
                    .HasConstraintName("FK_Expense_CapacityLevel");

                entity.HasOne(d => d.ContractType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ContractTypeId)
                    .HasConstraintName("FK_Expense_ContractType");

                entity.HasOne(d => d.ExpensePlatoStatus)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ExpensePlatoStatusId)
                    .HasConstraintName("FK_Expense_ExpensePlatoStatus");

                entity.HasOne(d => d.ExpenseStatus)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ExpenseStatusId)
                    .HasConstraintName("FK_Expense_ExpenseStatus");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .HasConstraintName("FK_Expense_ExpenseType");

                entity.HasOne(d => d.GrandType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.GrandTypeId)
                    .HasConstraintName("FK_Expense_GrantType");

                entity.HasOne(d => d.GrantSubType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.GrantSubTypeId)
                    .HasConstraintName("FK_Expense_GrantSubType");

                entity.HasOne(d => d.LocationActual)
                    .WithMany(p => p.ExpenseLocationActual)
                    .HasForeignKey(d => d.LocationActualId)
                    .HasConstraintName("FK_Expense_Location1");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ExpenseLocation)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Expense_Location");

                entity.HasOne(d => d.MeetingApprovalStatus)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.MeetingApprovalStatusId)
                    .HasConstraintName("FK_Expense_MeetingApprovalStatus");

                entity.HasOne(d => d.MeetingStatus)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.MeetingStatusId)
                    .HasConstraintName("FK_Expense_MeetingStatus");

                entity.HasOne(d => d.ProcConType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcConTypeId)
                    .HasConstraintName("FK_Expense_ProcurementContractType");

                entity.HasOne(d => d.ProcFrameworkType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcFrameworkTypeId)
                    .HasConstraintName("FK_Expense_ProcurementFrameworkType");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_Expense_Procurement");

                entity.HasOne(d => d.ProcStatus)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcStatusId)
                    .HasConstraintName("FK_Expense_ProcurementStatus");

                entity.HasOne(d => d.ProcSubType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcSubTypeId)
                    .HasConstraintName("FK_Expense_ProcurementSubType");

                entity.HasOne(d => d.ProcTimingStatus)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcTimingStatusId)
                    .HasConstraintName("FK_Expense_ProcurementTimingStatus");

                entity.HasOne(d => d.ProcType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcTypeId)
                    .HasConstraintName("FK_Expense_ProcurementType");

                entity.HasOne(d => d.ProcessProject)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcessProjectId)
                    .HasConstraintName("FK_Expense_ProcessProject");

                entity.HasOne(d => d.ProcessProjectSub)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ProcessProjectSubId)
                    .HasConstraintName("FK_Expense_ProcessProjectSub");

                entity.HasOne(d => d.Recurrence)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.RecurrenceId)
                    .HasConstraintName("FK_Expense_Recurrence");

                entity.HasOne(d => d.SpdKeyOutput)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.SpdKeyOutputId)
                    .HasConstraintName("FK_Expense_SpdKeyOutput");

                entity.HasOne(d => d.SpdObjective)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.SpdObjectiveId)
                    .HasConstraintName("FK_Expense_SpdObjective");

                entity.HasOne(d => d.UserIdAuthOfficerNavigation)
                    .WithMany(p => p.ExpenseUserIdAuthOfficerNavigation)
                    .HasForeignKey(d => d.UserIdAuthOfficer)
                    .HasConstraintName("FK_Expense_UserApplication2");

                entity.HasOne(d => d.UserIdFinancialAssistantNavigation)
                    .WithMany(p => p.ExpenseUserIdFinancialAssistantNavigation)
                    .HasForeignKey(d => d.UserIdFinancialAssistant)
                    .HasConstraintName("FK_Expense_UserApplication3");

                entity.HasOne(d => d.UserIdOwnerNavigation)
                    .WithMany(p => p.ExpenseUserIdOwnerNavigation)
                    .HasForeignKey(d => d.UserIdOwner)
                    .HasConstraintName("FK_Expense_UserApplication");

                entity.HasOne(d => d.UserIdProcurementOfficerNavigation)
                    .WithMany(p => p.ExpenseUserIdProcurementOfficerNavigation)
                    .HasForeignKey(d => d.UserIdProcurementOfficer)
                    .HasConstraintName("FK_Expense_UserApplication1");
            });

            modelBuilder.Entity<ExpenseBudgetAbac>(entity =>
            {
                entity.Property(e => e.AbacId).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseBudgetAbacComLocalKey).HasMaxLength(50);

                entity.Property(e => e.ExpenseBudgetAbacCommitted).HasColumnType("money");

                entity.Property(e => e.ExpenseBudgetAbacDescription).HasColumnType("text");

                entity.Property(e => e.ExpenseBudgetAbacFirstComDate).HasColumnType("datetime");

                entity.Property(e => e.ExpenseBudgetAbacLastPayDate).HasColumnType("datetime");

                entity.Property(e => e.ExpenseBudgetAbacName).HasMaxLength(500);

                entity.Property(e => e.ExpenseBudgetAbacPaid).HasColumnType("money");

                entity.Property(e => e.ExpenseBudgetAbacPayCentralKey).HasMaxLength(50);

                entity.Property(e => e.ExpenseBudgetAbacPayLocalKey).HasMaxLength(50);

                entity.Property(e => e.ExpenseBudgetAbacType).HasMaxLength(50);

                entity.HasOne(d => d.BudgetLine)
                    .WithMany(p => p.ExpenseBudgetAbac)
                    .HasForeignKey(d => d.BudgetLineId)
                    .HasConstraintName("FK_ExpenseBudgetAbac_BudgetLine");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseBudgetAbac)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_ExpenseBudgetAbac_Expense");
            });

            modelBuilder.Entity<ExpenseDeliverable>(entity =>
            {
                entity.HasKey(e => e.ExpDeliverableId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.DeliverableSmap1)
                    .HasColumnName("DeliverableSMAP1")
                    .HasMaxLength(10);

                entity.Property(e => e.DeliverableSmap2)
                    .HasColumnName("DeliverableSMAP2")
                    .HasMaxLength(10);

                entity.Property(e => e.DeliverableSmap3)
                    .HasColumnName("DeliverableSMAP3")
                    .HasMaxLength(10);

                entity.Property(e => e.DeliverableSmap4)
                    .HasColumnName("DeliverableSMAP4")
                    .HasMaxLength(10);

                entity.Property(e => e.ExpDeliverableEndDate).HasColumnType("datetime");

                entity.HasOne(d => d.Deliverable)
                    .WithMany(p => p.ExpenseDeliverable)
                    .HasForeignKey(d => d.DeliverableId)
                    .HasConstraintName("FK_ExpenseDeliverable_Deliverable");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseDeliverable)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_ExpenseDeliverable_Expense");

                entity.HasOne(d => d.UserIdOwnerNavigation)
                    .WithMany(p => p.ExpenseDeliverable)
                    .HasForeignKey(d => d.UserIdOwner)
                    .HasConstraintName("FK_ExpenseDeliverable_UserApplication");
            });

            modelBuilder.Entity<ExpenseFunctionParticipant>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseFunctionParticipant)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_ExpenseFunctionParticipant_Expense");

                entity.HasOne(d => d.FunctionParticipant)
                    .WithMany(p => p.ExpenseFunctionParticipant)
                    .HasForeignKey(d => d.FunctionParticipantId)
                    .HasConstraintName("FK_ExpenseFunctionParticipant_FunctionParticipant");
            });

            modelBuilder.Entity<ExpenseHistory>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseHistoryElement).HasMaxLength(150);

                entity.Property(e => e.ExpenseHistoryNewValue).HasMaxLength(150);

                entity.Property(e => e.ExpenseHistoryPreviousValue).HasMaxLength(150);

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseHistory)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_ExpenseHistory_Expense");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExpenseHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExpenseHistory_UserApplication");
            });

            modelBuilder.Entity<ExpensePlatoStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpensePlatoStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ExpensePlatoStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<ExpenseStaff>(entity =>
            {
                entity.HasIndex(e => e.ExpenseId)
                    .HasName("IX_ExpenseStaffExpenseId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffActualFte).HasColumnName("ExpenseStaffActualFTE");

                entity.Property(e => e.ExpenseStaffHoDpValidationDate)
                    .HasColumnName("ExpenseStaffHoDPValidationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffHoUValidationDate)
                    .HasColumnName("ExpenseStaffHoUValidationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffIsHoDpValidation).HasColumnName("ExpenseStaffIsHoDPValidation");

                entity.Property(e => e.ExpenseStaffIsHoUValidation).HasColumnName("ExpenseStaffIsHoUValidation");

                entity.Property(e => e.ExpenseStaffPlanFte).HasColumnName("ExpenseStaffPlanFTE");

                entity.Property(e => e.UserIdHoDpvalidation).HasColumnName("UserIdHoDPValidation");

                entity.Property(e => e.UserIdHoUvalidation).HasColumnName("UserIdHoUValidation");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseStaff)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_ExpenseStaff_Expense");

                entity.HasOne(d => d.ExpenseStaffStatus)
                    .WithMany(p => p.ExpenseStaff)
                    .HasForeignKey(d => d.ExpenseStaffStatusId)
                    .HasConstraintName("FK_ExpenseStaff_ExpenseStaffStatus");

                entity.HasOne(d => d.UserApplication)
                    .WithMany(p => p.ExpenseStaffUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExpenseStaff_UserApplication");

                entity.HasOne(d => d.UserIdHoDpValidationNavigation)
                    .WithMany(p => p.ExpenseStaffUserIdHoDpvalidationNavigation)
                    .HasForeignKey(d => d.UserIdHoDpvalidation)
                    .HasConstraintName("FK_ExpenseStaff_UserApplication2");

                entity.HasOne(d => d.UserIdHoUValidationNavigation)
                    .WithMany(p => p.ExpenseStaffUserIdHoUvalidationNavigation)
                    .HasForeignKey(d => d.UserIdHoUvalidation)
                    .HasConstraintName("FK_ExpenseStaff_UserApplication1");
            });

            modelBuilder.Entity<ExpenseStaffHistory>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffHistoryElement).HasMaxLength(150);

                entity.Property(e => e.ExpenseStaffHistoryNewValue).HasMaxLength(150);

                entity.Property(e => e.ExpenseStaffHistoryPreviousValue).HasMaxLength(150);

                entity.HasOne(d => d.ExpenseStaff)
                    .WithMany(p => p.ExpenseStaffHistory)
                    .HasForeignKey(d => d.ExpenseStaffId)
                    .HasConstraintName("FK_ExpenseStaffHistory_ExpenseStaff");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExpenseStaffHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExpenseStaffHistory_UserApplication");
            });

            modelBuilder.Entity<ExpenseStaffLost>(entity =>
            {
                entity.HasKey(e => e.ExpenseStaffId);

                entity.Property(e => e.ExpenseStaffId).ValueGeneratedNever();

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffActualFte).HasColumnName("ExpenseStaffActualFTE");

                entity.Property(e => e.ExpenseStaffHoDpvalidationDate)
                    .HasColumnName("ExpenseStaffHoDPValidationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffHoUvalidationDate)
                    .HasColumnName("ExpenseStaffHoUValidationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffIsHoDpvalidation).HasColumnName("ExpenseStaffIsHoDPValidation");

                entity.Property(e => e.ExpenseStaffIsHoUvalidation).HasColumnName("ExpenseStaffIsHoUValidation");

                entity.Property(e => e.ExpenseStaffPlanFte).HasColumnName("ExpenseStaffPlanFTE");

                entity.Property(e => e.UserIdHoDpvalidation).HasColumnName("UserIdHoDPValidation");

                entity.Property(e => e.UserIdHoUvalidation).HasColumnName("UserIdHoUValidation");
            });

            modelBuilder.Entity<ExpenseStaffStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseStaffStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ExpenseStaffStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<ExpenseStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ExpenseStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExpenseTypeDescription).HasMaxLength(150);

                entity.Property(e => e.ExpenseTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<ExternalToolsRole>(entity =>
            {
                entity.HasKey(e => e.ExternalToolRoleId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ExternalToolRoleDescription).HasMaxLength(150);

                entity.Property(e => e.ExternalToolRoleName).HasMaxLength(150);
            });

            modelBuilder.Entity<FunctionParticipant>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.FunctionParticipantDescription).HasMaxLength(150);

                entity.Property(e => e.FunctionParticipantName).HasMaxLength(50);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.FunctionParticipant)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_FunctionParticipant_AnnualWorkPlan");
            });

            modelBuilder.Entity<GlobalSetting>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.GlobalSettingDescription).HasMaxLength(500);

                entity.Property(e => e.GlobalSettingValue).HasMaxLength(500);

                entity.HasOne(d => d.SettingType)
                    .WithMany(p => p.GlobalSetting)
                    .HasForeignKey(d => d.SettingTypeId)
                    .HasConstraintName("FK_GlobalSetting_SettingType");
            });

            modelBuilder.Entity<GradeCost>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.GradeCost1).HasColumnName("GradeCost");

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.GradeCost)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_GradeCost_AnnualWorkPlan");

                entity.HasOne(d => d.UserGrade)
                    .WithMany(p => p.GradeCost)
                    .HasForeignKey(d => d.UserGradeId)
                    .HasConstraintName("FK_GradeCost_UserGrade");
            });

            modelBuilder.Entity<GrantSubType>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.GrantSubTypeDescription).HasMaxLength(150);

                entity.Property(e => e.GrantSubTypeName).HasMaxLength(200);

                entity.HasOne(d => d.GrantType)
                    .WithMany(p => p.GrantSubType)
                    .HasForeignKey(d => d.GrantTypeId)
                    .HasConstraintName("FK_GrantSubType_GrantType");
            });

            modelBuilder.Entity<GrantType>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.GrantTitle).HasMaxLength(150);

                entity.Property(e => e.GrantTypeDescription).HasMaxLength(150);

                entity.Property(e => e.GrantTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.GroupDescription).HasMaxLength(150);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.SmaplanId).HasColumnName("SMAPlanId");

                entity.HasOne(d => d.Smaplan)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.SmaplanId)
                    .HasConstraintName("FK_Group_StrategyMAPlan");
            });

            modelBuilder.Entity<GroupActivity>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.GroupActivityCode).HasMaxLength(50);

                entity.Property(e => e.GroupActivityDescription).HasMaxLength(500);

                entity.Property(e => e.GroupActivityName).HasMaxLength(500);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.GroupActivity)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_GroupActivity_AnnualWorkPlan");
            });

            modelBuilder.Entity<KeyObjective>(entity =>
            {
                entity.HasKey(e => e.KeyObjId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.KeyObjDescription).HasMaxLength(150);

                entity.Property(e => e.KeyObjName).HasMaxLength(300);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.LocationDescription).HasMaxLength(150);

                entity.Property(e => e.LocationName).HasMaxLength(50);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.LogDateTime).HasColumnType("nchar(10)");

                entity.Property(e => e.LogNote).HasMaxLength(200);

                entity.Property(e => e.LogNote2).HasMaxLength(200);

                entity.HasOne(d => d.LogEntryType)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.LogEntryTypeId)
                    .HasConstraintName("FK_Log_LogEntryType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Log_UserApplication");
            });

            modelBuilder.Entity<LogEntryType>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.LogEntryTypeCode).HasMaxLength(20);

                entity.Property(e => e.LogEntryTypeDescription).HasMaxLength(150);

                entity.Property(e => e.LogEntryTypeName).HasMaxLength(150);
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.Property(e => e.Level).HasMaxLength(128);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.LocationCity).HasMaxLength(150);

                entity.Property(e => e.MeetingAmount).HasColumnType("money");

                entity.Property(e => e.MeetingCode).HasMaxLength(50);

                entity.Property(e => e.MeetingEndDate).HasColumnType("datetime");

                entity.Property(e => e.MeetingName).HasMaxLength(1000);

                entity.Property(e => e.MeetingStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_Meeting_Expense");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Meeting_Location");

                entity.HasOne(d => d.UserIdOrganizerNavigation)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.UserIdOrganizer)
                    .HasConstraintName("FK_Meeting_UserApplication");
            });

            modelBuilder.Entity<MeetingApprovalStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MeetingApprovalStatusDescription).HasMaxLength(150);

                entity.Property(e => e.MeetingApprovalStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<MeetingBudgetAbac>(entity =>
            {
                entity.Property(e => e.AbacId).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MeetingBudgetAbacCommitted).HasColumnType("money");

                entity.Property(e => e.MeetingBudgetAbacDescription).HasColumnType("text");

                entity.Property(e => e.MeetingBudgetAbacName).HasMaxLength(500);

                entity.Property(e => e.MeetingBudgetAbacPaid).HasColumnType("money");

                entity.Property(e => e.MeetingBudgetAbacType).HasMaxLength(50);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.MeetingBudgetAbac)
                    .HasForeignKey(d => d.AwpId)
                    .HasConstraintName("FK_MeetingBudgetAbac_AnnualWorkPlan");

                entity.HasOne(d => d.BudgetLine)
                    .WithMany(p => p.MeetingBudgetAbac)
                    .HasForeignKey(d => d.BudgetLineId)
                    .HasConstraintName("FK_MeetingBudgetAbac_BudgetLine");
            });

            modelBuilder.Entity<MeetingBudgetCalculation>(entity =>
            {
                entity.HasKey(e => e.MeetingBudgetId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MeetingBudgetAmountExternal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MeetingBudgetAmountInternal).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<MeetingStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MeetingStatusDescription).HasMaxLength(150);

                entity.Property(e => e.MeetingStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<Microbiology>(entity =>
            {
                entity.HasKey(e => e.MicroId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MicroDescription).HasMaxLength(150);

                entity.Property(e => e.MicroName).HasMaxLength(150);
            });

            modelBuilder.Entity<MissionBudgetCalculation>(entity =>
            {
                entity.HasKey(e => e.MissionBudgetId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MissionBudgetCostPerDay).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MissionBudgetCalculation)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_MissionBudgetCalculation_Location");
            });

            modelBuilder.Entity<MultiAnnualWorkPlan>(entity =>
            {
                entity.HasKey(e => e.Mawpid);

                entity.Property(e => e.Mawpid).HasColumnName("MAWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.MawpendYear)
                    .HasColumnName("MAWPEndYear")
                    .HasColumnType("date");

                entity.Property(e => e.MawpstartYear)
                    .HasColumnName("MAWPStartYear")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.NoteContent).HasMaxLength(2000);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Note_Activity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Note_UserApplication");
            });

            modelBuilder.Entity<PendingExpenseTransfer>(entity =>
            {
                entity.HasKey(e => e.PetId);

                entity.Property(e => e.PetId).ValueGeneratedOnAdd();

                entity.Property(e => e.Btbid).HasColumnName("BTBId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.PetAbacReference).HasMaxLength(50);

                entity.Property(e => e.PetAmount).HasColumnType("money");

                entity.Property(e => e.PetDateApproval).HasColumnType("datetime");

                entity.Property(e => e.PetDateCommitted).HasColumnType("datetime");

                entity.Property(e => e.PetDateDeleted).HasColumnType("datetime");

                entity.Property(e => e.PetDateDirectorApproval).HasColumnType("datetime");

                entity.Property(e => e.PetDateDirectorRejected).HasColumnType("datetime");

                entity.Property(e => e.PetDateExcRejected).HasColumnType("datetime");

                entity.Property(e => e.PetDateFinanceInitRejected).HasColumnType("datetime");

                entity.Property(e => e.PetDateFinanceRejected).HasColumnType("datetime");

                entity.Property(e => e.PetDateHeadOfUnitSourceApproval).HasColumnType("datetime");

                entity.Property(e => e.PetDateHeadOfUnitSourceRejected).HasColumnType("datetime");

                entity.Property(e => e.PetDateHeadOfUnitTargetApproval).HasColumnType("datetime");

                entity.Property(e => e.PetDateHeadOfUnitTargetRejected).HasColumnType("datetime");

                entity.Property(e => e.PetDateLastNotification).HasColumnType("datetime");

                entity.Property(e => e.PetIsExcrejected).HasColumnName("PetIsEXCRejected");

                entity.Property(e => e.PetMotivation).HasMaxLength(1000);

                entity.Property(e => e.PetMotivationTarget).HasColumnType("text");

                entity.Property(e => e.PetNote).HasColumnType("text");

                entity.Property(e => e.PetRejectionReason).HasMaxLength(500);

                entity.Property(e => e.PetTransactionNumber).HasMaxLength(50);

                entity.HasOne(d => d.ExpenseIdSourceNavigation)
                    .WithMany(p => p.PendingExpenseTransferExpenseIdSourceNavigation)
                    .HasForeignKey(d => d.ExpenseIdSource)
                    .HasConstraintName("FK_PendingExpenseTransfer_Expense");

                entity.HasOne(d => d.ExpenseIdTargetNavigation)
                    .WithMany(p => p.PendingExpenseTransferExpenseIdTargetNavigation)
                    .HasForeignKey(d => d.ExpenseIdTarget)
                    .HasConstraintName("FK_PendingExpenseTransfer_Expense1");

                entity.HasOne(d => d.PetApprovalStatus)
                    .WithMany(p => p.PendingExpenseTransfer)
                    .HasForeignKey(d => d.PetApprovalStatusId)
                    .HasConstraintName("FK_PendingExpenseTransfer_PendingTransferApprovalStatus");

                //entity.HasOne(d => d.Pet)
                //    .WithOne(p => p.InversePet)
                //    .HasForeignKey<PendingExpenseTransfer>(d => d.PetId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PendingExpenseTransfer_PendingExpenseTransfer");

                entity.HasOne(d => d.PetStatus)
                    .WithMany(p => p.PendingExpenseTransfer)
                    .HasForeignKey(d => d.PetStatusId)
                    .HasConstraintName("FK_PendingExpenseTransfer_PendingTransferStatus");

                entity.HasOne(d => d.UserIdAutorizedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdAutorizedNavigation)
                    .HasForeignKey(d => d.UserIdAutorized)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationAuthorized");

                entity.HasOne(d => d.UserIdCommitedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdCommitedNavigation)
                    .HasForeignKey(d => d.UserIdCommited)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationCommited");

                entity.HasOne(d => d.UserIdDeletedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdDeletedNavigation)
                    .HasForeignKey(d => d.UserIdDeleted)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationDeleted");

                entity.HasOne(d => d.UserIdDirectorAutorizedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdDirectorAutorizedNavigation)
                    .HasForeignKey(d => d.UserIdDirectorAutorized)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationDirector");

                entity.HasOne(d => d.UserIdHeadOfUnitSourceAutorizedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdHeadOfUnitSourceAutorizedNavigation)
                    .HasForeignKey(d => d.UserIdHeadOfUnitSourceAutorized)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationHoUSource");

                entity.HasOne(d => d.UserIdHeadOfUnitTargetAutorizedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdHeadOfUnitTargetAutorizedNavigation)
                    .HasForeignKey(d => d.UserIdHeadOfUnitTargetAutorized)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationHoUTarget");

                entity.HasOne(d => d.UserIdRejectedNavigation)
                    .WithMany(p => p.PendingExpenseTransferUserIdRejectedNavigation)
                    .HasForeignKey(d => d.UserIdRejected)
                    .HasConstraintName("FK_PendingExpenseTransfer_UserApplicationRejected");
            });

            modelBuilder.Entity<PendingTransferApprovalStatus>(entity =>
            {
                entity.HasKey(e => e.PetApprovalStatusId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.PetApprovalStatusDescription).HasMaxLength(150);

                entity.Property(e => e.PetApprovalStatusIsExcapproved).HasColumnName("PetApprovalStatusIsEXCApproved");

                entity.Property(e => e.PetApprovalStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<PendingTransferStatus>(entity =>
            {
                entity.HasKey(e => e.PetStatusId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.PetStatusDescription).HasMaxLength(150);

                entity.Property(e => e.PetStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<PerformanceIndicator>(entity =>
            {
                entity.HasKey(e => e.PerIndId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.PerIndDescription).HasMaxLength(150);

                entity.Property(e => e.PerIndName).HasMaxLength(300);
            });

            modelBuilder.Entity<PlatoStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.PlatoStatusDescription).HasMaxLength(150);

                entity.Property(e => e.PlatoStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.PriorityDescription).HasMaxLength(150);

                entity.Property(e => e.PriorityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcessCode).HasMaxLength(10);

                entity.Property(e => e.ProcessDescription).HasMaxLength(150);

                entity.Property(e => e.ProcessName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProcessProject>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcessProjectDescription).HasMaxLength(150);

                entity.Property(e => e.ProcessProjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProcessProjectSub>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcessProjectSubDescription).HasMaxLength(150);

                entity.Property(e => e.ProcessProjectSubName).HasMaxLength(50);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.ProcessProjectSub)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_ProcessProjectSub_AnnualWorkPlan");

                entity.HasOne(d => d.ProcessProject)
                    .WithMany(p => p.ProcessProjectSub)
                    .HasForeignKey(d => d.ProcessProjectId)
                    .HasConstraintName("FK_ProcessProjectSub_ProcessProject");
            });

            modelBuilder.Entity<Procurement>(entity =>
            {
                entity.HasKey(e => e.ProcId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcAward14DayStandstill).HasColumnType("datetime");

                entity.Property(e => e.ProcAwardAmount).HasColumnType("money");

                entity.Property(e => e.ProcAwardConsultationCed).HasColumnType("datetime");

                entity.Property(e => e.ProcAwardDecision).HasColumnType("datetime");

                entity.Property(e => e.ProcAwardEvidenceExclusionCriteria).HasColumnType("text");

                entity.Property(e => e.ProcAwardNotificationLetter).HasColumnType("datetime");

                entity.Property(e => e.ProcContractedAmount).HasColumnType("money");

                entity.Property(e => e.ProcDetailConsultationCpcg)
                    .HasColumnName("ProcDetailConsultationCPCG")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcDetailContractNumber).HasMaxLength(150);

                entity.Property(e => e.ProcDetailDurationComment).HasColumnType("text");

                entity.Property(e => e.ProcDetailDurationMonth).HasMaxLength(150);

                entity.Property(e => e.ProcDetailDurationWeek).HasMaxLength(150);

                entity.Property(e => e.ProcDetailDurationYear).HasMaxLength(150);

                entity.Property(e => e.ProcDetailExpectedContractSignature).HasColumnType("datetime");

                entity.Property(e => e.ProcDetailExpectedContractStartDate).HasColumnType("datetime");

                entity.Property(e => e.ProcDetailExpectedLaunch).HasColumnType("datetime");

                entity.Property(e => e.ProcDetailNumberLot).HasMaxLength(150);

                entity.Property(e => e.ProcDetailSubmissionDocCpcg)
                    .HasColumnName("ProcDetailSubmissionDocCPCG")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcEvalCommetteeAppointed).HasColumnType("datetime");

                entity.Property(e => e.ProcEvalEvalCommetteeMeeting).HasColumnType("datetime");

                entity.Property(e => e.ProcEvalReportSignature).HasColumnType("datetime");

                entity.Property(e => e.ProcLauchPublicationOj)
                    .HasColumnName("ProcLauchPublicationOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchArrivalCorrigenda).HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchArrivalProc).HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchConfirmationSubmission).HasColumnType("text");

                entity.Property(e => e.ProcLaunchCpcgmeeting)
                    .HasColumnName("ProcLaunchCPCGMeeting")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchCpcgmeetingIsApplicable).HasColumnName("ProcLaunchCPCGMeetingIsApplicable");

                entity.Property(e => e.ProcLaunchDeadline).HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchDeadlineClarification).HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchDispatchContractNoticeOj)
                    .HasColumnName("ProcLaunchDispatchContractNoticeOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchEstimatedPublicationOj)
                    .HasColumnName("ProcLaunchEstimatedPublicationOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchNameQa)
                    .HasColumnName("ProcLaunchNameQA")
                    .HasColumnType("text");

                entity.Property(e => e.ProcLaunchNumberQa)
                    .HasColumnName("ProcLaunchNumberQA")
                    .HasColumnType("text");

                entity.Property(e => e.ProcLaunchPublicationCorrigendaOj)
                    .HasColumnName("ProcLaunchPublicationCorrigendaOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchPublicationCorrigendaWebsite).HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchPublicationEcdcWebsite).HasColumnType("datetime");

                entity.Property(e => e.ProcLaunchReference).HasMaxLength(1500);

                entity.Property(e => e.ProcNegociatedProcedureDeadline).HasColumnType("datetime");

                entity.Property(e => e.ProcNegociatedProcedureDispatch).HasColumnType("datetime");

                entity.Property(e => e.ProcNegociatedProcedureReference).HasMaxLength(1500);

                entity.Property(e => e.ProcOpeningCommetteAppointedDate).HasColumnType("datetime");

                entity.Property(e => e.ProcOpeningDate).HasColumnType("datetime");

                entity.Property(e => e.ProcPublicationDeadline).HasColumnType("datetime");

                entity.Property(e => e.ProcPublicationDispatchOj)
                    .HasColumnName("ProcPublicationDispatchOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcPublicationOnWeb).HasColumnType("datetime");

                entity.Property(e => e.ProcPublicationPublicationOj)
                    .HasColumnName("ProcPublicationPublicationOJ")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Procurement2>(entity =>
            {
                entity.HasKey(e => e.ProcId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcActualLaunchDate).HasColumnType("datetime");

                entity.Property(e => e.ProcComment).HasColumnType("text");

                entity.Property(e => e.ProcContractedAmount).HasColumnType("money");

                entity.Property(e => e.ProcCurrentExpectedContractSignature).HasColumnType("datetime");

                entity.Property(e => e.ProcCurrentExpectedLaunch).HasColumnType("datetime");

                entity.Property(e => e.ProcDeadline).HasColumnType("datetime");

                entity.Property(e => e.ProcExpectedSubmissionDocCpcg)
                    .HasColumnName("ProcExpectedSubmissionDocCPCG")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcPlannedKickoffDate).HasColumnType("datetime");

                entity.Property(e => e.ProcNumberFwc).HasColumnName("ProcNumberFWC");

                entity.Property(e => e.ProcPlannedExpectedContractSignature).HasColumnType("datetime");

                entity.Property(e => e.ProcPlannedExpectedLaunch).HasColumnType("datetime");

                entity.Property(e => e.ProcSignatureContract).HasColumnType("datetime");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_Procurement2_Expense");

                entity.HasOne(d => d.ProcConType)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.ProcConTypeId)
                    .HasConstraintName("FK_Procurement2_ProcurementContractType");

                entity.HasOne(d => d.ProcFinancingDecision)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.ProcFinancingDecisionId)
                    .HasConstraintName("FK_Procurement2_ProcurementFinancingDecision");

                entity.HasOne(d => d.ProcFrameworkType)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.ProcFrameworkTypeId)
                    .HasConstraintName("FK_Procurement2_ProcurementFrameworkType");

                entity.HasOne(d => d.ProcTimingStatus)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.ProcTimingStatusId)
                    .HasConstraintName("FK_Procurement2_ProcurementTimingStatus");

                entity.HasOne(d => d.ProcType)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.ProcTypeId)
                    .HasConstraintName("FK_Procurement2_ProcurementType");

                entity.HasOne(d => d.UserIdOwnerNavigation)
                    .WithMany(p => p.Procurement2)
                    .HasForeignKey(d => d.UserIdOwner)
                    .HasConstraintName("FK_Procurement2_UserApplication");
            });

            modelBuilder.Entity<ProcurementCompagnyDispatch>(entity =>
            {
                entity.HasKey(e => e.ProcCompagnyDispatchId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcCompagnyDispatchAdress).HasMaxLength(500);

                entity.Property(e => e.ProcCompagnyDispatchContactPerson).HasMaxLength(500);

                entity.Property(e => e.ProcCompagnyDispatchDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcCompagnyDispatchEmail).HasMaxLength(100);

                entity.Property(e => e.ProcCompagnyDispatchName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcCompagnyDispatchPhone).HasMaxLength(100);

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementCompagnyDispatch)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementCompagnyDispatch_Procurement");
            });

            modelBuilder.Entity<ProcurementCompagnyReceived>(entity =>
            {
                entity.HasKey(e => e.ProcCompagnyReceivedId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcCompagnyReceivedDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcCompagnyReceivedName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementCompagnyReceived)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementCompagnyReceived_Procurement");
            });

            modelBuilder.Entity<ProcurementContract>(entity =>
            {
                entity.HasKey(e => e.ProcContractId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcContractArrival).HasColumnType("datetime");

                entity.Property(e => e.ProcContractDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcContractLot)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcContractNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcContractSignature).HasColumnType("datetime");

                entity.Property(e => e.ProcTenderName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementContract)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementContract_Procurement");
            });

            modelBuilder.Entity<ProcurementContractType>(entity =>
            {
                entity.HasKey(e => e.ProcConTypeId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcConTypeDescription).HasMaxLength(150);

                entity.Property(e => e.ProcConTypeName).HasMaxLength(500);
            });

            modelBuilder.Entity<ProcurementCorrigendum>(entity =>
            {
                entity.HasKey(e => e.ProcCorrigendumId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcCorrigendumArrival).HasColumnType("datetime");

                entity.Property(e => e.ProcCorrigendumPublicationOj)
                    .HasColumnName("ProcCorrigendumPublicationOJ")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProcCorrigendumPublicationWeb).HasColumnType("datetime");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementCorrigendum)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementCorrigendum_Procurement");
            });

            modelBuilder.Entity<ProcurementEvaluationCommittee>(entity =>
            {
                entity.HasKey(e => e.ProcEvaluationId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementEvaluationCommittee)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementEvaluationCommittee_Procurement");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProcurementEvaluationCommittee)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ProcurementEvaluationCommittee_UserApplication");
            });

            modelBuilder.Entity<ProcurementFinancingDecision>(entity =>
            {
                entity.HasKey(e => e.ProcFinancingDecisionId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcFinancingDecisionFunctionalGroup).HasMaxLength(250);

                entity.Property(e => e.ProcFinancingDecisionName).HasMaxLength(250);

                entity.Property(e => e.ProcFinancingDecisionStrategy).HasMaxLength(250);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.ProcurementFinancingDecision)
                    .HasForeignKey(d => d.AwpId)
                    .HasConstraintName("FK_ProcurementFinancingDecision_AnnualWorkPlan");
            });

            modelBuilder.Entity<ProcurementFrameworkType>(entity =>
            {
                entity.HasKey(e => e.ProcFrameworkTypeId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcFrameworkTypeDescription).HasMaxLength(150);

                entity.Property(e => e.ProcFrameworkTypeName).HasMaxLength(150);
            });

            modelBuilder.Entity<ProcurementMember>(entity =>
            {
                entity.HasKey(e => e.ProcMemberId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementMember)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementMember_Procurement");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProcurementMember)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ProcurementMember_UserApplication");
            });

            modelBuilder.Entity<ProcurementPackage>(entity =>
            {
                entity.HasKey(e => e.ProcPackageId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcPackageDeliverables)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcPackageDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcPackageImplementation).HasColumnType("datetime");

                entity.Property(e => e.ProcPackageName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementPackage)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementPackage_Procurement");

                entity.HasOne(d => d.UserIdProjectManagerNavigation)
                    .WithMany(p => p.ProcurementPackage)
                    .HasForeignKey(d => d.UserIdProjectManager)
                    .HasConstraintName("FK_ProcurementPackage_UserApplication");
            });

            modelBuilder.Entity<ProcurementStage>(entity =>
            {
                entity.HasKey(e => e.ProcStageId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcStageCompletedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ProcurementStage)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_ProcurementStage_Expense");

                entity.HasOne(d => d.ProcStatus)
                    .WithMany(p => p.ProcurementStage)
                    .HasForeignKey(d => d.ProcStatusId)
                    .HasConstraintName("FK_ProcurementStage_ProcurementStatus");
            });

            modelBuilder.Entity<ProcurementStatus>(entity =>
            {
                entity.HasKey(e => e.ProcStatusId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ProcStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<ProcurementStatusWorkflow>(entity =>
            {
                entity.HasKey(e => e.ProcStatusWorkflowId);

                entity.HasOne(d => d.ProcurementType)
                    .WithMany(p => p.ProcurementStatusWorkflow)
                    .HasForeignKey(d => d.ProcTypeId)
                    .HasConstraintName("FK_ProcurementStatusWorkflow_ProcurementType");

                entity.HasOne(d => d.ProcStatus)
                    .WithMany(p => p.ProcurementStatusWorkflow)
                    .HasForeignKey(d => d.ProcStatusId)
                    .HasConstraintName("FK_ProcurementStatusWorkflow_ProcurementStatus");
            });

            modelBuilder.Entity<ProcurementSubType>(entity =>
            {
                entity.HasKey(e => e.ProcSubTypeId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcSubTypeDescription).HasMaxLength(150);

                entity.Property(e => e.ProcSubTypeName).HasMaxLength(50);

                entity.HasOne(d => d.ProcType)
                    .WithMany(p => p.ProcurementSubType)
                    .HasForeignKey(d => d.ProcTypeId)
                    .HasConstraintName("FK_ProcurementSubType_ProcurementType");
            });

            modelBuilder.Entity<ProcurementTender>(entity =>
            {
                entity.HasKey(e => e.ProcTenderId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcTenderAdress).HasMaxLength(500);

                entity.Property(e => e.ProcTenderContactPerson).HasMaxLength(500);

                entity.Property(e => e.ProcTenderDescription).HasColumnType("text");

                entity.Property(e => e.ProcTenderEmail).HasMaxLength(100);

                entity.Property(e => e.ProcTenderEntity).HasMaxLength(500);

                entity.Property(e => e.ProcTenderName).HasMaxLength(500);

                entity.Property(e => e.ProcTenderPhone).HasMaxLength(100);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ProcurementTender)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_ProcurementTender_Location");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.ProcurementTender)
                    .HasForeignKey(d => d.ProcId)
                    .HasConstraintName("FK_ProcurementTender_Procurement");
            });

            modelBuilder.Entity<ProcurementTimingStatus>(entity =>
            {
                entity.HasKey(e => e.ProcTimingStatusId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcTimingStatusDescription).HasMaxLength(150);

                entity.Property(e => e.ProcTimingStatusName).HasMaxLength(150);
            });

            modelBuilder.Entity<ProcurementType>(entity =>
            {
                entity.HasKey(e => e.ProcTypeId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProcTypeDescription).HasMaxLength(150);

                entity.Property(e => e.ProcTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ProjectDescription).HasMaxLength(150);

                entity.Property(e => e.ProjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProjectManagementPlan>(entity =>
            {
                entity.HasKey(e => e.PmplanId);

                entity.Property(e => e.PmplanId).HasColumnName("PMPlanId");

                entity.Property(e => e.ApprovalApplyDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.OriginalPmplanId).HasColumnName("OriginalPMPlanId");

                entity.Property(e => e.Pmpassumptions).HasColumnName("PMPAssumptions");

                entity.Property(e => e.Pmpbackground).HasColumnName("PMPBackground");

                entity.Property(e => e.PmpchangeManagement).HasColumnName("PMPChangeManagement");

                entity.Property(e => e.Pmpconstraints).HasColumnName("PMPConstraints");

                entity.Property(e => e.PmpmainLessonsLearnt).HasColumnName("PMPMainLessonsLearnt");

                entity.Property(e => e.PmpqualityManagement).HasColumnName("PMPQualityManagement");

                entity.Property(e => e.Pmpresults).HasColumnName("PMPResults");

                entity.Property(e => e.Pmpscope).HasColumnName("PMPScope");

                entity.HasOne(d => d.ApprovedByUser)
                    .WithMany(p => p.ProjectManagementPlan)
                    .HasForeignKey(d => d.ApprovedByUserId)
                    .HasConstraintName("FK_ProjectManagementPlan_UserApplication");

                entity.HasOne(d => d.OriginalPmplan)
                    .WithMany(p => p.InverseOriginalPmplan)
                    .HasForeignKey(d => d.OriginalPmplanId)
                    .HasConstraintName("FK_ProjectManagementPlan_OriginalPMPlan");
            });

            modelBuilder.Entity<Recurrence>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.RecurrenceDescription).HasMaxLength(500);

                entity.Property(e => e.RecurrenceName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.SectionCode).HasMaxLength(30);

                entity.Property(e => e.SectionDescription).HasMaxLength(150);

                entity.Property(e => e.SectionName).HasMaxLength(200);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Section_Unit");
            });

            modelBuilder.Entity<SettingType>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.SettingTypeDescription).HasMaxLength(150);

                entity.Property(e => e.SettingTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<SpdKeyOutput>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.SpdKeyOutputDescription).HasMaxLength(150);

                entity.Property(e => e.SpdKeyOutputName).HasMaxLength(150);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.SpdKeyOutput)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_SpdKeyOutput_AnnualWorkPlan");
            });

            modelBuilder.Entity<SpdObjective>(entity =>
            {
                entity.Property(e => e.Awpid).HasColumnName("AWPId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.SpdKeyOutputDescription).HasMaxLength(150);

                entity.Property(e => e.SpdObjectiveName).HasMaxLength(150);

                entity.HasOne(d => d.Awp)
                    .WithMany(p => p.SpdObjective)
                    .HasForeignKey(d => d.Awpid)
                    .HasConstraintName("FK_SpdObjective_AnnualWorkPlan");
            });

            modelBuilder.Entity<StorageDocument>(entity =>
            {
                entity.HasKey(e => e.StorageDocId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.StorageDocDescription).HasMaxLength(150);

                entity.Property(e => e.StorageDocName).HasMaxLength(150);

                entity.Property(e => e.StorageDocPath).HasMaxLength(300);

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.StorageDocument)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_StorageDocument_Expense");

                entity.HasOne(d => d.StorageDocType)
                    .WithMany(p => p.StorageDocument)
                    .HasForeignKey(d => d.StorageDocTypeId)
                    .HasConstraintName("FK_DocumentStorage_DocumentStorageType");
            });

            modelBuilder.Entity<StorageDocumentType>(entity =>
            {
                entity.HasKey(e => e.StorageDocTypeId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.StorageDocTypeDescription).HasMaxLength(150);

                entity.Property(e => e.StorageDocTypeName).HasMaxLength(150);
            });

            modelBuilder.Entity<Strategy>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Mawpid).HasColumnName("MAWPId");

                entity.Property(e => e.StartegyName).HasMaxLength(500);

                entity.Property(e => e.StrategyDescription).HasMaxLength(500);

                entity.HasOne(d => d.Mawp)
                    .WithMany(p => p.Strategy)
                    .HasForeignKey(d => d.Mawpid)
                    .HasConstraintName("FK_Strategy_MultiAnnualWorkPlan");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.Strategy)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK_Strategy_Target");
            });

            modelBuilder.Entity<StrategyMaplan>(entity =>
            {
                entity.HasKey(e => e.SmaplanId);

                entity.ToTable("StrategyMAPlan");

                entity.Property(e => e.SmaplanId).HasColumnName("SMAPlanId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.SmaplanDescription)
                    .HasColumnName("SMAPlanDescription")
                    .HasMaxLength(150);

                entity.Property(e => e.SmaplanEndYear)
                    .HasColumnName("SMAPlanEndYear")
                    .HasColumnType("date");

                entity.Property(e => e.SmaplanName)
                    .HasColumnName("SMAPlanName")
                    .HasMaxLength(50);

                entity.Property(e => e.SmaplanStartYear)
                    .HasColumnName("SMAPlanStartYear")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<SystemHelpText>(entity =>
            {
                entity.HasKey(e => e.HelpId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.HelpField).HasColumnType("nchar(50)");

                entity.Property(e => e.HelpText).HasColumnType("text");

                entity.Property(e => e.HelpTitle).HasColumnType("text");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TagDescription).HasMaxLength(500);

                entity.Property(e => e.TagName).HasMaxLength(500);
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TargetCode).HasMaxLength(20);

                entity.Property(e => e.TargetDescription).HasMaxLength(500);

                entity.Property(e => e.TargetName).HasMaxLength(200);

                entity.Property(e => e.TragetNameShort).HasMaxLength(200);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Target)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Target_Group");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TaskAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TaskDescription).HasMaxLength(500);

                entity.Property(e => e.TaskEndDate).HasColumnType("date");

                entity.Property(e => e.TaskGroupName).HasMaxLength(150);

                entity.Property(e => e.TaskMonitorStatusNote).HasColumnType("text");

                entity.Property(e => e.TaskName).HasMaxLength(500);

                entity.Property(e => e.TaskNote).HasColumnType("text");

                entity.Property(e => e.TaskStartDate).HasColumnType("date");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Task_Activity");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ExpenseId)
                    .HasConstraintName("FK_Task_Expense");

                entity.HasOne(d => d.ParentTask)
                    .WithMany(p => p.InverseParentTask)
                    .HasForeignKey(d => d.ParentTaskId)
                    .HasConstraintName("FK_Task_Task");

                entity.HasOne(d => d.TaskMon)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TaskMonId)
                    .HasConstraintName("FK_Task_TaskMonitoringStatus");

                entity.HasOne(d => d.TaskStatus)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.TaskStatusId)
                    .HasConstraintName("FK_Task_TaskStatus");

                entity.HasOne(d => d.UserIdAlocatedNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.UserIdAlocated)
                    .HasConstraintName("FK_Task_UserApplication");
            });

            modelBuilder.Entity<TaskMonitoringStatus>(entity =>
            {
                entity.HasKey(e => e.TaskMonId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TaskMonCode).HasMaxLength(10);

                entity.Property(e => e.TaskMonColor).HasMaxLength(20);

                entity.Property(e => e.TaskMonDescription).HasColumnType("text");

                entity.Property(e => e.TaskMonName).HasMaxLength(20);
            });

            modelBuilder.Entity<TaskResourceLink>(entity =>
            {
                entity.HasKey(e => e.TaskResId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TaskResNote).HasColumnType("text");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskResourceLink)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TaskResourceLink_Task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskResourceLink)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TaskResourceLink_UserApplication");
            });

            modelBuilder.Entity<TaskStatus>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TaskStatusDescription).HasMaxLength(150);

                entity.Property(e => e.TaskStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<TaskTemplate>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.TaskTemplateCode).HasMaxLength(20);

                entity.Property(e => e.TaskTemplateDescription).HasColumnType("text");

                entity.Property(e => e.TaskTemplateName).HasMaxLength(100);
            });

            modelBuilder.Entity<TaskTemplateItem>(entity =>
            {
                entity.HasKey(e => e.TtitemId);

                entity.Property(e => e.TtitemId).HasColumnName("TTItemId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.ParentTtitemId).HasColumnName("ParentTTItemId");

                entity.Property(e => e.TtitemBudget)
                    .HasColumnName("TTItemBudget")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TtitemDuration).HasColumnName("TTItemDuration");

                entity.Property(e => e.TtitemLevel).HasColumnName("TTItemLevel");

                entity.Property(e => e.TtitemName)
                    .HasColumnName("TTItemName")
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.TtitemSequence).HasColumnName("TTItemSequence");

                entity.HasOne(d => d.ParentTtitem)
                    .WithMany(p => p.InverseParentTtitem)
                    .HasForeignKey(d => d.ParentTtitemId)
                    .HasConstraintName("FK_TaskTemplateItem_TaskTemplateItem");

                entity.HasOne(d => d.TaskTemplate)
                    .WithMany(p => p.TaskTemplateItem)
                    .HasForeignKey(d => d.TaskTemplateId)
                    .HasConstraintName("FK_TaskTemplateItem_TaskTemplate");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.OldUnitCode).HasMaxLength(20);

                entity.Property(e => e.UnitCode).HasMaxLength(20);

                entity.Property(e => e.UnitDescription).HasMaxLength(150);

                entity.Property(e => e.UnitName).HasMaxLength(150);
            });

            modelBuilder.Entity<UserApplication>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.Dspid).HasColumnName("DSPId");

                entity.Property(e => e.UserEmail).HasMaxLength(150);

                entity.Property(e => e.UserFirstName).HasMaxLength(150);

                entity.Property(e => e.UserLastName).HasMaxLength(150);

                entity.Property(e => e.UserLoginName).HasMaxLength(100);

                entity.Property(e => e.UserOfficeNumber).HasMaxLength(100);

                entity.Property(e => e.UserPhoneMobile).HasMaxLength(50);

                entity.Property(e => e.UserPhoneOffice).HasMaxLength(50);

                entity.Property(e => e.UserPicture).HasColumnType("image");

                entity.HasOne(d => d.Dsp)
                    .WithMany(p => p.UserApplication)
                    .HasForeignKey(d => d.Dspid)
                    .HasConstraintName("FK_UserApplication_DSP1");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.UserApplication)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_UserApplication_Section");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.UserApplication)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_UserApplication_Unit");

                entity.HasOne(d => d.UserGrade)
                    .WithMany(p => p.UserApplication)
                    .HasForeignKey(d => d.UserGradeId)
                    .HasConstraintName("FK_UserApplication_UserGrade");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.UserApplicationUserRole)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_UserApplication_UserRole");

                entity.HasOne(d => d.UserRoleBis)
                    .WithMany(p => p.UserApplicationUserRoleIdBisNavigation)
                    .HasForeignKey(d => d.UserRoleIdBis)
                    .HasConstraintName("FK_UserApplication_UserRole1");
            });

            modelBuilder.Entity<UserExternalTool>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.HasOne(d => d.ExternalToolRole)
                    .WithMany(p => p.UserExternalTool)
                    .HasForeignKey(d => d.ExternalToolRoleId)
                    .HasConstraintName("FK_UserUtilitiesTool_UtilitiesType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExternalTool)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserUtilitiesTool_UserApplication");
            });

            modelBuilder.Entity<UserGrade>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.UserGradeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserGradeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateMod).HasColumnType("datetime");

                entity.Property(e => e.UserRoleDescription).HasMaxLength(150);

                entity.Property(e => e.UserRoleIsDspCoordinator).HasColumnName("UserRoleIsDSPCoordinator");

                entity.Property(e => e.UserRoleIsDspCoordinatorDeputy).HasColumnName("UserRoleIsDSPCoordinatorDeputy");

                entity.Property(e => e.UserRoleName).HasMaxLength(50);
            });
        }
    }
}
