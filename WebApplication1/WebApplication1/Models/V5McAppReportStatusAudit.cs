using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppReportStatusAudit
    {
        public int Id { get; set; }
        public string? ForecastQuarter { get; set; }
        public string? ForecastYearPeriod { get; set; }
        public string? ReportedForecastPeriod { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
