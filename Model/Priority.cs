using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Priority : ILookupData
    {
        public Priority()
        {
            Activity = new HashSet<Activity>();
        }

        public long PriorityId { get; set; }
        public string PriorityName { get; set; }
        public string PriorityDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }

        #region lookkup

        [NotMapped]
        public bool IsInactive { get; set; }

        [NotMapped]
        public string Text
        {
            get { return PriorityName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return PriorityId; }
            set { Value = value; }
        }

        #endregion
    }
}
