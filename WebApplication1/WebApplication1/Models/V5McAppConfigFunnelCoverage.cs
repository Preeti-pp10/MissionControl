using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppConfigFunnelCoverage
    {
        public int Id { get; set; }
        public string? CurrentQuarter { get; set; }
        public string? StartQuarter { get; set; }
        public string? EndQuarter { get; set; }
        public string? ForecastMonth { get; set; }
        public string? NumQtrs { get; set; }
        public string? FcstYqM { get; set; }
    }
}
