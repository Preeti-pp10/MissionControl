using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class V5McAppOrderSplitBookingsAdjustment
    {
        public int Id { get; set; }
        public string? Transcation { get; set; }
        public string? OrderNumber { get; set; }
        public string? District { get; set; }
        public string? FiscalPeriod { get; set; }
        public string? L3BusinessGroup { get; set; }
        public string? L4BusinessUnit { get; set; }
        public string? L5ProductLine { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TransDate { get; set; } 
        public double? Bookings { get; set; }
        public string? Comments { get; set; }
        public double? CcAmtGrossBookings { get; set; }
        public string? SplitPercent { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? EntryBy { get; set; }
        public string? SplitType { get; set; }
        public string? Region { get; set; }
        public string? SubRegion { get; set; }
    }
}
