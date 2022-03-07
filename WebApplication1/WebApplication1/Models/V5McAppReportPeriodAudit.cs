using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppReportPeriodAudit
    {
        public string ReportYearQuarter { get; set; } = null!;
        public string ReportPeriod { get; set; } = null!;
        public string? ReportYearPeriod { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
