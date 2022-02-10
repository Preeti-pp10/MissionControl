using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ReportPeroid
    {
        public int Id { get; set; }
        public string report_period { get; set; }
        public string report_year_quarter { get; set; }
        public string report_year_period { get; set; }
        public string Active { get; set; }
    }
}
