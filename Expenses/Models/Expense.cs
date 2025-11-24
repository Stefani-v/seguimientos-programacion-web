namespace Expenses.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; } //GASTO
        public string? Category { get; set; }
        public DateTime Date { get; set; }
    }
}
