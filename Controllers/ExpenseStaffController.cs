using System;
using System.Collections.Generic;
using System.Linq;
using ECDC.MIS.API.DI;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.TransferClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class ExpenseStaffController : Controller
    {
        private readonly MISContext misContext;
        private readonly UserApplication currentUser;
        private readonly string defaultUserPictureUrl;
        // private readonly ILookupActivity lookupActivity;

        //public ExpenseStaffController([FromServices]MISContext misContext, ILookupActivity lookupActivity)
        public ExpenseStaffController([FromServices]MISContext misContext, ILookupUser lookupUser, IHostingEnvironment server)
        {
            this.misContext = misContext;
            this.currentUser = lookupUser!=null ? lookupUser.CurrentUser: null;
            this.defaultUserPictureUrl = server.WebRootPath + @"\images\DefaultUser.png";
            // this.lookupActivity = lookupActivity;
        }

        /// <summary>
        /// Return list of ExpenseStaff for an ExpenseId
        /// </summary>
        /// <param name="expenseId">The expenseId</param>
        /// <returns>The list of expenseStaff</returns>
        public List<ExpenseStaffTransfer> GetExpenseStaffList(long expenseId)
        {
            var query = from expenseStaff in misContext.ExpenseStaff
                        .Include(p => p.UserApplication)
                        .Where(p => p.ExpenseId == expenseId).ToList()
                        .Where(p=>p.ExpenseStaffIsHoUValidation == true)
                        select new ExpenseStaffTransfer()
                        {
                            StaffName = expenseStaff.UserApplication == null ? "" : expenseStaff.UserApplication.UserFirstName + " " + expenseStaff.UserApplication.UserLastName,
                            StaffId = expenseStaff.UserId.GetValueOrDefault(),
                            RequestedDay = expenseStaff.ExpenseStaffRequestedDay,
                            RequestedFte = Math.Round(expenseStaff.ExpenseStaffRequestedDay.GetValueOrDefault() / 160, 2),
                            PlanDay = expenseStaff.ExpenseStaffPlanDay,
                            PlanFte = expenseStaff.ExpenseStaffPlanFte,
                            ActualDay = expenseStaff.ExpenseStaffActualDay,
                            ActualFte = expenseStaff.ExpenseStaffActualFte,
                            IsPriority = expenseStaff.ExpenseStaffIsPriority,
                            StaffPicture = Helper.SetUserPicture(expenseStaff.UserApplication, defaultUserPictureUrl),
                        };
            return query.OrderBy(p=>p.StaffName).ToList();
        }

        //public byte[] SetUserPicture(long userId)
        //{
        //    byte[] picture = misContext.UserApplication.Where(p => p.UserId == userId).Select(p => p.UserPicture).FirstOrDefault();
        //    if (picture == null)
        //        //return Helper.ImageToByte(defaultUserPictureUrl);
        //        return null;

        //    return (picture);
        //}


        /// <summary>
        /// Return list of ExpenseStaff for a userId, used in Request FTE
        /// </summary>
        /// <param name="awpId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetExpenseSatff/{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<ExpenseStaffTransfer> GetExpenseSatff(long awpId)
        {
            return Get(awpId, currentUser.UserId);
        }

        /// <summary>
        /// Return list of ExpenseStaff for a userId, used in Request FTE
        /// </summary>
        /// <param name="awpId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{awpId}/{userId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<ExpenseStaffTransfer> Get(long awpId, long userId)
        {

            //List<LookupListItem> ActivityCodeList = lookupActivity.GetLookupActivity(awpId);

            var query = from expenseStaff in misContext.ExpenseStaff
                        .Include(p => p.UserApplication)
                        .Include(p => p.Expense).ThenInclude(p => p.Activity)
                        .Where(p => p.Expense.Activity.AWPId.GetValueOrDefault() == awpId)
                        .Where(p => (userId==0) || p.UserApplication.UserId == userId)
                        .Where(p => p.Expense.Activity.ActivityIsDeleted.GetValueOrDefault() != true)
                        .Where(p => p.Expense.Activity.ActivityIsValidated.GetValueOrDefault() == true).ToList()
                        select new ExpenseStaffTransfer()
                        {
                            StaffName = expenseStaff.UserApplication == null ? "" : expenseStaff.UserApplication.UserFirstName + " " + expenseStaff.UserApplication.UserLastName,
                            StaffId = expenseStaff.UserId.GetValueOrDefault(),
                            PlanDay = expenseStaff.ExpenseStaffPlanDay,
                            PlanFte = expenseStaff.ExpenseStaffPlanFte,
                            ActualDay = expenseStaff.ExpenseStaffActualDay,
                            ActualFte = expenseStaff.ExpenseStaffActualFte,
                            ActivityName = expenseStaff.Expense.Activity.ActivityName,
                            ExpenseName = expenseStaff.Expense.ExpenseName,
                           // ActivityCode = ActivityCodeList.Where(p => p.Value == expenseStaff.Expense.ActivityId).Select(p => p.Text).FirstOrDefault(),
                            ActivityId = expenseStaff.Expense.ActivityId
                        };
            return query.ToList();
        }

    }
}
