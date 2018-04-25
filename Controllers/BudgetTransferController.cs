using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Options;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.TransferClass;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.ExportClass;

namespace ECDC.MIS.API.Controllers
{
    [Route("api/[controller]")]
    public class BudgetTransferController : Controller
    {
        private readonly MISContext misContext;
        //private readonly List<UserApplication> userApplicationFullList;
        //private readonly ILookupRepository lookupList;
        //private readonly UserApplication currentUser;
        //private readonly LogService logService;
        //private readonly Uri reportServerUrl;
        //public ILookupActivity ActivityLookupList { get; }

        //private List<LookupListItem> ActivityCodeList{ get; set; }

        //Artung userlist contain only active user, what about people that left ecdc ?
        //public BudgetTransferController([FromServices]MISContext misContext, ILookupActivity lookupActivity, ILookupRepository lookupRepository, ILookupUser lookupUser, IOptions<AppSettings> appSettings, LogService logService)
        public BudgetTransferController([FromServices]MISContext misContext)
        {
            this.misContext = misContext;
        }

        #region load data

        /// <summary>
        /// Get list of budget transfer for awpId
        /// </summary>
        /// <param name="awpId">The awp id</param>
        /// <returns>The list of BudgetTransfer object</returns>
        [HttpGet]
        [Route("{awpId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public List<BudgetTransferTransfer> Get(long awpId)
        {
            var query = (from bt in misContext.PendingExpenseTransfer.AsNoTracking()
                         .Include(p => p.PetStatus).AsNoTracking()
                         .Include(p => p.ExpenseIdSourceNavigation).ThenInclude(p => p.Activity).AsNoTracking()
                         .Include(p => p.ExpenseIdTargetNavigation).ThenInclude(p => p.Activity).AsNoTracking()
                         .Where(p => p.PetIsDeleted != true)
                         .Where(p => p.ExpenseIdSourceNavigation.Activity != null ? p.ExpenseIdSourceNavigation.Activity.AWPId == awpId : p.ExpenseIdTargetNavigation.Activity != null ? p.ExpenseIdTargetNavigation.Activity.AWPId == awpId : false)
                         select new BudgetTransferTransfer
                         {
                             PetId = bt.PetId,
                             Amount = bt.PetAmount,
                             IsFinanceNeeded = NeedFinanceApproval(bt),
                             IsFinanceInitiatorNeeded = NeedFinanceInitiatorApproval(bt),
                             UserIdAdded = bt.UserAdded,
                             PetType = SetPetType(bt),
                             //UserModFullName = userApplicationFullList.Where(p => p.UserId == bt.UserMod).Select(p => p.UserFullName).FirstOrDefault(),
                             DateMod = bt.DateMod,
                             PetNote = bt.PetNote == null ? "" : bt.PetNote,
                             ValidationType = BudgetTransferValidationType.None,
                             AbacReference = bt.PetAbacReference,

                             PetStatusIsPending = bt.PetStatus.PetIsPending,
                             PetStatusIsExecuted = bt.PetStatus.PetIsExecuted,
                             PetStatusIsRejected = bt.PetStatus.PetIsRejected,
                             PetStatusId = bt.PetStatusId,
                             PetStatusName = bt.PetStatus == null ? "" : bt.PetStatus.PetStatusName,
                             //PetStatusIcon = SetStatusIcon(bt),
                             PetStatusTooltip = bt.PetStatus == null ? "No status" : bt.PetStatus.PetStatusName,

                             SourceMotivation = bt.PetMotivation,
                             SourceAmount = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseAmount : 0,
                             SourceActivityId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ActivityId : 0,
                             SourceActivityName = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.ActivityName : "",
                             SourceExpenseName = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseName : "",
                             SourceExpenseId = bt.ExpenseIdSource.GetValueOrDefault(),
                             SourceExpenseIdName = bt.ExpenseIdSource.ToString(),
                             SourceBudgetLineId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.BudgetLineId : null,
                             SourceBudgetLineCode = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.BudgetLine.BudgetLineName : "",
                             SourceExpenseType = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseType.ExpenseTypeName : "",
                             SourceActivityUnitId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.UnitId : null,
                             SourceActivityDpId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.DSPId : null,
                             SourceActivityAwpId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.AWPId : null,
                             SourceIsTitle1 = bt.ExpenseIdSource.GetValueOrDefault() == 0 ? bt.PetIsBudgetTitle1.GetValueOrDefault() : false,
                             SourceIsTitle2 = bt.ExpenseIdSource.GetValueOrDefault() == 0 ? bt.PetIsBudgetTitle2.GetValueOrDefault() : false,
                             SourceActivityCode = bt.ExpenseIdSourceNavigation != null ? Helper.GetCode(new Activity() { ActivityId = bt.ExpenseIdSourceNavigation.Activity.ActivityId, ActivityCodeSequence = bt.ExpenseIdSourceNavigation.Activity.ActivityCodeSequence, Strategy = bt.ExpenseIdSourceNavigation.Activity.Strategy, Unit = bt.ExpenseIdSourceNavigation.Activity.Unit, Awp = bt.ExpenseIdSourceNavigation.Activity.Awp, Dsp = bt.ExpenseIdSourceNavigation.Activity.Dsp }):"",

                             TargetMotivation = bt.PetMotivationTarget,
                             TargetAmount = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseAmount : 0,
                             TargetActivityId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ActivityId.GetValueOrDefault() : 0,
                             TargetActivityName = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.ActivityName : "",
                             TargetExpenseName = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseName : "",
                             TargetExpenseId = bt.ExpenseIdTarget.GetValueOrDefault(),
                             TargetExpenseIdName = bt.ExpenseIdTarget.ToString(),
                             TargetBudgetLineId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.BudgetLineId : null,
                            
                             TargetBudgetLineCode = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.BudgetLine.BudgetLineName : "",
                             TargetExpenseType = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseType.ExpenseTypeName : "",
                             TargetActivityUnitId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.UnitId : null,
                             TargetActivityDpId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.DSPId : null,
                             TargetActivityAwpId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.AWPId : null,
                             TargetIsTitle1 = bt.ExpenseIdTarget == null ? bt.PetIsBudgetTitle1.GetValueOrDefault() : false,
                             TargetIsTitle2 = bt.ExpenseIdTarget == null ? bt.PetIsBudgetTitle2.GetValueOrDefault() : false,
                             TargetActivityCode = bt.ExpenseIdTargetNavigation != null ? Helper.GetCode(new Activity() { ActivityId = bt.ExpenseIdTargetNavigation.Activity.ActivityId, ActivityCodeSequence = bt.ExpenseIdTargetNavigation.Activity.ActivityCodeSequence, Strategy = bt.ExpenseIdTargetNavigation.Activity.Strategy, Unit = bt.ExpenseIdTargetNavigation.Activity.Unit, Awp = bt.ExpenseIdTargetNavigation.Activity.Awp, Dsp = bt.ExpenseIdTargetNavigation.Activity.Dsp }):"",

                             //Wokflow source
                             SourceIsHoUAutorized = bt.PetIsHeadOfUnitSourceAutorized,
                             SourceHoUAutorizedDate = bt.PetDateHeadOfUnitSourceApproval,
                             SourceIsHoURejected = bt.PetIsHeadOfUnitSourceRejected,
                             SourceHoURejectedDate = bt.PetDateHeadOfUnitSourceRejected,
                             //SourceHoUFullNameAutorize = userApplicationFullList.Where(p => p.UserId == bt.UserIdHeadOfUnitSourceAutorized).Select(p => p.UserFullName).FirstOrDefault(),

                             //Wokflow target
                             TargetIsHoUAutorized = bt.PetIsHeadOfUnitTargetAutorized,
                             TargetHoUAutorizedDate = bt.PetDateHeadOfUnitTargetApproval,
                             TargetIsHoURejected = bt.PetIsHeadOfUnitTargetRejected,
                             TargetHoURejectedDate = bt.PetDateHeadOfUnitTargetRejected,
                             //TargetHoUFullNameAutorize = userApplicationFullList.Where(p => p.UserId == bt.UserIdHeadOfUnitTargetAutorized).Select(p => p.UserFullName).FirstOrDefault(),

                             //Wokflow finance initiator
                             FinanceInitiatorRejected = bt.PetIsFinanceInitRejected,
                             FinanceInitiatorRejectedDate = bt.PetDateFinanceInitRejected,
                             FinanceInitiatorAutorized = bt.PetIsFinanceInitAutorized,
                             //FinanceInitiatorAutorizeFullName = userApplicationFullList.Where(p => p.UserId == bt.UserIdAutorized).Select(p => p.UserFullName).FirstOrDefault(),
                             FinanceInitiatorAutorizeDate = bt.PetDateApproval,

                             //Wokflow finance
                             FinanceRejected = bt.PetIsFinanceRejected,
                             FinanceRejectedDate = bt.PetDateFinanceRejected,
                             FinanceAutorized = bt.PetIsAutorized,
                             //FinanceAutorizeFullName = userApplicationFullList.Where(p => p.UserId == bt.UserIdAutorized).Select(p => p.UserFullName).FirstOrDefault(),
                             FinanceAutorizeDate = bt.PetDateApproval,

                             //RejectedFullName = userApplicationFullList.Where(p => p.UserId == bt.UserIdRejected).Select(p => p.UserFullName).FirstOrDefault(),
                         }).ToList();

                //    SetPetType(bt);
                //    SetWorkflow(bt);
                return query.ToList();
        }

        /// <summary>
        /// Get a budgetTransfer for a petId
        /// </summary>
        /// <param name="petId">The petId</param>
        /// <returns>The BudgetTransfer</returns>
        [HttpGet]
        [Route("getBudgetTransfer/{petId}")]
        [ResponseCache(NoStore = true, Duration = 0)]
        public BudgetTransferTransfer GetBudgetTransfer(long petId)
        {
            var query = (from bt in misContext.PendingExpenseTransfer.AsNoTracking()
                         .Include(p => p.PetStatus).AsNoTracking()
                         .Include(p => p.ExpenseIdSourceNavigation).ThenInclude(p => p.Activity).AsNoTracking()
                         .Include(p => p.ExpenseIdTargetNavigation).ThenInclude(p => p.Activity).AsNoTracking()
                         .Where(p => p.PetIsDeleted != true)
                         .Where(p => p.PetId == petId)
                         select new BudgetTransferTransfer
                         {
                             PetId = bt.PetId,
                             Amount = bt.PetAmount,
                             IsFinanceNeeded = NeedFinanceApproval(bt),
                             IsFinanceInitiatorNeeded = NeedFinanceInitiatorApproval(bt),
                             UserIdAdded = bt.UserAdded,
                             PetType = SetPetType(bt),
                             //UserModFullName = userApplicationFullList.Where(p => p.UserId == bt.UserMod).Select(p => p.UserFullName).FirstOrDefault(),
                             DateMod = bt.DateMod,
                             PetNote = bt.PetNote == null ? "" : bt.PetNote,
                             ValidationType = BudgetTransferValidationType.None,
                             AbacReference = bt.PetAbacReference,

                             PetStatusIsPending = bt.PetStatus.PetIsPending,
                             PetStatusIsExecuted = bt.PetStatus.PetIsExecuted,
                             PetStatusIsRejected = bt.PetStatus.PetIsRejected,
                             PetStatusId = bt.PetStatusId,
                             PetStatusName = bt.PetStatus == null ? "" : bt.PetStatus.PetStatusName,
                             //PetStatusIcon = SetStatusIcon(bt),
                             PetStatusTooltip = bt.PetStatus == null ? "No status" : bt.PetStatus.PetStatusName,

                             SourceMotivation = bt.PetMotivation,
                             SourceAmount = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseAmount : 0,
                             SourceActivityId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ActivityId : 0,
                             SourceActivityName = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.ActivityName : "",
                             SourceExpenseName = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseName : "",
                             SourceExpenseId = bt.ExpenseIdSource.GetValueOrDefault(),
                             SourceExpenseIdName = bt.ExpenseIdSource.ToString(),
                             SourceBudgetLineId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.BudgetLineId : null,
                             SourceBudgetLineCode = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.BudgetLine.BudgetLineName : "",
                             SourceExpenseType = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseType.ExpenseTypeName : "",
                             SourceActivityUnitId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.UnitId : null,
                             SourceActivityDpId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.DSPId : null,
                             SourceActivityAwpId = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.AWPId : null,
                             SourceIsTitle1 = bt.ExpenseIdSource.GetValueOrDefault() == 0 ? bt.PetIsBudgetTitle1.GetValueOrDefault() : false,
                             SourceIsTitle2 = bt.ExpenseIdSource.GetValueOrDefault() == 0 ? bt.PetIsBudgetTitle2.GetValueOrDefault() : false,
                             SourceActivityCode = bt.ExpenseIdSourceNavigation != null ? Helper.GetCode(new Activity() { ActivityId = bt.ExpenseIdSourceNavigation.Activity.ActivityId, ActivityCodeSequence = bt.ExpenseIdSourceNavigation.Activity.ActivityCodeSequence, Strategy = bt.ExpenseIdSourceNavigation.Activity.Strategy, Unit = bt.ExpenseIdSourceNavigation.Activity.Unit, Awp = bt.ExpenseIdSourceNavigation.Activity.Awp, Dsp = bt.ExpenseIdSourceNavigation.Activity.Dsp }):"",

                             TargetMotivation = bt.PetMotivationTarget,
                             TargetAmount = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseAmount : 0,
                             TargetActivityId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ActivityId.GetValueOrDefault() : 0,
                             TargetActivityName = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.ActivityName : "",
                             TargetExpenseName = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseName : "",
                             TargetExpenseId = bt.ExpenseIdTarget.GetValueOrDefault(),
                             TargetExpenseIdName = bt.ExpenseIdTarget.ToString(),
                             TargetBudgetLineId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.BudgetLineId : null,
                             TargetBudgetLineCode = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.BudgetLine.BudgetLineName : "",
                             TargetExpenseType = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseType.ExpenseTypeName : "",
                             TargetActivityUnitId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.UnitId : null,
                             TargetActivityDpId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.DSPId : null,
                             TargetActivityAwpId = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.AWPId : null,
                             TargetIsTitle1 = bt.ExpenseIdTarget == null ? bt.PetIsBudgetTitle1.GetValueOrDefault() : false,
                             TargetIsTitle2 = bt.ExpenseIdTarget == null ? bt.PetIsBudgetTitle2.GetValueOrDefault() : false,
                             TargetActivityCode = bt.ExpenseIdTargetNavigation != null ? Helper.GetCode(new Activity() { ActivityId = bt.ExpenseIdTargetNavigation.Activity.ActivityId, ActivityCodeSequence = bt.ExpenseIdTargetNavigation.Activity.ActivityCodeSequence, Strategy = bt.ExpenseIdTargetNavigation.Activity.Strategy, Unit = bt.ExpenseIdTargetNavigation.Activity.Unit, Awp = bt.ExpenseIdTargetNavigation.Activity.Awp, Dsp = bt.ExpenseIdTargetNavigation.Activity.Dsp }):"",

                             //Wokflow source
                             SourceIsHoUAutorized = bt.PetIsHeadOfUnitSourceAutorized,
                             SourceHoUAutorizedDate = bt.PetDateHeadOfUnitSourceApproval,
                             SourceIsHoURejected = bt.PetIsHeadOfUnitSourceRejected,
                             SourceHoURejectedDate = bt.PetDateHeadOfUnitSourceRejected,
                             //SourceHoUFullNameAutorize = userApplicationFullList.Where(p => p.UserId == bt.UserIdHeadOfUnitSourceAutorized).Select(p => p.UserFullName).FirstOrDefault(),

                             //Wokflow target
                             TargetIsHoUAutorized = bt.PetIsHeadOfUnitTargetAutorized,
                             TargetHoUAutorizedDate = bt.PetDateHeadOfUnitTargetApproval,
                             TargetIsHoURejected = bt.PetIsHeadOfUnitTargetRejected,
                             TargetHoURejectedDate = bt.PetDateHeadOfUnitTargetRejected,
                             //TargetHoUFullNameAutorize = userApplicationFullList.Where(p => p.UserId == bt.UserIdHeadOfUnitTargetAutorized).Select(p => p.UserFullName).FirstOrDefault(),

                             //Wokflow finance initiator
                             FinanceInitiatorRejected = bt.PetIsFinanceInitRejected,
                             FinanceInitiatorRejectedDate = bt.PetDateFinanceInitRejected,
                             FinanceInitiatorAutorized = bt.PetIsFinanceInitAutorized,
                             //FinanceInitiatorAutorizeFullName = userApplicationFullList.Where(p => p.UserId == bt.UserIdAutorized).Select(p => p.UserFullName).FirstOrDefault(),
                             FinanceInitiatorAutorizeDate = bt.PetDateApproval,

                             //Wokflow finance
                             FinanceRejected = bt.PetIsFinanceRejected,
                             FinanceRejectedDate = bt.PetDateFinanceRejected,
                             FinanceAutorized = bt.PetIsAutorized,
                             //FinanceAutorizeFullName = userApplicationFullList.Where(p => p.UserId == bt.UserIdAutorized).Select(p => p.UserFullName).FirstOrDefault(),
                             FinanceAutorizeDate = bt.PetDateApproval,

                             //RejectedFullName = userApplicationFullList.Where(p => p.UserId == bt.UserIdRejected).Select(p => p.UserFullName).FirstOrDefault(),
                         }).FirstOrDefault();

                //    SetPetType(bt);
                //    SetWorkflow(bt);
                return query;
        }

        #endregion

        #region List of BudgetTransfer for ActivityDetail page

        public class BudgetTransferSummary
        {
            public long ExpenseId { get; set; }
            public decimal? InitialAmount { get; set; }
            public decimal? Amount { get; set; }
            public string ExpenseName { get; set; }
            public List<BudgetTransferTransfer> BudgetTransferList { get; set; }
        }

        [HttpGet]
        [Route("activity/{activityId}")]
        public List<BudgetTransferSummary> GetBtList(long activityId)
        {
            var btList = (from bt in misContext.PendingExpenseTransfer
                          where bt.PetIsDeleted == null
                                  && bt.PetStatus.PetIsExecuted.GetValueOrDefault()
                                  && (bt.ExpenseIdTargetNavigation.Activity.ActivityId == activityId)
                                  || (bt.ExpenseIdSourceNavigation.Activity.ActivityId == activityId)
                          orderby bt.PetId descending
                          select new BudgetTransferTransfer()
                          {
                              PetId = bt.PetId,
                              Amount = bt.PetAmount,

                              SourceActivityId = bt.ExpenseIdSourceNavigation.ActivityId.GetValueOrDefault(),
                              SourceActivityCode = Helper.GetCode(bt.ExpenseIdSourceNavigation.Activity),
                              SourceExpenseId = bt.ExpenseIdSource.GetValueOrDefault(),
                              SourceExpenseName = bt.ExpenseIdSourceNavigation.ExpenseName,
                              SourceAmount = bt.ExpenseIdSourceNavigation.ExpenseAmount,
                              SourceInitialAmount = bt.ExpenseIdSourceNavigation.ExpenseInitialAmount,


                              TargetActivityId = bt.ExpenseIdTargetNavigation.ActivityId.GetValueOrDefault(),
                              TargetActivityCode = Helper.GetCode(bt.ExpenseIdTargetNavigation.Activity),
                              TargetExpenseId = bt.ExpenseIdTarget.GetValueOrDefault(),
                              TargetExpenseName = bt.ExpenseIdTargetNavigation.ExpenseName,
                              TargetAmount = bt.ExpenseIdTargetNavigation.ExpenseAmount,
                              TargetInitialAmount = bt.ExpenseIdTargetNavigation.ExpenseInitialAmount,
                          }).ToList();

            //Get list of expenseId source and target
            List<BudgetTransferSummary> btSummaryList = new List<BudgetTransferSummary>();
            foreach (var bt in btList)
            {
                if (btSummaryList.Find(p => p.ExpenseId == bt.SourceExpenseId) == null)
                {
                    BudgetTransferSummary newItem = new BudgetTransferSummary();
                    newItem.ExpenseId = bt.SourceExpenseId;
                    newItem.Amount = bt.SourceAmount;
                    newItem.ExpenseName = bt.SourceExpenseName;
                    newItem.InitialAmount = bt.SourceInitialAmount;
                    btSummaryList.Add(newItem);
                }
                if (btSummaryList.Find(p => p.ExpenseId == bt.TargetExpenseId) == null)
                {
                    BudgetTransferSummary newItem = new BudgetTransferSummary();
                    newItem.ExpenseId = bt.TargetExpenseId;
                    newItem.Amount = bt.TargetAmount;
                    newItem.ExpenseName = bt.TargetExpenseName;
                    newItem.InitialAmount = bt.TargetInitialAmount;
                    btSummaryList.Add(newItem);
                }
            }

            //Add list of BT
            foreach (var btSummary in btSummaryList.ToList())
            {
                btSummary.BudgetTransferList = btList.Where(p => p.SourceExpenseId == btSummary.ExpenseId || p.TargetExpenseId == btSummary.ExpenseId).ToList();
            }

            return btSummaryList;
        }

        #endregion

        #region Export to CSV

        /// <summary>
        /// Get data to export to csv file for Activity detail page
        /// </summary>
        [HttpGet]
        [Route("ExportData/{activityId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<BudgetTransferSummaryExport> ExportData(long activityId)
        {
            List<BudgetTransferSummaryExport> result = new List<BudgetTransferSummaryExport>();

            //Get list of budget transfer for this activity
            var btList = (from bt in misContext.PendingExpenseTransfer
                          where bt.PetIsDeleted == null
                                  && bt.PetStatus.PetIsExecuted.GetValueOrDefault()
                                  && (bt.ExpenseIdTargetNavigation.Activity.ActivityId == activityId)
                                  || (bt.ExpenseIdSourceNavigation.Activity.ActivityId == activityId)
                          orderby bt.PetId descending
                          select new BudgetTransferTransfer()
                          {
                              PetId = bt.PetId,
                              Amount = bt.PetAmount,
                              SourceActivityId = bt.ExpenseIdSourceNavigation.ActivityId.GetValueOrDefault(),
                              SourceActivityCode = Helper.GetCode(bt.ExpenseIdSourceNavigation.Activity),
                              SourceExpenseId = bt.ExpenseIdSource.GetValueOrDefault(),
                              SourceExpenseName = bt.ExpenseIdSourceNavigation.ExpenseName,
                              SourceAmount = bt.ExpenseIdSourceNavigation.ExpenseAmount,
                              SourceInitialAmount = bt.ExpenseIdSourceNavigation.ExpenseInitialAmount,
                              TargetActivityId = bt.ExpenseIdTargetNavigation.ActivityId.GetValueOrDefault(),
                              TargetActivityCode = Helper.GetCode(bt.ExpenseIdTargetNavigation.Activity),
                              TargetExpenseId = bt.ExpenseIdTarget.GetValueOrDefault(),
                              TargetExpenseName = bt.ExpenseIdTargetNavigation.ExpenseName,
                              TargetAmount = bt.ExpenseIdTargetNavigation.ExpenseAmount,
                              TargetInitialAmount = bt.ExpenseIdTargetNavigation.ExpenseInitialAmount,
                          }).ToList();

            //for each expense of this activity we add the transfer in or out
            foreach (var expense in misContext.Expense.Where(p=>p.ActivityId == activityId).ToList())
            {
                foreach (var bt in btList)
                {
                    if (bt.SourceExpenseId == expense.ExpenseId || bt.TargetExpenseId == expense.ExpenseId)
                    {
                        BudgetTransferSummaryExport exportLine = new BudgetTransferSummaryExport()
                        {
                            ExpenseId = expense.ExpenseId,
                            ExpenseName = expense.ExpenseName,
                            InitialAmount = expense.ExpenseInitialAmount,
                            CurrentAmount = expense.ExpenseAmount,
                            PetId = bt.PetId,
                            TransferAmount = bt.Amount,
                            Source = bt.SourceExpenseId + "-" + bt.SourceExpenseName,
                            Target = bt.TargetExpenseId + "-" + bt.TargetExpenseName
                        };

                        result.Add(exportLine);
                    }
                }
            }

            return result;
        }


        [HttpGet]
        [Route("ExportDataBis/{awpId}")]
        public IEnumerable<BudgetTransferExport> ExportDataBis(long awpId)
        {
            var query = (from bt in misContext.PendingExpenseTransfer.AsNoTracking()
                         .Include(p => p.PetStatus).AsNoTracking()
                         .Include(p => p.ExpenseIdSourceNavigation).ThenInclude(p => p.Activity).AsNoTracking()
                         .Include(p => p.ExpenseIdTargetNavigation).ThenInclude(p => p.Activity).AsNoTracking()
                         .Where(p => p.PetIsDeleted != true)
                         .Where(p => p.ExpenseIdSourceNavigation.Activity != null ? p.ExpenseIdSourceNavigation.Activity.AWPId == awpId : p.ExpenseIdTargetNavigation.Activity != null ? p.ExpenseIdTargetNavigation.Activity.AWPId == awpId : false)
                         select new BudgetTransferExport
                         {
                             PetId = bt.PetId,
 
                             SourceActivityCode = Helper.GetCode(new Activity() { ActivityId = bt.ExpenseIdSourceNavigation.Activity.ActivityId, ActivityCodeSequence = bt.ExpenseIdSourceNavigation.Activity.ActivityCodeSequence, Strategy = bt.ExpenseIdSourceNavigation.Activity.Strategy, Unit = bt.ExpenseIdSourceNavigation.Activity.Unit, Awp = bt.ExpenseIdSourceNavigation.Activity.Awp, Dsp = bt.ExpenseIdSourceNavigation.Activity.Dsp }),
                             SourceActivityName = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.Activity.ActivityName : "",
                             SourceExpenseName = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseName : "",
                             SourceBudgetLineCode = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.BudgetLine.BudgetLineName : "",
                             SourceExpenseType = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseType.ExpenseTypeName : "",
                             SourceAmount = bt.ExpenseIdSourceNavigation != null ? bt.ExpenseIdSourceNavigation.ExpenseAmount : 0,
                             SourceMotivation = bt.PetMotivation,
                           
                             TargetActivityCode = Helper.GetCode(new Activity() { ActivityId = bt.ExpenseIdTargetNavigation.Activity.ActivityId, ActivityCodeSequence = bt.ExpenseIdTargetNavigation.Activity.ActivityCodeSequence, Strategy = bt.ExpenseIdTargetNavigation.Activity.Strategy, Unit = bt.ExpenseIdTargetNavigation.Activity.Unit, Awp = bt.ExpenseIdTargetNavigation.Activity.Awp, Dsp = bt.ExpenseIdTargetNavigation.Activity.Dsp }),
                             TargetActivityName = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.Activity.ActivityName : "",
                             TargetExpenseName = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseName : "",
                             TargetBudgetLineCode = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.BudgetLine.BudgetLineName : "",
                             TargetExpenseType = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseType.ExpenseTypeName : "",
                             TargetAmount = bt.ExpenseIdTargetNavigation != null ? bt.ExpenseIdTargetNavigation.ExpenseAmount : 0,
                             TargetMotivation = bt.PetMotivationTarget,

                             Amount = bt.PetAmount,
                             PetStatusName = bt.PetStatus == null ? "" : bt.PetStatus.PetStatusName,
                         }).ToList();

                return query.ToList();
        }

        #endregion
    



    //[HttpGet]
    //[Route("/api/[controller]/GetBasketList/{awpId}")]
    //public List<BudgetTransferBasketTransfer> GetBasketList(long awpId)
    //{
    //    ActivityCodeList = GetActivityCodeList(awpId);

    //    var query = (from item in misContext.ExpenseBudgetAbac
    //                 .Include(p => p.Expense).ThenInclude(p => p.Activity)
    //                 where ((item.ExpenseBudgetAbacCommitted == 0 && item.ExpenseBudgetAbacType == "C8") || (item.ExpenseBudgetAbacType != "C8"))
    //                 select item).ToList().Where(p => p.Expense.Activity.AWPId.GetValueOrDefault() == awpId).ToList();

    //    var query2 = (from item2 in query
    //                  group item2 by new
    //                  {
    //                      item2.ExpenseId,
    //                      item2.Expense.ActivityId,
    //                      item2.Expense.ExpenseName,
    //                  } into newGroup
    //                  where newGroup.Sum(x => x.ExpenseBudgetAbacCommitted) != newGroup.Sum(x => x.Expense.ExpenseAmount)
    //                  select new BudgetTransferBasketTransfer
    //                  {
    //                      ActivityCode = ActivityCodeList.Where(p => p.Value == newGroup.Key.ActivityId).Select(p => p.Text).FirstOrDefault(),
    //                      ActivityId = newGroup.Key.ActivityId,
    //                      ExpenseId = newGroup.Key.ExpenseId,
    //                      ExpenseName = newGroup.Key.ExpenseName,
    //                      CommittedAmount = newGroup.Sum(x => x.ExpenseBudgetAbacCommitted),
    //                      AllocatedAmount = newGroup.Sum(x => x.Expense.ExpenseAmount),
    //                      PaidAmount = newGroup.Sum(x => x.ExpenseBudgetAbacPaid),
    //                      RemainAmount = newGroup.Sum(x => x.Expense.ExpenseAmount) - newGroup.Sum(x => x.ExpenseBudgetAbacCommitted)
    //                  }).ToList();

    //    return query2;
    //}

    //#region save

    //// POST api/values
    //[HttpPost]
    //public void Post([FromBody]BudgetTransferTransfer bt)
    //{
    //    try
    //    {
    //        PendingExpenseTransfer pet = misContext.PendingExpenseTransfer.Where(p => p.PetId == bt.PetId).FirstOrDefault();
    //        bool isAdd = false;

    //        if (pet != null)
    //        {
    //            pet.DateMod = DateTime.Now;
    //            pet.UserMod = currentUser.UserId;
    //        }
    //        else
    //        {
    //            isAdd = true;
    //            pet = new PendingExpenseTransfer()
    //            {
    //                DateAdded = DateTime.Now,
    //                UserAdded = currentUser.UserId,
    //                PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsPending == true).Select(p => p.PetStatusId).FirstOrDefault()
    //            };
    //        }

    //        pet.ExpenseIdSource = bt.SourceExpenseId == 0 ? new Nullable<long>() : bt.SourceExpenseId;
    //        pet.ExpenseIdTarget = bt.TargetExpenseId == 0 ? new Nullable<long>() : bt.TargetExpenseId;
    //        pet.PetAbacReference = bt.AbacReference;
    //        pet.PetIsBudgetTitle1 = bt.SourceIsTitle1 || bt.TargetIsTitle1 ? true : false;
    //        pet.PetIsBudgetTitle2 = bt.SourceIsTitle2 || bt.TargetIsTitle2 ? true : false;

    //        pet.PetMotivation = bt.SourceMotivation;
    //        pet.PetMotivationTarget = bt.TargetMotivation;
    //        pet.PetAmount = bt.Amount;

    //        if (isAdd)
    //        {
    //            misContext.Entry(pet).State = EntityState.Added;
    //        }
    //        else
    //        {
    //            misContext.Entry(pet).State = EntityState.Modified;
    //        }

    //        //The execution should happen after the pet has been saved in db
    //        bool isExecuteAfterSave = UpdateApprovalStatus(bt, pet);
    //        misContext.SaveChanges();
    //        if (isExecuteAfterSave)
    //        {
    //            ExecuteBudgetTransfer(bt.SourceExpenseId, bt.TargetExpenseId, bt.Amount);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        logService.SaveLog(currentUser.UserId, LogType.Error, MISPage.BudgetTransferPage, ex, Method.UpdateExecuteBudgetTransfer);
    //    }
    //}

    ///// <summary>
    ///// Update the status of a pet and return a bool if the BT should be executed
    ///// </summary>
    ///// <param name="bt">Thed BT </param>
    ///// <param name="pet">The pet to update</param>
    ///// <returns>The execution boolean</returns>
    //private bool UpdateApprovalStatus(BudgetTransferTransfer bt, PendingExpenseTransfer pet)
    //{
    //        bool isExecute = false;

    //        switch (bt.ValidationType)
    //        {
    //            case BudgetTransferValidationType.None:
    //                break;
    //            case BudgetTransferValidationType.HoUSourceApproval:
    //                pet.PetIsHeadOfUnitSourceAutorized = true;
    //                pet.UserIdHeadOfUnitSourceAutorized = currentUser.UserId;
    //                pet.PetDateHeadOfUnitSourceApproval = DateTime.Now;
    //                pet.PetDateLastNotification = null;
    //                break;
    //            case BudgetTransferValidationType.HoUSourceRejected:
    //                pet.PetIsHeadOfUnitSourceRejected = true;
    //                pet.UserIdRejected = currentUser.UserId;
    //                pet.PetDateHeadOfUnitSourceRejected = DateTime.Now;
    //                pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsRejected == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                break;
    //            case BudgetTransferValidationType.HoUTargetApproval:
    //                pet.PetIsHeadOfUnitTargetAutorized = true;
    //                pet.UserIdHeadOfUnitTargetAutorized = currentUser.UserId;
    //                pet.PetDateHeadOfUnitTargetApproval = DateTime.Now;
    //                pet.PetDateLastNotification = null;
    //                if (!bt.IsFinanceNeeded && !bt.IsFinanceInitiatorNeeded)
    //                {
    //                    pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsExecuted == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                    //ExecuteBudgetTransfer(bt.SourceExpenseId, bt.TargetExpenseId, bt.Amount);
    //                    isExecute = true;
    //                }
    //                break;
    //            case BudgetTransferValidationType.HoUTargetRejected:
    //                pet.PetIsHeadOfUnitTargetRejected = true;
    //                pet.UserIdRejected = currentUser.UserId;
    //                pet.PetDateHeadOfUnitTargetRejected = DateTime.Now;
    //                pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsRejected == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                break;
    //            case BudgetTransferValidationType.FinanceInitiatorApproval:
    //                pet.PetIsFinanceInitAutorized = true;
    //                pet.UserIdAutorized = currentUser.UserId;
    //                pet.PetDateApproval = DateTime.Now;
    //                pet.PetDateLastNotification = null;
    //                pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsExecuted == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                //ExecuteBudgetTransfer(bt.SourceExpenseId, bt.TargetExpenseId, bt.Amount);
    //                isExecute = true;
    //                break;
    //            case BudgetTransferValidationType.FinanceInitiatorRejected:
    //                pet.PetIsFinanceInitRejected = true;
    //                pet.UserIdRejected = currentUser.UserId;
    //                pet.PetDateFinanceInitRejected = DateTime.Now;
    //                pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsRejected == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                break;
    //            case BudgetTransferValidationType.FinanceApproval:
    //                pet.PetIsAutorized = true;
    //                pet.UserIdAutorized = currentUser.UserId;
    //                pet.PetDateApproval = DateTime.Now;
    //                pet.PetDateLastNotification = null;
    //                pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsExecuted == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                //ExecuteBudgetTransfer(bt.SourceExpenseId, bt.TargetExpenseId, bt.Amount);
    //                isExecute = true;
    //                break;
    //            case BudgetTransferValidationType.FinanceRejected:
    //                pet.PetIsFinanceRejected = true;
    //                pet.UserIdRejected = currentUser.UserId;
    //                pet.PetDateFinanceRejected = DateTime.Now;
    //                pet.PetStatusId = misContext.PendingTransferStatus.Where(p => p.PetIsRejected == true).Select(p => p.PetStatusId).FirstOrDefault();
    //                break;
    //            default:
    //                break;
    //        }

    //        return isExecute;
    //}

    //private void ExecuteBudgetTransfer(long expenseSourceId, long expenseTargetId, decimal? amountToTransfer)
    //{
    //    Expense expenseSource = misContext.Expense.Where(p => p.ExpenseId == expenseSourceId).Select(p => p).FirstOrDefault();
    //    Expense expenseTarget = misContext.Expense.Where(p => p.ExpenseId == expenseTargetId).Select(p => p).FirstOrDefault();

    //    if (expenseSource != null)
    //    {
    //        expenseSource.ExpenseAmount = expenseSource.ExpenseAmount == null ? 0 : expenseSource.ExpenseAmount - amountToTransfer;
    //        expenseSource.UserMod = currentUser.UserId;
    //        misContext.Entry(expenseSource).State = EntityState.Modified;
    //        misContext.SaveChanges();
    //    }
    //    if (expenseTarget != null)
    //    {
    //        expenseTarget.ExpenseAmount = expenseTarget.ExpenseAmount == null ? amountToTransfer : expenseTarget.ExpenseAmount + amountToTransfer;
    //        expenseTarget.UserMod = currentUser.UserId;
    //        misContext.Entry(expenseTarget).State = EntityState.Modified;
    //        misContext.SaveChanges();
    //    }
    //}

    //#endregion

    //#region print abac report

    //[HttpGet]
    //[Route("/api/[controller]/PrintAbacReport/{petId}")]
    //public string PrintAbacReport(int petId)
    //{
    //    return string.Format("{0}/Pages/ReportViewer.aspx?%2fMISDev%2fSub+reports%2fSubAbac&rs:Command=Render&PetId={1}", reportServerUrl.ToString(), petId);
    //}

    //#endregion

    #region workflow

    private static bool NeedFinanceApproval(PendingExpenseTransfer bt)
    {
       if (bt.ExpenseIdSourceNavigation == null || bt.ExpenseIdTargetNavigation == null) return true;
       return bt.ExpenseIdSourceNavigation.BudgetLineId != bt.ExpenseIdTargetNavigation.BudgetLineId;
    }

    private static bool NeedFinanceInitiatorApproval(PendingExpenseTransfer bt)
    {
       if (bt.ExpenseIdSourceNavigation == null || bt.ExpenseIdTargetNavigation == null) return false;
       if (bt.ExpenseIdSourceNavigation.BudgetLineId != bt.ExpenseIdTargetNavigation.BudgetLineId) return false;
       return  bt.ExpenseIdSourceNavigation.Activity.DSPId != bt.ExpenseIdTargetNavigation.Activity.DSPId
           || bt.ExpenseIdSourceNavigation.Activity.UnitId != bt.ExpenseIdTargetNavigation.Activity.UnitId;
    }

    //private bool SetWorkflow(BudgetTransferTransfer bt)
    //{
    //    bt.WorkflowIsApproveSourceEnable = false;
    //    bt.WorkflowIsApprovalTargetEnable = false;
    //    bt.WorkflowIsApprovalFinanceEnable = false;
    //    bt.WorkflowIsEditEnable = false;

    //    //if executed or rejected no action possible
    //    if (bt.PetStatusIsExecuted.GetValueOrDefault() || bt.PetStatusIsRejected.GetValueOrDefault())
    //    {
    //        return true;
    //    }

    //     //Transfer title 1 and 2 source
    //    if ((bt.SourceIsTitle1 || bt.SourceIsTitle2) && !bt.TargetIsHoUAutorized.GetValueOrDefault())
    //    {
    //        if (currentUser.UserRole.UserRoleIsPlanningMonitoring.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsPlanningMonitoring.GetValueOrDefault()
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnit.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnit.GetValueOrDefault()))
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault())))
    //        {
    //            bt.WorkflowIsApprovalTargetEnable = true;
    //            bt.WorkflowIsEditEnable = true;
    //        }
    //        return true;
    //    }

    //    //If source not authorized
    //    if (!bt.SourceIsHoUAutorized.GetValueOrDefault() && !bt.SourceIsTitle1 && !bt.SourceIsTitle2)
    //    {
    //        if (currentUser.UserRole.UserRoleIsPlanningMonitoring.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsPlanningMonitoring.GetValueOrDefault()
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnit.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnit.GetValueOrDefault()) && bt.SourceActivityUnitId == currentUser.UnitId)
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault()) && bt.SourceActivityUnitId == currentUser.UnitId))
    //        {
    //            bt.WorkflowIsApproveSourceEnable = true;
    //            bt.WorkflowIsEditEnable = true;
    //        }
    //        if (currentUser.UserRole.UserRoleIsResourceOfficer.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsResourceOfficer.GetValueOrDefault())
    //        {
    //            bt.WorkflowIsEditEnable = true;
    //        }
    //        return true;
    //    }

    //    //Transfer title 1 and 2 target
    //    if ((bt.TargetIsTitle1 || bt.TargetIsTitle2) && !bt.SourceIsHoUAutorized.GetValueOrDefault())
    //    {
    //        if (currentUser.UserRole.UserRoleIsPlanningMonitoring.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsPlanningMonitoring.GetValueOrDefault()
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnit.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnit.GetValueOrDefault()))
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault())))
    //        {
    //            bt.WorkflowIsApproveSourceEnable = true;
    //            bt.WorkflowIsEditEnable = true;
    //        }
    //        return true;
    //    }

    //    //If target not authorized
    //    if (!bt.TargetIsHoUAutorized.GetValueOrDefault() && !bt.TargetIsTitle1 && !bt.TargetIsTitle2)
    //    {
    //        if (currentUser.UserRole.UserRoleIsPlanningMonitoring.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsPlanningMonitoring.GetValueOrDefault()
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnit.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnit.GetValueOrDefault()) && bt.TargetActivityUnitId == currentUser.UnitId)
    //        || ((currentUser.UserRole.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsHeadOfUnitDeputy.GetValueOrDefault()) && bt.TargetActivityUnitId == currentUser.UnitId))
    //        {
    //            bt.WorkflowIsApprovalTargetEnable = true;
    //            bt.WorkflowIsEditEnable = true;
    //        }
    //        return true;
    //    }

    //    //If Finance initiator not authorized and Finance(Ressource officer) or PMM
    //    if (currentUser.UserRole.UserRoleIsPlanningMonitoring.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsPlanningMonitoring.GetValueOrDefault()
    //    || (currentUser.UserRole.UserRoleIsFinance.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsFinance.GetValueOrDefault())
    //    || (currentUser.UserRole.UserRoleIsResourceOfficer.GetValueOrDefault() || currentUser.UserRoleBis.UserRoleIsResourceOfficer.GetValueOrDefault()))
    //    {
    //        bt.WorkflowIsApprovalFinanceEnable = true;
    //    }

    //    return true;
    //}

    #endregion

    #region helper

    private string SetPetType(PendingExpenseTransfer bt)
    {
        if (bt.ExpenseIdSourceNavigation == null)
           return "differentBL";

        if (bt.ExpenseIdTargetNavigation == null)
           return "differentBL";

        if (bt.ExpenseIdSourceNavigation.BudgetLineId != bt.ExpenseIdTargetNavigation.BudgetLineId)
           return "differentBL";

        if(bt.ExpenseIdSourceNavigation.BudgetLineId == bt.ExpenseIdTargetNavigation.BudgetLineId 
        && (bt.ExpenseIdSourceNavigation.ActivityId != bt.ExpenseIdTargetNavigation.ActivityId 
            || bt.ExpenseIdSourceNavigation.Activity.DSPId != bt.ExpenseIdTargetNavigation.Activity.DSPId))
           return "differentLL";

           return "";

    }

    //private List<LookupListItem> GetActivityCodeList(long awpId)
    //{
    //    List<LookupListItem> query;

    //    query = (from item in misContext.Activity
    //        .Include(p => p.Awp)
    //        .Include(p => p.Strategy)
    //        .Include(p => p.Unit)
    //        .Include(p => p.Dsp)
    //        .Where(p => p.AWPId.GetValueOrDefault() == awpId)
    //        .Where(p => p.ActivityIsDeleted != true)
    //        .Where(p => p.ActivityIsValidated == true)
    //        .Where(p => GetActivityCode(p)).ToList()
    //             select new LookupListItem()
    //             {
    //                 Text = item.ActivityCode,
    //                 Value = item.ActivityId,
    //                 ExtraData = item.AWPId.ToString(),
    //                 ExtraDataII = item.ActivityName,
    //             }).ToList();
    //    query.Insert(0, new LookupListItem() { Text = "--", Value = 0, ExtraData = "" });

    //    return query;
    //}

    //public bool GetActivityCode(Activity p)
    //{
    //    p.ActivityCode = Helper.GetCode(p);
    //    return true;
    //}

    //private string SetStatusIcon(PendingExpenseTransfer bt)
    //{
    //    if (bt.PetStatus == null)
    //    {
    //        return @"\Images\GrayDot.png";
    //    }
    //    if (bt.PetStatus.PetIsExecuted.GetValueOrDefault())
    //    {
    //        return @"\Images\BlueDot.png";
    //    }
    //    if (bt.PetStatus.PetIsPending.GetValueOrDefault())
    //    {
    //        return @"\Images\OrangeDot.png";
    //    }
    //    if (bt.PetStatus.PetIsRejected.GetValueOrDefault())
    //    {
    //        return @"\Images\RedDot.png";
    //    }
    //    else return @"\Images\GrayDot.png";
    //}

    #endregion


    }
}