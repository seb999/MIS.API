using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ExpenseStaffHistory
    {
        public long ExpenseStaffHistoryId { get; set; }
        public long? UserId { get; set; }
        public long? ExpenseStaffId { get; set; }
        public string ExpenseStaffHistoryElement { get; set; }
        public string ExpenseStaffHistoryNewValue { get; set; }
        public string ExpenseStaffHistoryPreviousValue { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ExpenseStaff ExpenseStaff { get; set; }
        public UserApplication User { get; set; }
    }
}
