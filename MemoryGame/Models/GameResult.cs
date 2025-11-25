namespace MemoryGame.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = "";
        public int Moves { get; set; }
        public int Level { get; set; }
        public DateTime PlayedAt { get; set; } = DateTime.Now;
    }
}
