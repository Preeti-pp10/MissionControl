using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppOrderSplitBookingsAdjustmentsAudit
    {
        public int Id { get; set; }
        public string? Transaction { get; set; }
        public string? OrderNumber { get; set; }
        public string? CurrentDistrict { get; set; }
        public string? SplitPercent { get; set; }
        public double? Bookings { get; set; }
        public string? FiscalPeriod { get; set; }
        public string? CurrentCcbperiod { get; set; }
        public string? District1 { get; set; }
        public string? District2 { get; set; }
        public string? District3 { get; set; }
        public string? District4 { get; set; }
        public string? District5 { get; set; }
        public string? SplitPercent1 { get; set; }
        public string? SplitPercent2 { get; set; }
        public string? SplitPercent3 { get; set; }
        public string? SplitPercent4 { get; set; }
        public string? SplitPercent5 { get; set; }
        public string? SplitValue1 { get; set; }
        public string? SplitValue2 { get; set; }
        public string? SplitValue3 { get; set; }
        public string? SplitValue4 { get; set; }
        public string? SplitValue5 { get; set; }
        public string? L3 { get; set; }
        public string? L4 { get; set; }
        public string? L5 { get; set; }
        public string? Comments { get; set; }
        public DateTime? OriginalBookedDate { get; set; }
        public DateTime? TransDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? SplitType { get; set; }
    }
}
