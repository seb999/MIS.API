using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class ProcurementStatusWorkflow
    {
        public long ProcStatusWorkflowId { get; set; }
        public long? ProcStatusId { get; set; }
        public bool? ProcStatusWorkflowIsInactive { get; set; }
        public long? ProcTypeId { get; set; }

        public ProcurementType ProcurementType { get; set; }

        public ProcurementStatus ProcStatus { get; set; }
    }
}
