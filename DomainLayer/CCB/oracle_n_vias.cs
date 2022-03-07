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

        public class orcal_n_vias_model
        {
            List<oracle_n_vias> oracles { get; set; }

        }
        public string ORDER_NUMBER { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string PO_NUMBER { get; set; }
        public string District { get; set; }
        public string L3_BUSINESS_GROUP { get; set; }
        public string L4_BUSINESS_UNIT { get; set; }
        public string L5_PRODUCT_LINE { get; set; }
        public string TRANS_DATE_PERIOD_NAME { get; set; }
        public decimal CC_AMT_GROSS_BOOKINGS { get; set; }
        public DateTime TRANS_DATE { get; set; }
        public string SPLIT_PERCENT { get; set; }
        public decimal BOOKINGS { get; set; }
        public string FISCAL_PERIOD { get; set; }
        public string COMMENTS { get; set; }
        public string TRANSCATION { get; set; }
        public string ENTRY_BY { get; set; }
        public DateTime ENTRY_DATE { get; set; }
        public string SPLIT_TYPE { get; set; }



    }
}
