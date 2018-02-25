using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class MeetingStatus : ILookupData
    {
        public MeetingStatus()
        {
            Expense = new HashSet<Expense>();
        }

        public long MeetingStatusId { get; set; }
        public string MeetingStatusName { get; set; }
        public string MeetingStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Expense> Expense { get; set; }

        #region Lookup

        [NotMapped]
        public string Text
        {
            get { return MeetingStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return MeetingStatusId; }
            set { Value = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
