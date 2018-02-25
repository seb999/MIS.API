using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class GlobalSetting
    {
        public long GlobalSettingId { get; set; }
        public long? SettingTypeId { get; set; }
        public bool? GlobalSettingIsInactive { get; set; }
        public string GlobalSettingValue { get; set; }
        public string GlobalSettingDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public SettingType SettingType { get; set; }
    }
}
