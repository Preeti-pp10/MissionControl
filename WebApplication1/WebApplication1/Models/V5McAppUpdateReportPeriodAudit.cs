using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppUpdateReportPeriodAudit
    {
        public int Id { get; set; }
        public string? TransDateYearQuarter { get; set; }
        public string? TransDatePeriodName { get; set; }
        public string? TransDateYearPeriod { get; set; }
        public string? CreatedBy { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
