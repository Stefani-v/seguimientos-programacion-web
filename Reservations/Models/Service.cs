namespace Reservations.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Icon { get; set; } = "";
        public int Duration { get; set; } // minutos
        public decimal Price { get; set; }
    }
}
