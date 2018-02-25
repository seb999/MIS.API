
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECDC.MIS.API.Misc
{
    public class LookupListItem
    {
        public string Text { get; set; }
        public long? Value { get; set; }
        public string ExtraData { get; set; }
        public string ExtraDataII { get; set; }
        public string ExtraDataIII { get; set; }
        public decimal Amount { get; set; }
        public decimal ValueDecimal { get; set; }
    }
}
