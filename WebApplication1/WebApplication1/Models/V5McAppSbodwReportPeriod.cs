using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppSbodwReportPeriod
    {
        public int ReportYear { get; set; }
        public string ReportYearQuarter { get; set; } = null!;
        public string ReportPeriod { get; set; } = null!;
        public string? ReportYearPeriod { get; set; }
        public string? LastReportPeriod { get; set; }
        public string? LastReportYearQuarter { get; set; }
        public int? LastReportYear { get; set; }
        public string? LastReportYearPeriod { get; set; }
        public string? LastYearReportYearQuarter { get; set; }
        public string? NextReportYearQuarter { get; set; }
        public string? NextReportPeriod { get; set; }
        public string? LastYearLastReportQuarter { get; set; }
        public string? NextYearReportYearQuarter { get; set; }
        public string? LastYearReportYearPeriod { get; set; }
        public string? LastQuarterReportYearPeriod { get; set; }
        public string? Active { get; set; }
    }
}
