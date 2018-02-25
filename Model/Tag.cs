using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class Tag : ILookupData
    {
        public Tag()
        {
            ActivityTag = new HashSet<ActivityTag>();
        }

        public long TagId { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public bool? TagIsDeleted { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<ActivityTag> ActivityTag { get; set; }

        #region Lookup

        [NotMapped]
        public bool IsInactive
        {
            get { return TagIsDeleted.GetValueOrDefault(); }
            set { IsInactive = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return TagName; }
            set { Text = value; }
        }

        [NotMapped]
        public long Value
        {
            get { return TagId; }
            set { Value = value; }
        }

        #endregion
    }
}
