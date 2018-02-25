using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class AllegroImport
    {
        public long AllegroImportId { get; set; }
        public long? UserId { get; set; }
        public long? Awpid { get; set; }
        public long? ExpenseId { get; set; }
        public int? AllegroImportMonth { get; set; }
        public decimal? AllegroImportTime { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public Expense Expense { get; set; }
        public UserApplication User { get; set; }
    }
}
