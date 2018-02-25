using Microsoft.AspNetCore.Mvc;
using ECDC.MIS.API.DI;
using ECDC.MIS.API.Misc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ECDC.MIS.API.Controllers
{
   
    [Route("/api/[controller]")]
    public class LookupListController : Controller
    {
        private ILookupRepository LookupRepository { get; set; }
        private IMemoryCache memoryCache;

        public LookupListController(IMemoryCache memoryCache, ILookupRepository lookupRepository)
        {
            this.memoryCache = memoryCache;
            LookupRepository = lookupRepository;
        }

        [HttpGet]
        [Route("")]
        public ILookupRepository Get()
        {
            return LookupRepository;
        }

        [HttpGet]
        [Route("clearCache")]
        public bool ClearCache()
        {
            CacheHelper.ClearLookupCache(memoryCache);
            Response.Clear();
            return true;
        }
    }
}
