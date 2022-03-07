using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CCB
{
    public class BookingSplitOrder
    {
        public CCB_Model ccb_model { get; set; }
        public BookingSplitOrder()
        {
            ccb_model = new CCB_Model();

        }
      


    }
}
