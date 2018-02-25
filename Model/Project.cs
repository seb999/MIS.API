using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Project
    {
        public Project()
        {
            Activity = new HashSet<Activity>();
        }

        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }
}
