using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class MCCustomerModel
    {
        public int Id { get; set; }
        public string customer { get; set; }
        public string aggregated_customer { get; set; }
        [DataType(DataType.Date)]
        public DateTime? entry_date { get; set; }
        public DateTime created_on { get; set; }
        public string created_by { get; set; }
    }
    
}
