using ECDC.MIS.API.Model;

namespace ECDC.MIS.API.TransferClass
{
    public class SearchTransfer
    {
        public long ActivityId { get; set; }

        public string ActivityIdString { get; set; }

        public string ActivityCode { get; set; }

        public string ActivityName { get; set; }

        public string ActivityDescription { get; set; }

        public string Year { get; set; }

        public long ExpenseId { get; set; }
  
        public string ExpenseIdString { get; set; }

        public string ExpenseName { get; set; }
 
        public ExpenseType ExpenseType { get; set; }

    }
}
