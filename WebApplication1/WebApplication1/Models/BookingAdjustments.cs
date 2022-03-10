namespace WebApplication2.Models
{
    public class BookingAdjustments
    {
        public BookingOrder booking { get; set; }

        public BookingAdjustments()
        {
            booking = new BookingOrder();

        }
    }
}
