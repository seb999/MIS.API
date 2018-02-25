using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class UserGrade : ILookupData
    {
        public UserGrade()
        {
            GradeCost = new HashSet<GradeCost>();
            UserApplication = new HashSet<UserApplication>();
        }

        public long UserGradeId { get; set; }
        public string UserGradeName { get; set; }
        public string UserGradeDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<GradeCost> GradeCost { get; set; }
        public ICollection<UserApplication> UserApplication { get; set; }

        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return UserGradeId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return UserGradeName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
