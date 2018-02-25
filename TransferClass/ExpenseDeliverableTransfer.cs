using System;

namespace ECDC.MIS.API.TransferClass
{
    public class ExpenseDeliverableTransfer
    {
        public DateTime? EndDate { get; set; }
        public bool? IsDone { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
    }
}
