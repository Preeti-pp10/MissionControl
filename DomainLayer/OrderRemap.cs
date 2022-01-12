using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class OrderRemap
    {
        public int ID { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string PO_NUMBER { get; set; }
        public string Period { get; set; }
        public string Start_Quarter { get; set; }
        public string DISTRICT { get; set; }
        public string SUB_REGION { get; set; }
        public string REGION { get; set; }
        public string New_Region { get; set; }
        public string New_Subregion { get; set; }
        public string New_District { get; set; }
        public string Method { get; set; }
        public string Standard_Reason { get; set; }
        public string Comments { get; set; }
        public bool Is_Anaplan_TQM { get; set; }
        public bool Is_Approved_Move_To_New_Region { get; set; }
    }
}
