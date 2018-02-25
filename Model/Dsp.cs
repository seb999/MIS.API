using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Dsp : ILookupData
    {
        public Dsp()
        {
            Activity = new HashSet<Activity>();
            DashBudget = new HashSet<DashBudget>();
            DashLinkAbacmis = new HashSet<DashLinkAbacmis>();
            DashLinkMissionMis = new HashSet<DashLinkMissionMis>();
            DashMeetingTemp = new HashSet<DashMeetingTemp>();
            DashMission = new HashSet<DashMission>();
            DashTempDeliverables = new HashSet<DashTempDeliverables>();
            UserApplication = new HashSet<UserApplication>();
        }

        public long DspId { get; set; }
        public string DspCode { get; set; }
        public string Dspname { get; set; }
        public string DspDescription { get; set; }
        public bool? DspIsCore { get; set; }
        public int? DspSortSequence { get; set; }
        public bool? DspIsInactive { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
        public ICollection<DashBudget> DashBudget { get; set; }
        public ICollection<DashLinkAbacmis> DashLinkAbacmis { get; set; }
        public ICollection<DashLinkMissionMis> DashLinkMissionMis { get; set; }
        public ICollection<DashMeetingTemp> DashMeetingTemp { get; set; }
        public ICollection<DashMission> DashMission { get; set; }
        public ICollection<DashTempDeliverables> DashTempDeliverables { get; set; }
        public ICollection<UserApplication> UserApplication { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return DspId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return DspCode; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
