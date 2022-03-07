using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppReportStatus
    {
        public int Id { get; set; }
        public string? ForecastStatus { get; set; }
        public string? ForecastYearPeriod { get; set; }
        public string? ForecastYearLastPeriod { get; set; }
        public string? ReportedForecastYearPeriod { get; set; }
        public string? ReportedForecastPeriod { get; set; }
        public string? M1 { get; set; }
        public string? M2 { get; set; }
        public string? M3 { get; set; }
        public string? ForecastQuarter { get; set; }
        public string? LastQuarter { get; set; }
        public string? Nm1 { get; set; }
        public string? Nm2 { get; set; }
        public string? Nm3 { get; set; }
        public string? NextQuarter { get; set; }
        public string? PrelimForecastYearPeriod { get; set; }
        public string? Active { get; set; }
    }
}
