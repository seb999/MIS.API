using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECDC.MIS.API.DI;
using ECDC.MIS.API.Misc;
using System.Collections.Generic;
using System.Linq;
using System;
using ECDC.MIS.API.Model;
using ECDC.MIS.API.TransferClass;
using ECDC.MIS.API.ExportClass;

namespace ECDC.MIS.API.Controllers
{
    [Route("/api/[controller]")]
    public class ProcurementController : Controller
    {
        private readonly MISContext misContext;
        private readonly UserApplication currentUser;
        //private readonly LogService logService;
        public List<UserApplication> UserApplicationList { get; set; }
        //public ILookupActivity ActivityLookupList { get; }

        //public ProcurementController([FromServices]MISContext misContext, LogService logService,ILookupUser lookupUser, ILookupActivity lookupActivity)
        public ProcurementController([FromServices]MISContext misContext, ILookupUser lookupUser)
        {
            this.misContext = misContext;
            //this.logService = logService;
            this.currentUser = lookupUser.CurrentUser;
            //ActivityLookupList = lookupActivity;
            UserApplicationList = lookupUser.UserApplicationList;
        }

        #region Procurement list

        /// <summary>
        /// Get list of procurement for a awpId
        /// </summary>
        /// <param name="awpId">The awpid (ex : 2017 awpId = 9)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{awpId}")]
        public IEnumerable<ProcurementTransfer> Get(long awpId)
        {
            var query = (from expense in misContext.Expense.AsNoTracking()
               .Include(p => p.Activity).AsNoTracking()
               .Include(p => p.Activity.Strategy).AsNoTracking()
               .Include(p => p.Activity.Unit).AsNoTracking()
               .Include(p => p.Activity.Dsp).AsNoTracking()
               .Where(p => p.Activity.AWPId.GetValueOrDefault() == awpId)
               .Where(p=>p.ExpenseIsApproved == true)
               .Where(p => p.Activity.ActivityIsDeleted != true)
               .Where(p => p.Activity.ActivityIsValidated == true)
               .Where(p => p.Activity.ActivityIsApproved == true)
               .Where(p => p.ExpenseType.ExpenseTypeIsProcurement.GetValueOrDefault())
                select new ProcurementTransfer
                {
                    StatusIcon = SetStatusIcon(expense.ProcTimingStatus),
                    StatusTooltip = expense.ProcTimingStatus ==null ? "No status" : expense.ProcTimingStatus.ProcTimingStatusName ,
                    ExpenseId = expense.ExpenseId,
                    ExpenseIdName = expense.ExpenseId.ToString(),
                    BudgetLineCode = expense.BudgetLine.BudgetLineName.Substring(0, 4),
                    BudgetLineId = expense.BudgetLineId,
                    ActivityCode = Helper.GetCode(new Activity() { ActivityId = expense.Activity.ActivityId, ActivityCodeSequence = expense.Activity.ActivityCodeSequence, Strategy = expense.Activity.Strategy, Unit = expense.Activity.Unit, Awp = expense.Activity.Awp, Dsp = expense.Activity.Dsp }),
                    ProcurementName = expense.ExpenseName,
                    ProjectManager = SetUserFullName(expense.UserIdOwner),
                    ProjectManagerId = expense.UserIdOwner,
                    AuthOfficer = SetUserFullName(expense.UserIdAuthOfficer),
                    AuthOfficerId = expense.UserIdAuthOfficer,
                    ProcOfficer = SetUserFullName(expense.UserIdProcurementOfficer),
                    ProcOfficerId = expense.UserIdProcurementOfficer,
                    Amount = expense.ExpenseAmount,
                    TotalBudget = 1,
                    ProcurementType = expense.ProcType != null ? expense.ProcType.ProcTypeName : "",
                    ProcTypeId = expense.ProcTypeId,
                    //ContractType = expense.ContractType != null ? expense.ContractType.ContractTypeName : "",
                    ContractType = expense.ProcConType == null ? "" : expense.ProcConType.ProcConTypeName,
                    ProcStatus = expense.ProcStatus != null ? expense.ProcStatus.ProcStatusName : "",
                    ProcStatusId = expense.ProcStatusId,
                    Comment = expense.ProcComment == null ? "" : expense.ProcComment,
                    UnitCode = expense.Activity.Unit.UnitCode,
                    UnitId = expense.Activity.UnitId,
                    DPCode = expense.Activity.Dsp.DspCode,
                    DpId = expense.Activity.DSPId,
                    SectionCode = expense.Activity.Section.SectionCode,
                    SectionId = expense.Activity.SectionId,
                }).ToList();

            //Table doesn't exit in prod yet : WAIT
            //foreach (var p in query)
            //{
            //    GetProcData(p);
            //}

            return query;
        }

        #endregion

        /// <summary>
        /// Get a procurement for a specific ExpenseId. Get data from Expense table and data from Procurement2 table
        /// </summary>
        /// <param name="expenseId">The expense id</param>
        /// <returns>The ProcurementTransfer data for the UI</returns>
        [HttpGet]
        [Route("GetProcurement/{expenseId}")]
        public ProcurementTransfer GetProcurement(long expenseId)
        {
            var query = (from expense in misContext.Expense
                        .Include(p=>p.Procurement2)
                        .Include(p=>p.ProcurementStage)
                         where expense.ExpenseId == expenseId
                        select new ProcurementTransfer()
                        {
                            ExpenseId = expense.ExpenseId,
                            BudgetLineCode = expense.BudgetLine.BudgetLineName,
                            ActivityName = expense.Activity.ActivityName,
                            ProcurementName = expense.ExpenseName,
                            Comment = expense.ProcComment == null ? "" : expense.ProcComment,
                            Amount = expense.ExpenseAmount,
                            ProcTypeId = expense.ProcTypeId,
                            ProcTypeName = expense.ProcType == null ? "" : expense.ProcType.ProcTypeName,
                            ProcConTypeId = expense.ProcConTypeId,
                            ProcConTypeName = expense.ProcConType == null ? "" : expense.ProcConType.ProcConTypeName,
                            ProcTimingStatusId = expense.ProcTimingStatusId,
                            ProcTimingStatusName = expense.ProcTimingStatus == null ? "" : expense.ProcTimingStatus.ProcTimingStatusName,
                            ProcStatusId = expense.ProcStatusId,
                            ProcStatusName = expense.ProcStatus == null ? "" : expense.ProcStatus.ProcStatusName,
                            OwnerId = expense.UserIdOwner,
                            OwnerName = expense.UserIdOwnerNavigation == null ? "" : expense.UserIdOwnerNavigation.UserFirstName + "" + expense.UserIdOwnerNavigation.UserLastName,
                            AuthOfficerId = expense.UserIdAuthOfficer,
                            AuthOfficerName = expense.UserIdAuthOfficerNavigation == null ? "" : expense.UserIdAuthOfficerNavigation.UserFirstName + "" + expense.UserIdAuthOfficerNavigation.UserLastName,
                            ProcOfficerId = expense.UserIdProcurementOfficer,
                            ProcOfficerName = expense.UserIdProcurementOfficerNavigation == null ? "" : expense.UserIdProcurementOfficerNavigation.UserFirstName + "" + expense.UserIdProcurementOfficerNavigation.UserLastName,
                            FinanceAssistantId = expense.UserIdFinancialAssistant,
                            FinanceAssistantName = expense.UserIdFinancialAssistantNavigation == null ? "" : expense.UserIdFinancialAssistantNavigation.UserFirstName + "" + expense.UserIdFinancialAssistantNavigation.UserLastName,
                            FrameworkTypeId = expense.ProcFrameworkTypeId,
                            FrameworkTypeName = expense.ProcFrameworkType == null ? "" : expense.ProcFrameworkType.ProcFrameworkTypeName,
                            DateAdded = expense.DateAdded
                        }).FirstOrDefault();

            //GetProcurementStages(query);
            GetProcData(query);            
            return query;
        }

        /// <summary>
        /// Get a list of available procurement status by procurement type
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAvailableStatusListByType/{typeId}")]
        public List<long> GetAvailableStatusListByType(long typeId)
        {
            var statusListIds = misContext.ProcurementStatus.Where(
             p => p.ProcurementStatusWorkflow.Any(psw => psw.ProcTypeId == typeId) == false 
             || p.ProcurementStatusWorkflow.Any(psw => psw.ProcTypeId == typeId && psw.ProcStatusWorkflowIsInactive != true)).Select(p => p.ProcStatusId).ToList();

            return statusListIds;
        }

        /// <summary>
        /// Get procurement data from an expenseId in procurement2 table
        /// </summary>
        /// <param name="procurementTransfer"></param>
        /// <returns></returns>
        private void GetProcData(ProcurementTransfer procurementTransfer)
        {
            Procurement2 proc = misContext.Procurement2.Where(
                p => p.ExpenseId == procurementTransfer.ExpenseId 
                && !p.ProcParentId.HasValue).FirstOrDefault();

            if(proc != null)
            {
                
                    procurementTransfer.ProcContractedAmount = proc.ProcContractedAmount.GetValueOrDefault();
                    procurementTransfer.ImplementationIsProc = proc.ProcImplementationIsProc;
                    procurementTransfer.ImplementationIsGrant = proc.ProcImplementationIsGrant;
                    procurementTransfer.TypeIsOpen = proc.ProcTypeIsOpen;
                    procurementTransfer.TypeIsNegociated = proc.ProcTypeIsNegociated;
                    procurementTransfer.PlannedKickoffDate = proc.ProcPlannedKickoffDate;
                    procurementTransfer.CurrentKickoffDate = proc.ProcCurrentKickoffDate;
                    procurementTransfer.PlannedExpectedLaunch = proc.ProcPlannedExpectedLaunch;
                    procurementTransfer.CurrentExpectedLaunch = proc.ProcCurrentExpectedLaunch;
                    procurementTransfer.CurrentExpectedContractSignature = proc.ProcCurrentExpectedContractSignature;
                    procurementTransfer.PlannedExpectedContractSignature = proc.ProcPlannedExpectedContractSignature;
                    //procurementTransfer.AwardNoticeDispatch = proc.ProcAwardNoticeDispatch;
                    procurementTransfer.ActualLaunchDate = proc.ProcActualLaunchDate;
                    procurementTransfer.SignatureContract = proc.ProcSignatureContract;
                    procurementTransfer.ExpectedSubmissionDocCpcg = proc.ProcExpectedSubmissionDocCpcg;
                    procurementTransfer.NumberFwc = proc.ProcNumberFwc;
                    procurementTransfer.CpcgIsYes = proc.ProcCpcgIsYes;
                    procurementTransfer.CpcgIsNo = proc.ProcCpcgIsNo;
                    procurementTransfer.DmsUrl = proc.DmsUrl;
                    procurementTransfer.ProcFinancingDecisionId = proc.ProcFinancingDecisionId;
                    procurementTransfer.ProcFinancingDecisionName = misContext.ProcurementFinancingDecision.Where(p => p.ProcFinancingDecisionId == proc.ProcFinancingDecisionId).Select(p => p.ProcFinancingDecisionName).FirstOrDefault();
                    //Add here TimingStatus, Owner, Authorising officer, procurement officer, financial assisstant
                    //If we decide to have procurememnt children!!
              
            }
        }

        #region save

        /// <summary>
        /// Save procurement data in Expense table
        /// </summary>
        /// <param name="procTransfer"></param>
        [HttpPost]
        public void Post([FromBody]ProcurementTransfer procTransfer)
        {
            try
            {
                Expense expense = misContext.Expense.
                    Include(e=>e.ProcurementStage).
                    Where(p => p.ExpenseId == procTransfer.ExpenseId).FirstOrDefault();
                bool isAdd = false;

                if (expense != null)
                {
                    expense.DateMod = DateTime.Now;
                    expense.UserMod = currentUser.UserId;
                }
                else
                {
                    isAdd = true;
                    expense = new Expense()
                    {
                        DateAdded = DateTime.Now,
                        UserAdded = currentUser.UserId,
                    };
                }

                expense.ExpenseName = procTransfer.ProcurementName;
                expense.ProcComment = procTransfer.Comment;
                expense.ProcTypeId = procTransfer.ProcTypeId;
                expense.ProcConTypeId = procTransfer.ProcConTypeId;
                expense.ProcTimingStatusId = procTransfer.ProcTimingStatusId;
                expense.ProcStatusId = procTransfer.ProcStatusId;
                expense.UserIdOwner = procTransfer.OwnerId;
                expense.UserIdAuthOfficer = procTransfer.AuthOfficerId;
                expense.UserIdProcurementOfficer = procTransfer.ProcOfficerId;
                expense.UserIdFinancialAssistant = procTransfer.FinanceAssistantId;
                expense.ProcFrameworkTypeId = procTransfer.FrameworkTypeId;

                if (isAdd)
                {
                    misContext.Entry(expense).State = EntityState.Added;
                }
                else
                {
                    misContext.Entry(expense).State = EntityState.Modified;
                }

                
                misContext.SaveChanges();
                //SaveProcurementStages(expense, procTransfer.ProcurementStages);
                SaveProcData(procTransfer);
            }
            catch (Exception ex)
            {
                //logService.SaveLog(currentUser.UserId, LogType.Error, MISPage.ProcurementPage, ex, Method.SaveProcurement);
            }
        }
    
        /// <summary>
        /// Save proc data in Procurement table
        /// </summary>
        /// <param name="procTransfer"></param>
        private void SaveProcData(ProcurementTransfer procTransfer)
        {
            try
            {
                Procurement2 proc = misContext.Procurement2.Where(p => p.ExpenseId == procTransfer.ExpenseId).FirstOrDefault();
                bool isAdd = false;

                if (proc != null)
                {
                    proc.DateMod = DateTime.Now;
                    proc.UserMod = currentUser.UserId;
                }
                else
                {
                    isAdd = true;
                    proc = new Procurement2()
                    {
                        DateAdded = DateTime.Now,
                        UserAdded = currentUser.UserId,
                    };
                }

                proc.ExpenseId = procTransfer.ExpenseId;
                proc.ProcTypeId = procTransfer.ProcTypeId;
                proc.ProcConTypeId = procTransfer.ProcConTypeId;
                proc.ProcFinancingDecisionId = procTransfer.ProcFinancingDecisionId;
                proc.ProcContractedAmount = procTransfer.ProcContractedAmount;
                proc.ProcComment = procTransfer.Comment;
                proc.ProcPlannedKickoffDate = procTransfer.PlannedKickoffDate;
                proc.ProcCurrentKickoffDate = procTransfer.CurrentKickoffDate;
                proc.ProcPlannedExpectedLaunch = procTransfer.PlannedExpectedLaunch;
                proc.ProcCurrentExpectedLaunch = procTransfer.CurrentExpectedLaunch;
                proc.ProcCurrentExpectedContractSignature = procTransfer.CurrentExpectedContractSignature;
                proc.ProcPlannedExpectedContractSignature = procTransfer.PlannedExpectedContractSignature;
                //proc.ProcAwardNoticeDispatch = procTransfer.AwardNoticeDispatch;
                proc.ProcActualLaunchDate = procTransfer.ActualLaunchDate;
                proc.ProcSignatureContract = procTransfer.SignatureContract;
                proc.ProcExpectedSubmissionDocCpcg = procTransfer.ExpectedSubmissionDocCpcg;
                //checkboxes
                proc.ProcNumberFwc = procTransfer.NumberFwc;
                proc.ProcCpcgIsYes = procTransfer.CpcgIsYes;
                proc.ProcCpcgIsNo = procTransfer.CpcgIsNo;
                proc.ProcImplementationIsGrant = procTransfer.ImplementationIsGrant;
                proc.ProcImplementationIsProc = procTransfer.ImplementationIsProc;
                proc.ProcTypeIsOpen = procTransfer.TypeIsOpen;
                proc.ProcTypeIsNegociated = procTransfer.TypeIsNegociated;
                proc.DmsUrl = procTransfer.DmsUrl;
                if (isAdd)
                {
                    misContext.Entry(proc).State = EntityState.Added;
                }
                else
                {
                    misContext.Entry(proc).State = EntityState.Modified;
                }
                misContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //logService.SaveLog(currentUser.UserId, LogType.Error, MISPage.ProcurementPage, ex, Method.SaveChildProcurement);
            }
        }

        /// <summary>
        /// Save proc stages in ProcurementStage table
        /// </summary>
        /// <param name="expense"></param>
        /// <param name="procurementStages"></param>
        //private void SaveProcurementStages(Expense expense, List<ProcurementStageTransfer> procurementStages)
        //{
        //    try
        //    {
        //        foreach (var stage in procurementStages)
        //        {
        //            var existentStage = expense.ProcurementStage.FirstOrDefault(s => (s.ProcStageId == stage.ProcStageId && stage.ProcStageId != 0) || s.ProcStatusId == stage.ProcStatusId);

        //            if (existentStage == null)
        //            {
        //                var newStage = new ProcurementStage();
        //                newStage.ProcStatusId = stage.ProcStatusId;
        //                newStage.ProcStageCompletedDate = stage.ProcStageCompletedDate;
        //                newStage.ProcStageCompleted = stage.ProcStageCompleted;
        //                newStage.DateAdded = DateTime.Now;
        //                newStage.UserAdded = currentUser.UserId;
        //                expense.ProcurementStage.Add(newStage);
        //            }
        //            else
        //            {
        //                existentStage.ProcStageCompletedDate = stage.ProcStageCompletedDate;
        //                existentStage.ProcStageCompleted = stage.ProcStageCompleted;
        //                existentStage.DateMod = DateTime.Now;
        //                existentStage.UserMod = currentUser.UserId;
        //            }


        //        }
        //        misContext.SaveChanges();
        //    }
        //    catch(Exception ex)
        //    {
        //        logService.SaveLog(currentUser.UserId, LogType.Error, MISPage.ProcurementPage, ex, Method.SaveProcurementStages);
        //    }
        //}
        #endregion

        #region Export to Csv

        /// <summary>
        /// Get data to export to csv file
        /// </summary>
        /// <param name="awpId">The awpid</param>
        /// <returns>List of ProcurementExport for the awpid selected</returns>
        [HttpGet]
        [Route("ExportData/{awpId}")]
        //[ResponseCache(NoStore = true, Duration = 0)]
        public IEnumerable<ProcurementExport> ExportData(long awpId)
        {
            misContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var query = (from expense in misContext.Expense.AsNoTracking()
               .Include(p => p.Activity).AsNoTracking()
               .Include(p => p.Activity.Strategy).AsNoTracking()
               .Include(p => p.Activity.Unit).AsNoTracking()
               .Include(p => p.Activity.Dsp).AsNoTracking()
               .Where(p => p.Activity.AWPId.GetValueOrDefault() == awpId)
               .Where(p => p.ExpenseIsApproved == true)
               .Where(p => p.Activity.ActivityIsDeleted != true)
               .Where(p => p.Activity.ActivityIsValidated == true)
               .Where(p => p.Activity.ActivityIsApproved == true)
               .Where(p => p.ExpenseType.ExpenseTypeIsProcurement.GetValueOrDefault())
                         select new ProcurementExport
                         {
                             ExpenseId = expense.ExpenseId,
                             BudgetLineCode = expense.BudgetLine.BudgetLineName,
                             ActivityCode = Helper.GetCode(new Activity() { ActivityId = expense.Activity.ActivityId, ActivityCodeSequence = expense.Activity.ActivityCodeSequence, Strategy = expense.Activity.Strategy, Unit = expense.Activity.Unit, Awp = expense.Activity.Awp, Dsp = expense.Activity.Dsp }),
                             ProcurementName = expense.ExpenseName,
                             ProjectManager = SetUserFullName(expense.UserIdOwner),
                             AuthOfficer = SetUserFullName(expense.UserIdAuthOfficer),
                             ProcOfficer = SetUserFullName(expense.UserIdProcurementOfficer),
                             Amount = expense.ExpenseAmount,
                             ProcurementType = expense.ProcType != null ? expense.ProcType.ProcTypeName : "",
                             ContractType = expense.ProcConType == null ? "" : expense.ProcConType.ProcConTypeName,
                             Status = expense.ProcStatus != null ? expense.ProcStatus.ProcStatusName : "",
                             NextDeadline = DateTime.Now,
                             // {{(expense.plannedExpectedContractSignature ? procurement.plannedExpectedContractSignature : (procurement.plannedExpectedLaunch ? procurement.plannedExpectedLaunch : procurement.plannedKickoffDate))| date :'dd/MM/yyyy'}
                             Comment = expense.ProcComment == null ? "" : expense.ProcComment,
                         }).ToList();

            //foreach(var p in query)
            //{
            //    GetProcData(p);
            //}

            return query;
        }

        #endregion

        #region helper

        private string SetStatusIcon(ProcurementTimingStatus procTimingStatus)
        {
            if (procTimingStatus == null)
            {
                return @"\Images\GrayDot.png";
            }
            if (procTimingStatus.ProcTimingStatusName.Replace(" ", "") == ProcTimingSatus.OnTrack.ToString())
            {
                return @"\Images\GreenDot.png";
            }
            if (procTimingStatus.ProcTimingStatusName.Replace(" ", "") == ProcTimingSatus.AtRisk.ToString())
            {
                return @"\Images\OrangeDot.png";
            }
            if (procTimingStatus.ProcTimingStatusName == ProcTimingSatus.Delay.ToString())
            {
                return @"\Images\RedDot.png";
            }
            if (procTimingStatus.ProcTimingStatusName == ProcTimingSatus.Signed.ToString())
            {
                return @"\Images\BlueDot.png";
            }
            if (procTimingStatus.ProcTimingStatusName == ProcTimingSatus.Cancelled.ToString())
            {
                return @"\Images\Delete.png";
            }
            else return @"\Images\GrayDot.png";
        }

        private string SetUserFullName(long? userIdOwner)
        {
            if (userIdOwner == null) return "";
            return UserApplicationList.Where(p => p.UserId == userIdOwner).Select(p => p.UserFullName).FirstOrDefault();
        }

        /// <summary>
        /// Get proc stages from ProcurementStage table
        /// </summary>
        /// <param name="procurementTransfer"></param>
        //private void GetProcurementStages(ProcurementTransfer procurementTransfer)
        //{
        //    List<ProcurementStageTransfer> stages = new List<ProcurementStageTransfer>();
        //    var statuses = misContext.ProcurementStatus.OrderBy(p => p.ProcStatusOrder);        
        //    List<ProcurementStage> dbStages = misContext.ProcurementStage.Where(ps => ps.ExpenseId == procurementTransfer.ExpenseId).ToList();

        //    foreach (var status in statuses)
        //    {
        //        var dbStage = dbStages.FirstOrDefault(ps => ps.ProcStatusId == status.ProcStatusId);
        //        if (dbStage != null)
        //        {
        //            stages.Add(new ProcurementStageTransfer()
        //            {
        //                ProcStatusId = status.ProcStatusId,
        //                Order = status.ProcStatusOrder ?? 0,
        //                ProcStageId = dbStage.ProcStageId,
        //                ProcStageCompleted = dbStage.ProcStageCompleted,
        //                ProcStageCompletedDate = dbStage.ProcStageCompletedDate,
        //                StatusName = status.ProcStatusName,
        //                IgnoreRules = status.IgnoreRules == true
        //            });
        //        }
        //        else
        //        {
        //            stages.Add(new ProcurementStageTransfer()
        //            {
        //                ProcStatusId = status.ProcStatusId,
        //                ProcStageId = 0,
        //                StatusName = status.ProcStatusName,
        //                IgnoreRules = status.IgnoreRules == true
        //            });
        //        }
        //    }
        //    procurementTransfer.ProcurementStages = stages;
        //}
        #endregion


    }
}
