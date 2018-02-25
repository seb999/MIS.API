using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class StorageDocumentType
    {
        public StorageDocumentType()
        {
            StorageDocument = new HashSet<StorageDocument>();
        }

        public long StorageDocTypeId { get; set; }
        public string StorageDocTypeName { get; set; }
        public string StorageDocTypeDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public ICollection<StorageDocument> StorageDocument { get; set; }
    }
}
