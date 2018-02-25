using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System;
using ECDC.MIS.API.Misc;
using ECDC.MIS.API.Model;

namespace ECDC.MIS.API.DI
{
    public interface ILookupRepository
    {
        List<LookupListItem> BudgetLineList { get; set; }
        List<LookupListItem> UserList { get; set; }
        List<LookupListItem> LocationList { get; set; }
        List<LookupListItem> MeetingStatusList { get; set; }
        List<LookupListItem> AwpList { get; set; }
        List<LookupListItem> StrategyList { get; set; }
        List<LookupListItem> UnitList { get; set; }
        List<LookupListItem> DPList { get; set; }
        List<LookupListItem> SectionList { get; set; }
        List<LookupListItem> ActivityStatusList { get; set; }
        List<LookupListItem> ExpenseTypeList { get; set; }
        List<LookupListItem> ProcTypeList { get; set; }
        List<LookupListItem> ProcConTypeList { get; set; }
        List<LookupListItem> ProcFrameworkTypeList { get; set; }
        List<LookupListItem> UserGradeList { get; set; }
        List<LookupListItem> UserRoleList { get; set; }
        List<LookupListItem> TagList { get; set; }
        List<LookupListItem> ProcOfficerList { get; set; }
        List<LookupListItem> AuthOfficerList { get; set; }
        List<LookupListItem> FinanceInitiatorList { get; set; }
        List<LookupListItem> ProcStatusList { get; set; }
        List<LookupListItem> BudgetTransferStatusList { get; set; }
        List<LookupListItem> ExpenseStaffStatusList { get; set; }
        List<LookupListItem> ExpensePlatoStatusList { get; set; }
        List<LookupListItem> FunctionalGroupList { get; set; }
        List<LookupListItem> RecurrenceList { get; set; }
        List<LookupListItem> CapacityLevelList { get; set; }
        List<LookupListItem> SpdObjectivelList { get; set; }
        List<LookupListItem> SpdKeyOutputList { get; set; }
        List<LookupListItem> ProcTimingStatusList { get; set; }
        List<LookupListItem> PriorityList { get; set; }
        List<LookupListItem> ProcFinancingDecisionList { get; set; }
    }

    public class LookupRepository : ILookupRepository
    {
        private IMemoryCache memoryCache;

        #region properties

        public List<LookupListItem> BudgetLineList { get; set; }
        public List<LookupListItem> UserList { get; set; }
        public List<LookupListItem> LocationList { get; set; }
        public List<LookupListItem> MeetingStatusList { get; set; }
        public List<LookupListItem> AwpList { get; set; }
        public List<LookupListItem> StrategyList { get; set; }
        public List<LookupListItem> UnitList { get; set; }
        public List<LookupListItem> DPList { get; set; }
        public List<LookupListItem> SectionList { get; set; }
        public List<LookupListItem> ActivityStatusList { get; set; }
        public List<LookupListItem> ExpenseTypeList { get; set; }
        public List<LookupListItem> ProcTypeList { get; set; }
        public List<LookupListItem> ProcConTypeList { get; set; }
        public List<LookupListItem> UserGradeList { get; set; }
        public List<LookupListItem> UserRoleList { get; set; }
        public List<LookupListItem> TagList { get; set; }
        public List<LookupListItem> ProcOfficerList { get; set; }
        public List<LookupListItem> AuthOfficerList { get; set; }
        public List<LookupListItem> FinanceInitiatorList { get; set; }
        public List<LookupListItem> ProcStatusList { get; set; }
        public List<LookupListItem> BudgetTransferStatusList { get; set; }
        public List<LookupListItem> ExpenseStaffStatusList { get; set; }
        public List<LookupListItem> ExpensePlatoStatusList { get; set; }
        public List<LookupListItem> FunctionalGroupList { get; set; }
        public List<LookupListItem> RecurrenceList { get; set; }
        public List<LookupListItem> CapacityLevelList { get; set; }
        public List<LookupListItem> SpdObjectivelList { get; set; }
        public List<LookupListItem> SpdKeyOutputList { get; set; }
        public List<LookupListItem> ProcTimingStatusList { get; set; }
        public List<LookupListItem> ProcFrameworkTypeList { get; set; }
        public List<LookupListItem> PriorityList { get; set; }
        public List<LookupListItem> ProcFinancingDecisionList { get; set; }
        #endregion

        public LookupRepository(MISContext misContext, IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;

            //Get generics lookup using IsInactive bool
            SectionList = GetLookupListNew(misContext.Section);
            //BudgetLineList = GetLookupListNew<BudgetLine>(misContext.BudgetLine);
            StrategyList = GetLookupListNew<Strategy>(misContext.Strategy);
            ActivityStatusList = GetLookupListNew<ActivityStatus>(misContext.ActivityStatus);
            //MeetingStatusList = GetLookupListNew<MeetingStatus>(misContext.MeetingStatus);
            AwpList = GetLookupListNew<AnnualWorkPlan>(misContext.AnnualWorkPlan);
            DPList = GetLookupListNew<Dsp>(misContext.Dsp);
            //ProcTypeList = GetLookupListNew<ProcurementType>(misContext.ProcurementType);
            //ProcConTypeList = GetLookupListNew<ProcurementContractType>(misContext.ProcurementContractType);
            //ProcFrameworkTypeList = GetLookupListNew<ProcurementFrameworkType>(misContext.ProcurementFrameworkType);
            //UserGradeList = GetLookupListNew<UserGrade>(misContext.UserGrade);
            //UserRoleList = GetLookupListNew<UserRole>(misContext.UserRole);
            //TagList = GetLookupListNew<Tag>(misContext.Tag);
            //BudgetTransferStatusList = GetLookupListNew<PendingTransferStatus>(misContext.PendingTransferStatus);
            //ExpenseStaffStatusList = GetLookupListNew<ExpenseStaffStatus>(misContext.ExpenseStaffStatus);
            UnitList = GetLookupListNew<Unit>(misContext.Unit);
            //ExpenseTypeList = GetLookupListNew<ExpenseType>(misContext.ExpenseType);
            UserList = GetLookupListNew<UserApplication>(misContext.UserApplication).OrderBy(p => p.Text).ToList();
            //ProcStatusList = GetLookupListNew<ProcurementStatus>(misContext.ProcurementStatus).OrderBy(p => Int32.Parse(p.ExtraData)).ToList() ;
            //ProcTimingStatusList = GetLookupListNew<ProcurementTimingStatus>(misContext.ProcurementTimingStatus);
            //ProcOfficerList = GetLookupListNew<UserApplication>(misContext.UserApplication, "ProcOfficer").OrderBy(p => p.Text).ToList();
            //AuthOfficerList = GetLookupListNew<UserApplication>(misContext.UserApplication, "AuthOfficer").OrderBy(p => p.Text).ToList();
            //FinanceInitiatorList = GetLookupListNew<UserApplication>(misContext.UserApplication, "FinanceInitiator").OrderBy(p => p.Text).ToList();
            //LocationList = GetLookupListNew<Location>(misContext.Location);
            //ExpensePlatoStatusList = GetLookupListNew<ExpensePlatoStatus>(misContext.ExpensePlatoStatus);
            //FunctionalGroupList = GetLookupListNew<GroupActivity>(misContext.GroupActivity);
            //RecurrenceList = GetLookupListNew<Recurrence>(misContext.Recurrence);
            //CapacityLevelList = GetLookupListNew<CapacityLevel>(misContext.CapacityLevel);
            //SpdObjectivelList = GetLookupListNew<SpdObjective>(misContext.SpdObjective);
            //SpdKeyOutputList = GetLookupListNew<SpdKeyOutput>(misContext.SpdKeyOutput);
            //PriorityList = GetLookupListNew<Priority>(misContext.Priority);
            //ProcFinancingDecisionList = GetLookupListNew<ProcurementFinancingDecision>(misContext.ProcurementFinancingDecision);
        }

        #region Get LookupList methods

        private List<LookupListItem> GetLookupListNew<T>(DbSet<T> dbTable) where T : class, ILookupData
        {
            return GetLookupListNew<T>(dbTable, typeof(T).Name);
        }

        private List<LookupListItem> GetLookupListNew<T>(DbSet<T> dbTable, string name) where T : class, ILookupData
        {
            List<LookupListItem> cached;

            if (!memoryCache.TryGetValue(name, out cached))
            {
                cached = new List<LookupListItem>();

                //We load data from database
                List<T> myList = dbTable.AsNoTracking().Where(p => p.IsInactive != true).ToList();

                //We add default element in result list
                if (typeof(T).Name == typeof(Section).Name || typeof(T).Name == typeof(ProcurementStatus).Name)
                {
                    cached.Add(new LookupListItem() { Text = "--", ExtraDataII = "--", Value = 0, ExtraData = "0" });
                }
                else
                {
                    cached.Add(new LookupListItem() { Text = "--", ExtraDataII = "--", Value = 0, ExtraData = "" });
                }

                //We add rest of element to result list
                LookupListItem lookupListItem;
                foreach (var item in myList)
                {
                    lookupListItem = new LookupListItem();
                    lookupListItem.Text = item.Text;
                    lookupListItem.Value = item.Value;

                    if (typeof(T).Name == typeof(BudgetLine).Name)
                    {
                        lookupListItem.ExtraData = ((BudgetLine)(object)item).Mawpid.ToString();
                        lookupListItem.ExtraDataII = ((BudgetLine)(object)item).BudgetLineName.Substring(0, 4);
                    }
                    if (typeof(T).Name == typeof(Strategy).Name)
                    {
                        lookupListItem.ExtraData = ((Strategy)(object)item).Mawpid.ToString();
                        lookupListItem.ExtraDataII = string.Format("{0} | {1}", ((Strategy)(object)item).StartegyName.ToString(),  ((Strategy)(object)item).StrategyDescription.ToString());
                    }
                    if (typeof(T).Name == typeof(ActivityStatus).Name)
                    {
                        lookupListItem.ExtraData = ((ActivityStatus)(object)item).ActStatusImgPath.ToString();
                    }
                    if (typeof(T).Name == typeof(AnnualWorkPlan).Name)
                    {
                        lookupListItem.ExtraData = ((AnnualWorkPlan)(object)item).Mawpid.ToString();
                    }
                    if (name == "ProcOfficer")
                    {
                        if (((UserApplication)(object)item).UserRoleId.GetValueOrDefault() != 13 && ((UserApplication)(object)item).UserRoleIdBis != 13)
                            continue;
                    }
                    if (name == "AuthOfficer")
                    {
                        if (((UserApplication)(object)item).UserRoleId.GetValueOrDefault() != 4 && ((UserApplication)(object)item).UserRoleIdBis != 4)
                            continue;
                    }
                    if (name == "FinanceInitiator")
                    {
                        if (((UserApplication)(object)item).UserRoleId.GetValueOrDefault() != 11 && ((UserApplication)(object)item).UserRoleIdBis != 11)
                            continue;
                    }
                    if (typeof(T).Name == typeof(Location).Name)
                    {
                        if (((Location)(object)item).LocationIsCountry != true)
                            continue;
                    }
                    if (typeof(T).Name == typeof(Section).Name)
                    {
                        lookupListItem.ExtraData = ((Section)(object)item).UnitId.ToString();
                    }
                    if (typeof(T).Name == typeof(GroupActivity).Name)
                    {
                        lookupListItem.ExtraData = ((GroupActivity)(object)item).Awpid.ToString();
                    }
                    if (typeof(T).Name == typeof(SpdKeyOutput).Name)
                    {
                        lookupListItem.ExtraData = ((SpdKeyOutput)(object)item).Awpid.ToString();
                    }
                    if (typeof(T).Name == typeof(SpdObjective).Name)
                    {
                        lookupListItem.ExtraData = ((SpdObjective)(object)item).Awpid.ToString();
                    }
                    if (typeof(T).Name == typeof(ProcurementStatus).Name)
                    {
                        lookupListItem.ExtraData = ((ProcurementStatus)(object)item).ProcStatusOrder.ToString();
                        if (string.IsNullOrEmpty(lookupListItem.ExtraData))
                            lookupListItem.ExtraData = "0";
                    }
                    cached.Add(lookupListItem);
                }

                memoryCache.Set(name, cached);
            }

            return cached;
        }

        #endregion

        #region Get User methods

        private UserApplication GetUserDetails(MISContext MISContext, string userName)
        {
            var result = MISContext.UserApplication
                            .Include(p => p.UserRole)
                            .Include(p => p.UserRoleBis)
                            .Include(p => p.UserGrade)
                            .Include(p => p.Unit)
                            .Include(p => p.Dsp)
                            .Include(p => p.Section)
                            .Where(p => p.UserLoginName == userName).FirstOrDefault();

            if (result.UserRoleBis == null)
                result.UserRoleBis = new UserRole();

            return result;
        }

        #endregion
    }
}
