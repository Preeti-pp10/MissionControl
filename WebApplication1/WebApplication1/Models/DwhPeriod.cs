using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class DwhPeriod
    {
        public string? Period { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public string PeriodKey { get; set; } = null!;
        public DateTime? PeriodStartDate { get; set; }
        public string? PeriodType { get; set; }
        public string? Quarter { get; set; }
        public int? Year { get; set; }
        public DateTime? YearStartDate { get; set; }
        public DateTime? QuarterStartDate { get; set; }
        public string? YearPeriod { get; set; }
        public string? PeriodName { get; set; }
        public string? YearQuarter { get; set; }
    }
}
