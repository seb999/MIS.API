using System;
using System.Collections.Generic;

namespace ECDC.MIS.API.Model
{
    public partial class FunctionParticipant
    {
        public FunctionParticipant()
        {
            ExpenseFunctionParticipant = new HashSet<ExpenseFunctionParticipant>();
        }

        public long FunctionParticipantId { get; set; }
        public long? Awpid { get; set; }
        public string FunctionParticipantName { get; set; }
        public string FunctionParticipantDescription { get; set; }
        public DateTime? DateAdded { get; set; }
        public long? UserAdded { get; set; }
        public DateTime? DateMod { get; set; }
        public long? UserMod { get; set; }

        public AnnualWorkPlan Awp { get; set; }
        public ICollection<ExpenseFunctionParticipant> ExpenseFunctionParticipant { get; set; }
    }
}
