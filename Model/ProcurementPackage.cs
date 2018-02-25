using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementPackage
    {
        public long ProcPackageId { get; set; }
        public long? ProcId { get; set; }
        public long? UserIdProjectManager { get; set; }
        public string ProcPackageName { get; set; }
        public string ProcPackageDescription { get; set; }
        public int? ProcPackageNumber { get; set; }
        public string ProcPackageDeliverables { get; set; }
        public DateTime? ProcPackageImplementation { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public Procurement Proc { get; set; }
        public UserApplication UserIdProjectManagerNavigation { get; set; }
    }
}
