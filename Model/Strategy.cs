using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Strategy : ILookupData
    {
        public Strategy()
        {
            ActivityStrategy = new HashSet<Activity>();
            ActivityStrategyIdSecondaryNavigation = new HashSet<Activity>();
        }

        public long StrategyId { get; set; }
        public long? Mawpid { get; set; }
        public long? TargetId { get; set; }
        public string StartegyName { get; set; }
        public string StrategyDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public MultiAnnualWorkPlan Mawp { get; set; }
        public Target Target { get; set; }
        public ICollection<Activity> ActivityStrategy { get; set; }
        public ICollection<Activity> ActivityStrategyIdSecondaryNavigation { get; set; }

        #region lookkup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return StartegyName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return StrategyId; }
            set { Value = value; }
        }

        #endregion
    }
}
