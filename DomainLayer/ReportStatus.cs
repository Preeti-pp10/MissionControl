using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ReportStatus
    {
        public int ID { get; set; }
        public string Forecast_Year_Period { get; set; }
        public string Reported_Forecast_Period { get; set; }
        public string Forecast_Quarter { get; set; }
        public string Prelim_Forecast_Year_Period { get; set; }
        public string Active { get; set; }
    }
}
