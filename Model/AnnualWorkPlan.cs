using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class AnnualWorkPlan : ILookupData
    {
        public AnnualWorkPlan()
        {
            Activity = new HashSet<Activity>();
            AllegroImport = new HashSet<AllegroImport>();
            BudgetConstant = new HashSet<BudgetConstant>();
            ConstantFte = new HashSet<ConstantFte>();
            DashBudget = new HashSet<DashBudget>();
            DashMeetingTemp = new HashSet<DashMeetingTemp>();
            DashMission = new HashSet<DashMission>();
            DashVacRate = new HashSet<DashVacRate>();
            FunctionParticipant = new HashSet<FunctionParticipant>();
            GradeCost = new HashSet<GradeCost>();
            GroupActivity = new HashSet<GroupActivity>();
            MeetingBudgetAbac = new HashSet<MeetingBudgetAbac>();
            ProcessProjectSub = new HashSet<ProcessProjectSub>();
            ProcurementFinancingDecision = new HashSet<ProcurementFinancingDecision>();
            SpdKeyOutput = new HashSet<SpdKeyOutput>();
            SpdObjective = new HashSet<SpdObjective>();
        }

        public long Awpid { get; set; }
        public long? StrategyId { get; set; }
        public DateTime? Awpyear { get; set; }
        public string AWPName { get; set; }
        public string Awpdescription { get; set; }
        public long? Mawpid { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
        public ICollection<AllegroImport> AllegroImport { get; set; }
        public ICollection<BudgetConstant> BudgetConstant { get; set; }
        public ICollection<ConstantFte> ConstantFte { get; set; }
        public ICollection<DashBudget> DashBudget { get; set; }
        public ICollection<DashMeetingTemp> DashMeetingTemp { get; set; }
        public ICollection<DashMission> DashMission { get; set; }
        public ICollection<DashVacRate> DashVacRate { get; set; }
        public ICollection<FunctionParticipant> FunctionParticipant { get; set; }
        public ICollection<GradeCost> GradeCost { get; set; }
        public ICollection<GroupActivity> GroupActivity { get; set; }
        public ICollection<MeetingBudgetAbac> MeetingBudgetAbac { get; set; }
        public ICollection<ProcessProjectSub> ProcessProjectSub { get; set; }
        public ICollection<ProcurementFinancingDecision> ProcurementFinancingDecision { get; set; }
        public ICollection<SpdKeyOutput> SpdKeyOutput { get; set; }
        public ICollection<SpdObjective> SpdObjective { get; set; }

        #region Lookup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return AWPName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return Awpid; }
            set { Value = value; }
        }

        #endregion
    }
}
