using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class GroupActivity : ILookupData
    {
        public GroupActivity()
        {
            Activity = new HashSet<Activity>();
        }

        public long GroupActivityId { get; set; }
        public long? Awpid { get; set; }
        public string GroupActivityCode { get; set; }
        public string GroupActivityName { get; set; }
        public string GroupActivityDescription { get; set; }
        public bool? GroupActivityIsDeleted { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public ICollection<Activity> Activity { get; set; }

        #region lookkup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return GroupActivityName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return GroupActivityId; }
            set { Value = value; }
        }

        #endregion
    }
}
