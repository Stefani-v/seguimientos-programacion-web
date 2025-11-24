namespace Reservations.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string? TimeSlot { get; set; }//TimeSlot es para asignar un string ya sea una hora
        //o cualquier otro dato. 
    }
}
