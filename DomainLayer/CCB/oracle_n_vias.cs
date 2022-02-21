using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CCB
{
    public class oracle_n_vias
    {
        public string ORDER_NUMBER { get; set; }
        public string REGION { get; set; }
        public string SUB_REGION { get; set; }
        public string PO_NUMBER { get; set; }
        public string DISTRICT { get; set; }
        public string L3_BUSINESS_GROUP { get; set; }
        public string L4_BUSINESS_UNIT { get; set; }
        public string L5_PRODUCT_LINE { get; set; }
        public string TRANS_DATE_PERIOD_NAME { get; set; }
        public string CC_AMT_GROSS_BOOKINGS { get; set; }

        public DateTime TRANS_DATE { get; set; }
        public string Sales_Leader { get; set; }
        public string Sales_Team { get; set; }
    }
}
