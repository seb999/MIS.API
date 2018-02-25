using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementStage
    {
        [Key]
        public long ProcStageId { get; set; }
        public long? ExpenseId { get; set; }
        public long? ProcStatusId { get; set; }
        public bool? ProcStageCompleted { get; set; }
        public DateTime? ProcStageCompletedDate { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Expense Expense { get; set; }
        public ProcurementStatus ProcStatus { get; set; }
    }
}
