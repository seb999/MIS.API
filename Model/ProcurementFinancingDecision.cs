using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementFinancingDecision : ILookupData
    {
        public ProcurementFinancingDecision()
        {
            Procurement2 = new HashSet<Procurement2>();
        }

        public long ProcFinancingDecisionId { get; set; }
        public long? AwpId { get; set; }
        public string ProcFinancingDecisionName { get; set; }
        public string ProcFinancingDecisionStrategy { get; set; }
        public string ProcFinancingDecisionFunctionalGroup { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public ICollection<Procurement2> Procurement2 { get; set; }
        #region Lookup

        [NotMapped]
        public long Value
        {
            get { return ProcFinancingDecisionId; }
            set { Value = value; }
        }

        [NotMapped]
        public string Text
        {
            get { return ProcFinancingDecisionName; }
            set { Text = value; }
        }

        [NotMapped]
        public bool IsInactive { get; set; }

        #endregion
    }
}
