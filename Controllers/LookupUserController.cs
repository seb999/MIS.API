using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.DI;

namespace ECDC.MIS.API.Controllers
{

    [Route("api/[controller]")]
    
    public class LookupUserController : Controller
    {
        private readonly ILookupUser lookupUser;
        private readonly MISContext misContext;
        private readonly UserApplication currentUser;


        public LookupUserController([FromServices]MISContext misContext, ILookupUser lookupUser)
        {
            this.lookupUser = lookupUser;
            this.misContext = misContext;
            this.currentUser = lookupUser.CurrentUser;
        }

        /// <summary>
        /// Method to check user External user right (I.E :access procurement tool, access meeting tool)
        /// </summary>
        /// <param name="userAccess"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/[controller]/GetUserAuthorization/{userAccess}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public bool GetUserAuthorization(string userAccess)
        {
            if (currentUser.UserExternalTool != null)
            {
                foreach (var item in currentUser.UserExternalTool.Where(p => p.UserExternalToolIsDeleted != true))
                {
                    if (misContext.ExternalToolsRole.Where(p => p.ExternalToolRoleId == item.ExternalToolRoleId).Select(p => p.ExternalToolRoleName).FirstOrDefault() == userAccess)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("/api/[controller]/GetUserListWithPicture")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<UserApplication> GetUserListWithPicture()
        {
            return lookupUser.UserApplicationList;
        }

        [HttpGet]
        [Route("/api/[controller]/GetUserListWithNoPicture")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<UserApplication> GetUserListWithNoPicture()
        {
            return lookupUser.UserApplicationNoPictureList;
        }

        [HttpGet]
        [Route("/api/[controller]/GetCurrentUser")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public UserApplication GetCurrentUser()
        {
            return currentUser;
        }

        /// <summary>
        /// get user right for a specific activityId
        /// </summary>
        /// <param name="activityId">The activityId</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/[controller]/GetUserMaxOperationMode/{activityId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public string GetUserMaxOperationMode(long activityId)
        {
            Activity selectedActivity = misContext.Activity.Include(a=>a.ActAppStatus).Where(p => p.ActivityId == activityId).FirstOrDefault();
            if (selectedActivity == null) return OperationMode.View.ToString();

            if (currentUser.UserId == 0 || currentUser.UnitId == null || currentUser.UnitId == 0)
            {
                return OperationMode.View.ToString();
            }

            bool isDefaultCrieria = false;

            if (selectedActivity.ActivityUserApplicationCoreStaff.Where(p => p.UserId == currentUser.UserId).Select(p => p).FirstOrDefault() != null
                   || selectedActivity.UserIdActivityLeader == currentUser.UserId
                   || selectedActivity.UserAdded == currentUser.UserId)
            {
                isDefaultCrieria = true;
            }

            if (currentUser.UserRole.UserRoleIsNone.GetValueOrDefault() || currentUser.UserRole.UserRoleId == 0)
            {
                if (isDefaultCrieria)
                {
                    if (selectedActivity.ActAppStatus.ActAppStatusIsDraft.GetValueOrDefault())
                    {
                        return OperationMode.Edit.ToString();
                    }
                    else
                    {
                        return OperationMode.PartialEdit.ToString();
                    }
                }

                return OperationMode.View.ToString();
            }

            // It is only valid for the roles below to have no DSP
            if ((currentUser.Dspid == null && (currentUser.UserRole.UserRoleIsDspCoordinator.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsDspCoordinator.GetValueOrDefault()))
                || (currentUser.Dspid == null && (currentUser.UserRole.UserRoleIsDspCoordinatorDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsDspCoordinatorDeputy.GetValueOrDefault()))
                || (currentUser.SectionId == null && (currentUser.UserRole.UserRoleIsHeadOfSection.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfSection.GetValueOrDefault())))
            {
                return OperationMode.View.ToString();
            }

            if (currentUser.UserRole.UserRoleIsHeadOfSection.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfSection.GetValueOrDefault())
            {
                if (selectedActivity.SectionId != currentUser.SectionId && !isDefaultCrieria)
                {
                    return OperationMode.View.ToString();
                }

                if (selectedActivity.ActAppStatus.ActAppStatusIsDraft.GetValueOrDefault())
                {
                    return OperationMode.Edit.ToString();
                }
                else
                {
                    return OperationMode.PartialEdit.ToString();
                }
            }

            if (currentUser.UserRole.UserRoleIsDspCoordinator.GetValueOrDefault() || currentUser.UserRole.UserRoleIsDspCoordinatorDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsDspCoordinator.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsDspCoordinatorDeputy.GetValueOrDefault())
            {
                if (selectedActivity.DSPId != currentUser.Dspid && !isDefaultCrieria)
                {
                    return OperationMode.View.ToString();
                }

                if (selectedActivity.ActAppStatus.ActAppStatusIsDraft.GetValueOrDefault())
                {
                    return OperationMode.Edit.ToString();
                }
                else
                {
                    return OperationMode.PartialEdit.ToString();
                }
            }

            if (currentUser.UserRole.UserRoleIsHeadOfUnit.GetValueOrDefault() || currentUser.UserRole.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnit.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault())
            {
                if (selectedActivity.UnitId != currentUser.UnitId)
                {
                    if (isDefaultCrieria)
                    {
                        if (selectedActivity.ActAppStatus.ActAppStatusIsDraft.GetValueOrDefault())
                        {
                            return OperationMode.Edit.ToString();
                        }
                        else
                        {
                            return OperationMode.PartialEdit.ToString();
                        }
                    }
                    else
                    {
                        return OperationMode.View.ToString();
                    }
                }

                if (selectedActivity.ActAppStatus.ActAppStatusIsHos.GetValueOrDefault() || selectedActivity.ActAppStatus.ActAppStatusIsDraft.GetValueOrDefault())
                {
                    return OperationMode.Edit.ToString();
                }
                else
                {
                    return OperationMode.PartialEdit.ToString();
                }
            }

            if (currentUser.UserRole.UserRoleIsExecutive.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsExecutive.GetValueOrDefault())
            {
                if (selectedActivity.ActAppStatus.ActAppStatusIsHos.GetValueOrDefault() || selectedActivity.ActAppStatus.ActAppStatusIsDraft.GetValueOrDefault() || selectedActivity.ActAppStatus.ActAppStatusIsHou.GetValueOrDefault())
                {
                    return OperationMode.Edit.ToString();
                }
                else
                {
                    return OperationMode.PartialEdit.ToString();
                }
            }

            if (currentUser.UserRole.UserRoleIsPlanningMonitoring.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsPlanningMonitoring.GetValueOrDefault())
            {
                return OperationMode.Edit.ToString();
            }

            return OperationMode.View.ToString();
        }
    }

}
