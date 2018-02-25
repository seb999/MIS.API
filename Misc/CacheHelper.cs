using ECDC.MIS.API.Model;
using Microsoft.Extensions.Caching.Memory;

namespace ECDC.MIS.API.Misc
{
    public static class CacheHelper
    {
        public static void ClearLookupCache(IMemoryCache cache)
        {
            ClearCache<BudgetLine>(cache);
            ClearCache<Strategy>(cache);
            ClearCache<Section>(cache);
            ClearCache<ActivityStatus>(cache);
            ClearCache<UserApplication>(cache);
            ClearCache<Location>(cache);
            ClearCache<MeetingStatus>(cache);
            ClearCache<AnnualWorkPlan>(cache);
            ClearCache<Unit>(cache);
            ClearCache<Dsp>(cache);
            ClearCache<ExpenseType>(cache);
            ClearCache<ProcurementType>(cache);
            ClearCache<ProcurementContractType>(cache);
            ClearCache<UserGrade>(cache);
            ClearCache<UserRole>(cache);
            //ClearCache<TagHelper>(cache);
            ClearCache<Expense>(cache, "LookupList");
           // ClearCache<LookupExpenseItem>(cache);
            ClearCache<UserApplication>(cache, "ProcOfficer");
            ClearCache<UserApplication>(cache, "AuthOfficer");
            ClearCache<UserApplication>(cache, "FinanceInitiator");
            ClearCache<UserApplication>(cache, "WithPicture");
            ClearCache<UserApplication>(cache, "WithNoPicture");
            ClearCache<UserApplication>(cache, "FullList");
            ClearCache<ExpenseStaffStatus>(cache);
            ClearCache<ProcurementStatus>(cache);
            ClearCache<PendingTransferStatus>(cache);
            ClearCache<ExpensePlatoStatus>(cache);
            ClearCache<GroupActivity>(cache);
            ClearCache<Recurrence>(cache);
            ClearCache<CapacityLevel>(cache);
            ClearCache<SpdKeyOutput>(cache);
            ClearCache<SpdObjective>(cache);
            ClearCache<Priority>(cache);
            ClearCache<ProcurementFinancingDecision>(cache);
        }

        public static void ClearCache<T>(IMemoryCache cache)
        {
            ClearCache<T>(cache, "");
        }

        private static void ClearCache<T>(IMemoryCache cache, string name)
        {
            object cached;
            if (cache.TryGetValue(typeof(T).Name + name, out cached))
                cache.Remove(typeof(T).Name + name);
        }
    }
}
