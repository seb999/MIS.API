using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class DashExternalPath
    {
        public int DashExternalPathId { get; set; }
        public string DashExternalPathAccessType { get; set; }
        public string DashExternalPathToFile { get; set; }
        public string DashExternalPathFileName { get; set; }
        public string DashExternalPathSheetName { get; set; }
        public string DashExternalPathSave { get; set; }
    }
}
