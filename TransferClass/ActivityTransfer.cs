using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.TransferClass
{
    public class ActivityTransfer
    {
        public string ActivityCode { get; set; }
        public string ActivityDescription { get; set; }
        public long ActivityId { get; set; }
        public string ActivityLeader { get; set; }
        public string ActivityName { get; set; }
        public decimal? Amount { get; set; }
        public long AwpId { get; set; }
        public object AwpName { get; set; }
        public string CapacityLevel { get; internal set; }
        public DateTime? DateAdded { get; set; }
        public string DpCode { get; set; }
        public long DpId { get; set; }
        public DateTime? EndDate { get; set; }
        public string FunctionalGroup { get; internal set; }
        public string Project { get; internal set; }
        public string SectionCode { get; set; }
        public long SectionId { get; set; }
        public DateTime? StartDate { get; set; }
        public string StatusIcon { get; set; }
        public long? StatusId { get; set; }
        public string StatusName { get; set; }
        public string StrategyCode { get; set; }
        public long StrategyId { get; set; }
        public string UnitCode { get; set; }
        public long UnitId { get; set; }

        public List<ExpenseTransfer> ExpenseList { get; set; }
        public byte[] ActivityLeaderPicture { get; set; }

        public List<long> CoreStaffIds { get; set; }
        public long? ActivityLeaderId { get; set; }
        public string UserMod { get; set; }
        public long? FunctionalGroupId { get; set; }
        public bool? IsPublicHealthTraining { get; set; }
        public bool? IsPrepardness { get; set; }
        public bool? IsICT { get; set; }
        public bool? IsMicrobiology { get; set; }
        public bool? IsEnlargementCountries { get; set; }
        public bool? IsEnpCountries { get; set; }
        public bool? IsOtherThirdCountries { get; set; }
        public bool? IsHealthCom { get; set; }
        public string UserAdded { get; set; }
        public string ActivityIdName { get; set; }
        public long? CapacityLevelId { get; set; }
    }
}
