namespace Reservations.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ClientName { get; set; } = "";
        public string ClientEmail { get; set; } = "";
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; } = "";
        public bool Confirmed { get; set; }
    }
}
