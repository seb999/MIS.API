using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class UserExternalTool
    {
        public long UserExternalToolId { get; set; }
        public long? UserId { get; set; }
        public long? ExternalToolRoleId { get; set; }
        public bool? UserExternalToolIsDeleted { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ExternalToolsRole ExternalToolRole { get; set; }
        public UserApplication User { get; set; }
    }
}
