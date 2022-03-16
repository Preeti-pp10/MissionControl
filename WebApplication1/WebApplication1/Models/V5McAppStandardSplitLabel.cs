using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppStandardSplitLabel
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? District1 { get; set; }
        public int? SplitPer1 { get; set; }
        public string? District2 { get; set; }
        public int? SplitPer2 { get; set; }
        public string? District3 { get; set; }
        public int? SplitPer3 { get; set; }
    }
}
