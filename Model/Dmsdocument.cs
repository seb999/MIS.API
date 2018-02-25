using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class Dmsdocument
    {
        public long DmsDocId { get; set; }
        public long? ActivityId { get; set; }
        public string DmsDocCode { get; set; }
        public string DmsDocName { get; set; }
        public string DmsDocDescription { get; set; }
        public string DmsDocUrl { get; set; }
        public bool? DmsDocIsDeleted { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public long? ExpenseId { get; set; }

        public Activity Activity { get; set; }
        public Expense Expense { get; set; }
    }
}
