namespace Reservations.Models
{
    public class ReservationData
    {
        public static List<Service> Services = new List<Service>
        {
            new Service { Id = 1, Name = "Corte de Cabello", Icon = "✂️", Duration = 30, Price = 15000 },
            new Service { Id = 2, Name = "Masaje Relajante", Icon = "💆", Duration = 60, Price = 45000 },
            new Service { Id = 3, Name = "Manicure", Icon = "💅", Duration = 45, Price = 25000 },
            new Service { Id = 4, Name = "Consulta Médica", Icon = "🩺", Duration = 30, Price = 50000 }
        };

        public static List<Reservation> Reservations = new List<Reservation>();

        public static List<string> AvailableSlots = new List<string>
        {
            "09:00", "09:30", "10:00", "10:30", "11:00", "11:30",
            "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00"
        };
    }
}
