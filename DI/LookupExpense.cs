using ECDC.MIS.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECDC.MIS.API.DI
{
    /// <summary>
    /// Internal class
    /// </summary>
    public class LookupExpenseItem
    {
        public long? ExpenseId { get; set; }
        public long? ActivityId { get; set; }
        public long? AwpId { get; set; }
        public long? UnitId { get; set; }
        public long? DPId { get; set; }
        public long? SectionId { get; set; }
        public string DPCode { get; internal set; }
        public string SectionCode { get; internal set; }
        public string UnitCode { get; internal set; }
        public decimal? Amount { get; internal set; }
    }

    public interface ILookupExpense
    {
        List<LookupExpenseItem> ExpenseLookupList { get; set; }
    }
    public class LookupExpense : ILookupExpense
    {
        private IMemoryCache memoryCache;
        public List<LookupExpenseItem> ExpenseLookupList { get; set; }

        public LookupExpense(MISContext misContext, IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            List<LookupExpenseItem> cached;

            if (!memoryCache.TryGetValue(typeof(LookupExpenseItem).Name, out cached))
            {
                cached = (from expense in misContext.Expense
                            .Include(p => p.Activity)
                                     select new LookupExpenseItem
                                     {
                                         ExpenseId = expense.ExpenseId,
                                         ActivityId = expense.ActivityId,
                                         AwpId = expense.Activity.AWPId,
                                         DPId = expense.Activity.DSPId,
                                         DPCode = expense.Activity.Dsp.DspCode,
                                         SectionId = expense.Activity.SectionId,
                                         SectionCode = expense.Activity.Section.SectionCode,
                                         UnitId = expense.Activity.UnitId,
                                         UnitCode = expense.Activity.Unit.UnitCode,
                                         Amount = expense.ExpenseAmount,
                                     }).ToList();

                // Store it in cache
                memoryCache.Set(typeof(LookupExpenseItem).Name, cached);
            }

            ExpenseLookupList = cached;
        }
    }
}
