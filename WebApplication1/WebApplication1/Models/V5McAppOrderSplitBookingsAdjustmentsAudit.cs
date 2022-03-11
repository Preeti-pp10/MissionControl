using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class V5McAppOrderSplitBookingsAdjustmentsAudit
    {
        public int Id { get; set; }
        public string? Transaction { get; set; }
        public string? OrderNumber { get; set; }
        public string? District { get; set; }
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
        public double? Bookings1 { get; set; }
        public double? Bookings2 { get; set; }
        public double? Bookings3 { get; set; }
        public double? Bookings4 { get; set; }
        public double? Bookings5 { get; set; }
        public string? L3BusinessGroup { get; set; }
        public string? L4BusinessUnit { get; set; }
        public string? L5ProductLine { get; set; }
        public string? Comments { get; set; }
        public DateTime? OriginalBookedDate { get; set; }
        public DateTime? TransDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? EntryBy { get; set; }
        public string? SplitType { get; set; }
    }
}
