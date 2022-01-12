using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string ORDER_NUMBER { get; set; }
		public string PO_NUMBER { get; set; }
        public string TRANS_DATE_YEAR_QUARTER { get; set; }
        public string TRANS_DATE_PERIOD_NAME { get; set; }    
        public string DISTRICT { get; set; }
        public string SUB_REGION { get; set; }
        public string REGION { get; set; }
      
    }
}
