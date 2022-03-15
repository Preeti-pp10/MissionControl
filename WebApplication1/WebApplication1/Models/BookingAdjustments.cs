namespace WebApplication1.Models
{
    public class BookingAdjustments
    {
        public V5McAppOrderSplitBookingsAdjustmentsAudit booking { get; set; }

        public BookingAdjustments()
        {
            booking = new V5McAppOrderSplitBookingsAdjustmentsAudit();

        }
    }
}
