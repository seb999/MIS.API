using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.DI;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.Misc;
using Microsoft.AspNetCore.Hosting;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class RequestExpenseController : Controller
    {
        private readonly MISContext misContext;
        private readonly List<UserApplication> userApplicationList;
        private readonly ILookupUser lookupUser;
        private readonly UserApplication currentUser;
        private readonly string defaultUserPictureUrl;

        public RequestExpenseController([FromServices]MISContext misContext, ILookupUser lookupUser, ILookupExpense lookupExpense, IHostingEnvironment server)
        {
            this.lookupUser = lookupUser;
            this.misContext = misContext;
            this.userApplicationList = lookupUser.UserApplicationList;
            this.currentUser = lookupUser.CurrentUser;
            defaultUserPictureUrl = server.WebRootPath + @"/images/DefaultUser.png";
        }

        #region Load data

        [HttpGet]
        [Route("GetExpense/{expenseId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ExpenseTransfer GetExpense(long expenseId){
             var query = misContext.Expense.AsNoTracking()
                .Include(p => p.Activity).AsNoTracking()
                .Include(p => p.Activity.Strategy).AsNoTracking()
                .Include(p => p.Activity.Unit).AsNoTracking()
                .Include(p => p.Activity.Dsp).AsNoTracking()
                .Include(p => p.ExpenseType).AsNoTracking()
                .Where(p => p.ExpenseId == expenseId)
                .Select(p => new ExpenseTransfer
               {
                    StartDate = p.ExpenseStartDate,
                    EndDate = p.ExpenseEndDate,
                    ExpenseId = p.ExpenseId,
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = p.Activity.ActivityId, ActivityCodeSequence = p.Activity.ActivityCodeSequence, Strategy = p.Activity.Strategy, Unit = p.Activity.Unit, Awp = p.Activity.Awp, Dsp = p.Activity.Dsp }),
                    ExpenseName = p.ExpenseName,
                    ExpenseTypeName = p.ExpenseType != null ? p.ExpenseType.ExpenseTypeName : null,
                    BudgetLineName = p.BudgetLine != null ? p.BudgetLine.BudgetLineName : null,
                    OrganiserPicture = SetUserPicture(p.UserIdOwner.GetValueOrDefault()),
                    Organiser = p.UserIdOwnerNavigation == null ? "" : p.UserIdOwnerNavigation.UserFirstName + " " + p.UserIdOwnerNavigation.UserLastName,
               });
              
              return query.FirstOrDefault();
        }

        [HttpGet]
        [Route("{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<ExpenseTransfer> Get(long awpId)
        {
            var query = misContext.Expense.AsNoTracking()
                .Include(p => p.Activity).AsNoTracking()
                .Include(p => p.Activity.Strategy).AsNoTracking()
                .Include(p => p.Activity.Unit).AsNoTracking()
                .Include(p => p.Activity.Dsp).AsNoTracking()
                .Include(p => p.ExpenseType).AsNoTracking()
                .Where(p => p.Activity.AWPId.GetValueOrDefault() == awpId)
                .Where(p => p.Activity.ActivityIsDeleted != true)
                .Where(p => p.Activity.ActivityIsValidated == true)
                .Where(p => p.ExpenseIsRequested == true).OrderByDescending(p => p.ExpenseId).ToList()
               .Select(expense => new
               {
                   expense.Activity,
                   expense.ExpenseId,
                   expense.ExpenseName,
                   expense.ExpenseType,
                   expense.ExpenseTypeId,
                   expense.ExpenseStartDate,
                   expense.ExpenseEndDate,
                   expense.ExpenseAmount,
               });

            List<ExpenseTransfer> expenseList = new List<ExpenseTransfer>();

            foreach (var item in query.ToList())
            {
                expenseList.Add(new ExpenseTransfer
                {
                    ExpenseId = item.ExpenseId,
                    ExpenseName = item.ExpenseName,
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = item.Activity.ActivityId, ActivityCodeSequence = item.Activity.ActivityCodeSequence, Strategy = item.Activity.Strategy, Unit = item.Activity.Unit, Awp = item.Activity.Awp, Dsp = item.Activity.Dsp }),
                    ActivityUnitId = item.Activity.UnitId.GetValueOrDefault(),
                    ActivityDpId = item.Activity.DSPId.GetValueOrDefault(),
                    ExpenseTypeId = item.ExpenseTypeId.GetValueOrDefault(),
                    ExpenseTypeName = item.ExpenseType !=null ? item.ExpenseType.ExpenseTypeName : null,
                    StartDate = item.ExpenseStartDate,
                    EndDate = item.ExpenseEndDate,
                    Amount = item.ExpenseAmount,
                });
            };
            return expenseList;
        }

        #endregion 

        #region helper

        public byte[] SetUserPicture(long userId)
        {
            byte[] picture = misContext.UserApplication.Where(p => p.UserId == userId).Select(p => p.UserPicture).FirstOrDefault();
            if (picture == null)
                return Helper.ImageToByte(defaultUserPictureUrl);

            return (picture);
        }

        #endregion
    }
}
