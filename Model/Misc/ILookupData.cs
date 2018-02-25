using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public interface ILookupData
    {
        [NotMapped]
        long Value { get; set; }
        [NotMapped]
        string Text { get; set; }
        [NotMapped]
        bool IsInactive { get; set; }
    }
}