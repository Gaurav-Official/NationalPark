namespace NationlParkAPI_2.Models
{
    public class Booking
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBooking { get; set; }
        public int NumberOfPersons { get; set; }
        public decimal Price { get; set; }
        public string BookingStatus { get; set; } = "Pending";
    }
}
