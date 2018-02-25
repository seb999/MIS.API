using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Section : ILookupData
    {
        public Section()
        {
            Activity = new HashSet<Activity>();
            UserApplication = new HashSet<UserApplication>();
        }

        public long SectionId { get; set; }
        public long? UnitId { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public string SectionDescription { get; set; }
        public bool? SectionIsInactive { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Unit Unit { get; set; }
        public ICollection<Activity> Activity { get; set; }
        public ICollection<UserApplication> UserApplication { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return SectionId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return SectionCode; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive
        {
            get { return SectionIsInactive.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        #endregion
    }
}
