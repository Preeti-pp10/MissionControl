using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppUpdateReportPeriod
    {
        public int Id { get; set; }
        public string? TransDateYearQuarter { get; set; }
        public string? TransDatePeriodName { get; set; }
        public string? TransDateYearPeriod { get; set; }
        public string? Active { get; set; }
    }
}
