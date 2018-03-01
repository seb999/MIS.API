using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Activity
    {
        public Activity()
        {
            ActiivityPerformanceIndicator = new HashSet<ActiivityPerformanceIndicator>();
            ActivityActivityLinkActivity = new HashSet<ActivityActivityLink>();
            ActivityActivityLinkActivityIdLinkedNavigation = new HashSet<ActivityActivityLink>();
            ActivityBudgetAbac = new HashSet<ActivityBudgetAbac>();
            ActivityDocument = new HashSet<ActivityDocument>();
            ActivityHistory = new HashSet<ActivityHistory>();
            ActivityMicrobiology = new HashSet<ActivityMicrobiology>();
            ActivityTag = new HashSet<ActivityTag>();
            ActivityUserApplicationCoreStaff = new HashSet<ActivityUserApplicationCoreStaff>();
            Dmsdocument = new HashSet<Dmsdocument>();
            Expense = new HashSet<Expense>();
            InverseActivityIdBfNavigation = new HashSet<Activity>();
            Note = new HashSet<Note>();
            Task = new HashSet<Task>();
        }

        public long ActivityId { get; set; }
        public long? ActivityIdBf { get; set; }
        public long? AWPId { get; set; }
        public long? StrategyId { get; set; }
        public long? StrategyIdSecondary { get; set; }
        public long? UnitId { get; set; }
        public long? DSPId { get; set; }
        public long? SectionId { get; set; }
        public long? KeyObjId { get; set; }
        public long? ProjectId { get; set; }
        public long? PriorityId { get; set; }
        public long? ActStatusId { get; set; }
        public long? ActAppStatusId { get; set; }
        public long? GroupActivityId { get; set; }
        public long? UserIdActivityLeader { get; set; }
        public long? UserIdResourceOfficer { get; set; }
        public long? UserIdAuthOfficer { get; set; }
        public long? ActivityReccurenceId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime? ActivityStartDate { get; set; }
        public DateTime? ActivityEndDate { get; set; }
        public decimal? ActivityBudgetCommitted { get; set; }
        public decimal? ActivityBudgetPaid { get; set; }
        public DateTime? ActivityNewTimeframeDate { get; set; }
        public bool? ActivityIsContinous { get; set; }
        public bool? ActivityIsDeleted { get; set; }
        public bool? ActivityIsForReview { get; set; }
        public bool? ActivityIsNotMonitored { get; set; }
        public string ActivityCodeSequence { get; set; }
        public string ActivityDelayReason { get; set; }
        public string ActivityImmediateAction { get; set; }
        public decimal? ActivityFtecat1 { get; set; }
        public decimal? ActivityFtecat2 { get; set; }
        public decimal? ActivityFtecat3 { get; set; }
        public decimal? ActivityFtecat4 { get; set; }
        public decimal? ActivityFtecat5 { get; set; }
        public decimal? ActivityFtecat6 { get; set; }
        public decimal? ActivityFtecat7 { get; set; }
        public decimal? ActivityFtecat8 { get; set; }
        public int? ActivityFulltimeEquivalent { get; set; }
        public string ActivityProgress { get; set; }
        public string ActivitySummaryNote { get; set; }
        public string ActivityMonitorNote { get; set; }
        public string ActivityBudgetNote { get; set; }
        public string ActivityTaskNote { get; set; }
        public string ActivityResourceNote { get; set; }
        public string ActivityNoteNote { get; set; }
        public string ActivityHighHighNote { get; set; }
        public string ActivityHighMediumNote { get; set; }
        public string ActivityHighLowNote { get; set; }
        public string ActivityMediumHighNote { get; set; }
        public string ActivityMediumMediumNote { get; set; }
        public string ActivityMediumLowNote { get; set; }
        public string ActivityLowHighNote { get; set; }
        public string ActivityLowMediumNote { get; set; }
        public string ActivityLowLowNote { get; set; }
        public string ActivityRiskNote { get; set; }
        public string ActivityAddedEuroValue { get; set; }
        public string ActivityProposedMethod { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public int? OldActivityId { get; set; }
        public long? OldUnitId { get; set; }
        public long? OldDspid { get; set; }
        public long? OldSectionId { get; set; }
        public bool? ActivityIsValidated { get; set; }
        public bool? ActivityIsIct { get; set; }
        public bool? ActivityIsPublicHealthTraining { get; set; }
        public bool? ActivityIsHealthCom { get; set; }
        public bool? ActivityIsPrepardness { get; set; }
        public bool? ActivityIsEnlargementCountries { get; set; }
        public bool? ActivityIsEnpCountries { get; set; }
        public bool? ActivityIsOtherThirdCountries { get; set; }
        public long? PlatoStatusId { get; set; }
        //public bool? ActivityIsRequested { get; set; }
        //public bool? ActivityIsApproved { get; set; }
        //public bool? ActivityIsRejected { get; set; }

        public ActivityApprovalStatus ActAppStatus { get; set; }
        public ActivityStatus ActStatus { get; set; }
        public Activity ActivityIdBfNavigation { get; set; }
        public ActivityRecurrence ActivityReccurence { get; set; }
        public AnnualWorkPlan Awp { get; set; }
        public Dsp Dsp { get; set; }
        public GroupActivity GroupActivity { get; set; }
        public KeyObjective KeyObj { get; set; }
        public PlatoStatus PlatoStatus { get; set; }
        public Priority Priority { get; set; }
        public Project Project { get; set; }
        public Section Section { get; set; }
        public Strategy Strategy { get; set; }
        public Strategy StrategyIdSecondaryNavigation { get; set; }
        public Unit Unit { get; set; }
        public UserApplication UserIdActivityLeaderNavigation { get; set; }
        public UserApplication UserIdAuthOfficerNavigation { get; set; }
        public UserApplication UserIdResourceOfficerNavigation { get; set; }
        public ICollection<ActiivityPerformanceIndicator> ActiivityPerformanceIndicator { get; set; }
        public ICollection<ActivityActivityLink> ActivityActivityLinkActivity { get; set; }
        public ICollection<ActivityActivityLink> ActivityActivityLinkActivityIdLinkedNavigation { get; set; }
        public ICollection<ActivityBudgetAbac> ActivityBudgetAbac { get; set; }
        public ICollection<ActivityDocument> ActivityDocument { get; set; }
        public ICollection<ActivityHistory> ActivityHistory { get; set; }
        public ICollection<ActivityMicrobiology> ActivityMicrobiology { get; set; }
        public ICollection<ActivityTag> ActivityTag { get; set; }
        public ICollection<ActivityUserApplicationCoreStaff> ActivityUserApplicationCoreStaff { get; set; }
        public ICollection<Dmsdocument> Dmsdocument { get; set; }
        public ICollection<Expense> Expense { get; set; }
        public ICollection<Activity> InverseActivityIdBfNavigation { get; set; }
        public ICollection<Note> Note { get; set; }
        public ICollection<Task> Task { get; set; }

        #region Not mapped

        [NotMapped]
        public string ActivityCode { get; set; }
        [NotMapped]
        public string ActivityLeader { get; set; }
        [NotMapped]
        public Nullable<decimal> TotalAmount { get; set; }
        [NotMapped]
        public string UserAddedFullName { get; set; }
        [NotMapped]
        public string UserModFullName { get; set; }

        //[NotMapped]delete this
        //public List<string> MyList { get; internal set; }

        #endregion
    }
}
