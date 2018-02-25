using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECDC.MIS.API.Model
{
    public partial class PendingTransferStatus : ILookupData
    {
        public PendingTransferStatus()
        {
            PendingExpenseTransfer = new HashSet<PendingExpenseTransfer>();
        }

        public long PetStatusId { get; set; }
        public string PetStatusName { get; set; }
        public string PetStatusDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }
        public bool? PetIsExecuted { get; set; }
        public bool? PetIsPending { get; set; }
        public bool? PetIsRejected { get; set; }

        public ICollection<PendingExpenseTransfer> PendingExpenseTransfer { get; set; }

        #region lookup

        [NotMapped]
        public long Value
        {
            get { return PetStatusId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return PetStatusName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
