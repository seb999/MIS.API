using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Microbiology
    {
        public Microbiology()
        {
            ActivityMicrobiology = new HashSet<ActivityMicrobiology>();
        }

        public long MicroId { get; set; }
        public string MicroName { get; set; }
        public string MicroDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<ActivityMicrobiology> ActivityMicrobiology { get; set; }
    }
}
