using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExternalToolsRole
    {
        public ExternalToolsRole()
        {
            UserExternalTool = new HashSet<UserExternalTool>();
        }

        public long ExternalToolRoleId { get; set; }
        public string ExternalToolRoleName { get; set; }
        public string ExternalToolRoleDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<UserExternalTool> UserExternalTool { get; set; }
    }
}
