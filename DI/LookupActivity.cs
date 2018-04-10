using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.Model;

namespace ECDC.MIS.API.DI
{
    public interface ILookupActivity
    {
        List<LookupListItem> ActivityLookupList { get; set; }

        List<LookupListItem> GetLookupActivity(long awpId);
    }

    public class LookupActivity : ILookupActivity
    {
        private readonly MISContext misContext;
        private readonly IMemoryCache memoryCache;
        public List<LookupListItem> ActivityLookupList { get; set; }

        public LookupActivity(MISContext misContext, IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.misContext = misContext;
        }
        public List<LookupListItem> GetLookupActivity(long awpId)
        {

            List<LookupListItem> cached = new List<LookupListItem>();

            //Get list to be cache
            return (from item in misContext.Activity
                        .Include(p => p.Awp)
                        .Include(p => p.Strategy)
                        .Include(p => p.Unit)
                        .Include(p => p.Dsp)
                        .Where(p=>p.AWPId == awpId)
                        .Where(p => p.ActivityIsDeleted != true)
                        .Where(p => p.ActivityIsValidated == true)
                          select new LookupListItem()
                          {
                              Text = GetActivityCode(item),
                              Value = item.ActivityId,
                              ExtraData = item.AWPId.ToString(),
                              ExtraDataII = item.ActivityName
                          }).ToList();
        }

        #region helper

        public string GetActivityCode(Activity p)
        {
            return Helper.GetCode(p);
        }

        #endregion
    }
}
