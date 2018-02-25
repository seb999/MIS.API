using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Unit : ILookupData
    {
        public Unit()
        {
            Activity = new HashSet<Activity>();
            BudgetThreeBucket = new HashSet<BudgetThreeBucket>();
            DashBudget = new HashSet<DashBudget>();
            DashLinkAbacmis = new HashSet<DashLinkAbacmis>();
            DashLinkMissionMis = new HashSet<DashLinkMissionMis>();
            DashMeetingTemp = new HashSet<DashMeetingTemp>();
            DashMission = new HashSet<DashMission>();
            DashTempDeliverables = new HashSet<DashTempDeliverables>();
            Section = new HashSet<Section>();
            UserApplication = new HashSet<UserApplication>();
        }

        public long UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }
        public bool? UnitIsInactive { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public string OldUnitCode { get; set; }

        public ICollection<Activity> Activity { get; set; }
        public ICollection<BudgetThreeBucket> BudgetThreeBucket { get; set; }
        public ICollection<DashBudget> DashBudget { get; set; }
        public ICollection<DashLinkAbacmis> DashLinkAbacmis { get; set; }
        public ICollection<DashLinkMissionMis> DashLinkMissionMis { get; set; }
        public ICollection<DashMeetingTemp> DashMeetingTemp { get; set; }
        public ICollection<DashMission> DashMission { get; set; }
        public ICollection<DashTempDeliverables> DashTempDeliverables { get; set; }
        public ICollection<Section> Section { get; set; }
        public ICollection<UserApplication> UserApplication { get; set; }

        #region lookkup

        [NotMapped]
        public bool IsInactive
        {
            get { return UnitIsInactive.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return UnitCode; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return UnitId; }
            set { Value = value; }
        }

        #endregion
    }
}
