using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CCB
{
    public class CCB_Models
    {
        List<CCB_Model> CCbMOdelsList { get; set; }

    }
    public class CCB_Model
    {

        public int ID { get; set; }
        public string TRANSCATION { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string PO_NUMBER { get; set; }
        public string REGION { get; set; }
        public string SUB_REGION { get; set; }
        public string DISTRICT { get; set; }
        public string SPLIT_PERCENT { get; set; }

        public string FISCAL_PERIOD { get; set; }

        [DisplayFormat(DataFormatString  = " {0:##,#.##} ")]
        public Decimal BOOKINGS { get; set; }

        public int BOOKINGADJUSTMENTSID { get; set; }
        public int BOOKINGADJUSTMENTSID1{ get; set; }
        public int BOOKINGADJUSTMENTSID2{ get; set; }
        public int BOOKINGADJUSTMENTSID3{ get; set; }
        public int BOOKINGADJUSTMENTSID4{ get; set; }
        public int BOOKINGADJUSTMENTSID5{ get; set; }

        public string REGION1 { get; set; }
        public string REGION2 { get; set; }
        public string REGION3 { get; set; }
        public string REGION4 { get; set; }
        public string REGION5 { get; set; }
        public string SUB_REGION1 { get; set; }
        public string SUB_REGION2 { get; set; }
        public string SUB_REGION3 { get; set; }
        public string SUB_REGION4 { get; set; }
        public string SUB_REGION5 { get; set; }
        public string DISTRICT1 { get; set; }
        public string DISTRICT2 { get; set; }
        public string DISTRICT3 { get; set; }
        public string DISTRICT4 { get; set; }
        public string DISTRICT5 { get; set; }

        public string SPLIT_PERCENT1 { get; set; }
        public string SPLIT_PERCENT2 { get; set; }
        public string SPLIT_PERCENT3 { get; set; }
        public string SPLIT_PERCENT4 { get; set; }
        public string SPLIT_PERCENT5 { get; set; }

        public float SPLITVALUE1 { get; set; }
        public float SPLITVALUE2{ get; set; }
        public float SPLITVALUE3{ get; set; }
        public float SPLITVALUE4 { get; set; }
        public float SPLITVALUE5{ get; set; }

        public string LThree1 { get; set; }
        public string LThree2 { get; set; }
        public string LThree3 { get; set; }
        public string LThree4 { get; set; }
        public string LThree5 { get; set; }

        public string LFour1 { get; set; }
        public string LFour2 { get; set; }
        public string LFour3 { get; set; }
        public string LFour4 { get; set; }
        public string LFour5 { get; set; }

        public string LFive1 { get; set; }
        public string LFive2 { get; set; }
        public string LFive3 { get; set; }
        public string LFive4 { get; set; }
        public string LFive5 { get; set; }

        public string L3_BUSINESS_GROUP { get; set; }

        public string L4_BUSINESS_UNIT { get; set; }
        public string L5_PRODUCT_LINE { get; set; }
        public string COMMENTS { get; set; }
        public DateTime TRANS_DATE {  get; set; } 
        public decimal CC_AMT_GROSS_BOOKINGS { get; set; }
        public string ENTRY_BY { get; set; }
        public string  SPLIT_TYPE { get; set; }
        public DateTime ENTRY_DATE { get; set; }

    }
}
