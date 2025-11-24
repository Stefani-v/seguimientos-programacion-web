namespace Reservations.Models
{//esta clase es para manejar horarios y reservas
    public class ReservationView
    {
        public Reservation NewReservation { get; set; } = new Reservation();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<string> TimeSlots { get; set; } = new List<string>();
    }
}
