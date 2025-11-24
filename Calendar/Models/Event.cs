using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [DataType(DataType.DateTime)]//ayuda a mostrar controles de fecha/hora en vistas
        public DateTime End { get; set; }

        public string? Description { get; set; }
    }
}

