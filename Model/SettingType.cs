using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class SettingType
    {
        public SettingType()
        {
            GlobalSetting = new HashSet<GlobalSetting>();
        }

        public long SettingTypeId { get; set; }
        public string SettingTypeName { get; set; }
        public string SettingTypeDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<GlobalSetting> GlobalSetting { get; set; }
    }
}
