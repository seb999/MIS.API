using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.Misc;

namespace ECDC.MIS.API.DI
{
    public interface ILookupUser
    {
        UserApplication CurrentUser { get; set; }
        List<UserApplication> UserApplicationFullList { get; set; }
        List<UserApplication> UserApplicationList { get; set; }
        List<UserApplication> UserApplicationNoPictureList { get; set; }
    }

    public class LookupUser : ILookupUser
    {
        private IMemoryCache memoryCache;

        #region properties

        public UserApplication CurrentUser { get; set; }
        public List<UserApplication> UserApplicationFullList { get; set; }
        public List<UserApplication> UserApplicationList { get; set; }
        public List<UserApplication> UserApplicationNoPictureList { get; set; }
        string defaultUserPictureUrl = "";

        #endregion

        //Dipendency Injection for Http Context is not working
        //public LookupUser(MISContext misContext, IMemoryCache memoryCache, HttpContext httpContext, IHostingEnvironment server)
        public LookupUser(MISContext misContext, IMemoryCache memoryCache, IHostingEnvironment server)
        {
            this.memoryCache = memoryCache;
            HttpContext httpContext = new HttpContextAccessor().HttpContext;

            defaultUserPictureUrl = server.WebRootPath + @"/images/DefaultUser.png";

            //Get current user
            string userName = GetCurrentUserLoginName(httpContext);
            if (userName == "") return;
            CurrentUser = GetUserDetails(misContext, userName);
            //TODO : why this methid is so slow ??

            //Get list userApplication active and inactive (no picture)
             UserApplicationFullList = GetUserApplicationList(misContext);

            //Get list of active userApplication with picture
            UserApplicationList = GetActiveUserApplicationList(misContext);

            //Get list of active userApplication (no picture)
            UserApplicationNoPictureList = GetActiveUserApplicationNoPictureList(misContext);
        }

        #region Get User methods

        private static string GetCurrentUserLoginName(HttpContext httpContextAccessor)
        {
          
            string userName = httpContextAccessor.User.Identity.Name;
            if (userName != null)
            {
                userName = userName.Replace(@"\\", @"\");
                string[] nameSplit = userName.Split('\\');
                userName = nameSplit[1];
                return userName;
            }
            else return "SDubos";
        }

        private UserApplication GetUserDetails(MISContext MISContext, string userName)
        {
            var currentUser = MISContext.UserApplication.AsNoTracking()
                    .Include(p=>p.UserExternalTool).AsNoTracking()
                    .Include(p => p.UserRole).AsNoTracking()
                    .Include(p => p.UserRoleBis).AsNoTracking()
                    .Include(p => p.UserGrade).AsNoTracking()
                    .Include(p => p.Unit).AsNoTracking()
                    .Include(p => p.Dsp).AsNoTracking()
                    .Include(p => p.Section).AsNoTracking()
                    .Where(p => p.UserLoginName == userName)
                    .Where(p => SetUserDefaultPic(p)).FirstOrDefault();

            //If user is not in UserApplication table
            if (currentUser == null) return null;

            if (currentUser.UserRoleBis == null)
                currentUser.UserRoleBis = new UserRole();

            if (currentUser.UserRole == null)
                currentUser.UserRole = MISContext.UserRole.Where(p => p.UserRoleName == "N/A").FirstOrDefault();

            if (currentUser.UserGrade == null)
                currentUser.UserGrade = MISContext.UserGrade.Where(p => p.UserGradeName == "N/A").FirstOrDefault();

            return currentUser;
        }
       
        private List<UserApplication> GetUserApplicationList(MISContext context)
        {
            List<UserApplication> cached;

            if (!memoryCache.TryGetValue(typeof(UserApplication).Name + "FullList", out cached))
            {
                cached = context.UserApplication.AsNoTracking().ToList();
                cached.Insert(0, new UserApplication() { UserId = 0, UserFirstName = "--" });

                memoryCache.Set(typeof(UserApplication).Name + "FullList", cached);
            }

            return cached;
        }

        private List<UserApplication> GetActiveUserApplicationNoPictureList(MISContext context)
        {
            List<UserApplication> cached;

            if (!memoryCache.TryGetValue(typeof(UserApplication).Name + "WithNoPicture", out cached))
            {
                cached = context.UserApplication.AsNoTracking()
                    .Where(p => SetNoPicture(p))
                    .Where(p => p.UserIsInactive != true).ToList();

                cached.Insert(0, new UserApplication() { UserId = 0, UserFirstName = "--" });
                memoryCache.Set(typeof(UserApplication).Name + "WithNoPicture", cached);
            }

            return cached;
        }

        private List<UserApplication> GetActiveUserApplicationList(MISContext context)
        {
            List<UserApplication> cached;

            if (!memoryCache.TryGetValue(typeof(UserApplication).Name + "WithPicture", out cached))
            {
                cached = context.UserApplication.AsNoTracking()
                    .Where(p => SetUserDefaultPic(p))
                    .Where(p => p.UserIsInactive != true).ToList();
                    
                cached.Insert(0, new UserApplication() { UserId = 0, UserFirstName = "--" });
                SetUserDefaultPic(cached[0]);

                memoryCache.Set(typeof(UserApplication).Name + "WithPicture", cached);
            }

            return cached;
        }

        private bool SetNoPicture(UserApplication p)
        {
            p.UserPicture = null;
            return true;
        }

        #endregion

        #region helper

        private bool SetUserDefaultPic(UserApplication userApplication)
        {
            if (userApplication.UserPicture == null)
            {
                byte[] cached;

                if (!memoryCache.TryGetValue("UserDefaultPicture", out cached))
                {
                    cached = Helper.ImageToByte(defaultUserPictureUrl);
                }

                memoryCache.Set("UserDefaultPicture", cached);
                userApplication.UserPicture = cached;
            }
            return true;
        }

        #endregion
    }
}
