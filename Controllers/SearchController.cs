using ECDC.MIS.API.Misc;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.TransferClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly MISContext misContext;

        public SearchController([FromServices]MISContext misContext)
        {
            this.misContext = misContext;
        }

        [HttpGet]
        [Route("searchActivity/{searchString}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<SearchTransfer> searchActivity(string searchString)
        {
            var query = from activity in misContext.Activity
               .Include(p => p.Strategy)
               .Include(p => p.Unit)
               .Include(p => p.Dsp)
               .Include(p => p.Awp).ToList()
                        where activity.UnitId != null
                        && activity.Dsp != null
                        && !activity.ActivityIsDeleted.GetValueOrDefault()
                        && activity.ActivityIsValidated.GetValueOrDefault()

                        select new SearchTransfer
                        {
                            ActivityId = activity.ActivityId,
                            ActivityIdString = activity.ActivityId.ToString(),
                            ActivityCode = Helper.GetCode(new Activity() { ActivityId = activity.ActivityId, ActivityCodeSequence = activity.ActivityCodeSequence, Strategy = activity.Strategy, Unit = activity.Unit, Awp = activity.Awp, Dsp = activity.Dsp }),
                            ActivityName = activity.ActivityName,
                            ActivityDescription = activity.ActivityDescription != null ? activity.ActivityDescription : "",
                            Year = activity.Awp.AWPName,
                        };

            var queryInterim = query.ToList().AsQueryable();
            Expression<Func<SearchTransfer, bool>> filter = GetSearchFilter(searchString);

            List<SearchTransfer> result = queryInterim.Where(filter).ToList().Where(p => HighLightSearchString(p, searchString)).OrderByDescending(p => p.ActivityId).ToList();
            return result;
        }

        [HttpGet]
        [Route("searchExpense/{searchString}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<SearchTransfer> searchExpense(string searchString)
        {
            var query = from expense in misContext.Expense
                        .Include(p => p.ExpenseType)
                        .Include(p => p.Activity)
                        .Include(p => p.Activity.Awp)
                        where expense.Activity.ActivityIsDeleted != true
                        && expense.Activity.ActivityIsValidated.GetValueOrDefault()

                        select new SearchTransfer
                        {
                            ActivityId = expense.ActivityId.GetValueOrDefault(),
                            ExpenseId = expense.ExpenseId,
                            ExpenseIdString = expense.ExpenseId.ToString(),
                            ExpenseName = expense.ExpenseName != null ? expense.ExpenseName : "",
                            ActivityName = expense.Activity.ActivityName,
                            Year = expense.Activity.Awp.AWPName,
                            ExpenseType = expense.ExpenseType
                        };

            var queryInterim = query.ToList().AsQueryable();
            Expression<Func<SearchTransfer, bool>> filter = GetExpenseSearchFilter(searchString);

            List<SearchTransfer> result2 = queryInterim.Where(filter).ToList().Where(p => HighLightSearchString(p, searchString)).OrderByDescending(p => p.ExpenseId).ToList();
            result2.Where(p => GetActivityCode(p)).ToList();
            return result2;
        }

        #region Filtering

        private Expression<Func<SearchTransfer, bool>> GetSearchFilter(string searchString)
        {

            Expression<Func<SearchTransfer, bool>> pred = null;
            pred = p => p.ActivityCode.ToString().ToLower().Contains(searchString.ToLower());
            pred = pred.Or(p => p.ActivityName.ToString().ToLower().Contains(searchString.ToLower()));
            pred = pred.Or(p => p.ActivityId.ToString().ToLower().Contains(searchString.ToLower()));
            pred = pred.Or(p => p.ActivityDescription.ToString().ToLower().Contains(searchString.ToLower()));
            return pred;
        }

        private Expression<Func<SearchTransfer, bool>> GetExpenseSearchFilter(string searchString)
        {
            Expression<Func<SearchTransfer, bool>> pred = null;
            pred = p => p.ExpenseId.ToString().Contains(searchString.ToLower());
            pred = pred.Or(p => p.ExpenseName.ToString().ToLower().Contains(searchString.ToLower()));
            return pred;
        }

        #endregion

        #region Helper

        private bool HighLightSearchString(SearchTransfer p, string searchString)
        {
            if (p.ExpenseId == 0)
            {
                p.ActivityCode = HighLight(p.ActivityCode, searchString);
                p.ActivityIdString = HighLight(p.ActivityIdString, searchString);
                p.ActivityName = HighLight(p.ActivityName, searchString);
                p.ActivityDescription = HighLight(p.ActivityDescription, searchString);
                return true;
            }
            else
            {
                p.ExpenseIdString = HighLight(p.ExpenseIdString, searchString);
                p.ActivityName = HighLight(p.ActivityName, searchString);
                p.ExpenseName = HighLight(p.ExpenseName, searchString);
                return true;
            }
        }

        private string HighLight(string field, string searchString)
        {
            //field = field.Replace(searchString, "<span style=background-color:yellow>" + searchString + "</span>");
            //field = field.Replace(searchString.ToLower(), "<span style='background-color:yellow'>" + searchString.ToLower() + "</span>");
           // field = field.Replace(searchString.ToUpper(), "<span style='background-color:yellow'>" + searchString.ToUpper() + "</span>");
            return field;
        }

        private bool GetActivityCode(Activity p)
        {
            p.ActivityCode = Helper.GetCode(p);
            return true;
        }

        private bool GetActivityCode(SearchTransfer result)
        {

            var query = from activity in misContext.Activity
                .Include(p => p.Strategy)
                .Include(p => p.Unit)
                .Include(p => p.Dsp)
                .Include(p => p.Awp).Where(P => P.ActivityId == result.ActivityId).ToList().Where(p => GetActivityCode(p)).ToList()
                        select activity.ActivityCode;

            result.ActivityCode = query.FirstOrDefault();
            return true;
        }

        #endregion
    }
}