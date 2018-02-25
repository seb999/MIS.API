using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class PendingTransferApprovalStatus
    {
        public PendingTransferApprovalStatus()
        {
            PendingExpenseTransfer = new HashSet<PendingExpenseTransfer>();
        }

        public long PetApprovalStatusId { get; set; }
        public string PetApprovalStatusName { get; set; }
        public string PetApprovalStatusDescription { get; set; }
        public bool? PetApprovalStatusIsReviewed { get; set; }
        public bool? PetApprovalStatusIsRejected { get; set; }
        public bool? PetApprovalStatusIsExcapproved { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<PendingExpenseTransfer> PendingExpenseTransfer { get; set; }
    }
}
