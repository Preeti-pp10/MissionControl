using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BookingOrder
    {
        public int? Id { get; set; }
        public string? Transcation { get; set; }
        public string? OrderNumber { get; set; }
        public string? District { get; set; }
        public string? FiscalPeriod { get; set; }
        public string? L3BusinessGroup { get; set; }
        public string? L4BusinessUnit { get; set; }
        public string? L5ProductLine { get; set; }
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


        public string? Region1 { get; set; }
        public string? Region2 { get; set; }
        public string? Region3 { get; set; }
        public string? Region4 { get; set; }
        public string? Region5 { get; set; }


        public string? SubRegion1 { get; set; }
        public string? SubRegion2 { get; set; }
        public string? SubRegion3 { get; set; }
        public string? SubRegion4 { get; set; }
        public string? SubRegion5 { get; set; }


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

        public float? Bookings1 { get; set; }
        public float? Bookings2 { get; set; }
        public float? Bookings3 { get; set; }
        public float? Bookings4 { get; set; }
        public float? Bookings5 { get; set; }

        public string? L5ProductLine1 { get; set; }
        public string? L5ProductLine2 { get; set; }
        public string? L5ProductLine3 { get; set; }
        public string? L5ProductLine4 { get; set; }
        public string? L5ProductLine5 { get; set; }


    }
}
