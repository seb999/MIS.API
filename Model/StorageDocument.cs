using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class StorageDocument
    {
        public long StorageDocId { get; set; }
        public long? StorageDocTypeId { get; set; }
        public long? EntityId { get; set; }
        public bool? StorageDocIsDeleted { get; set; }
        public string StorageDocName { get; set; }
        public string StorageDocDescription { get; set; }
        public string StorageDocPath { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Expense Entity { get; set; }
        public StorageDocumentType StorageDocType { get; set; }
    }
}
