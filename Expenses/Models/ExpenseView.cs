namespace Expenses.Models
{//esto es para enviar a la vista el resumen mensual!
    public class ExpenseView
    {
        public Expense NewExpense { get; set; } = new Expense();
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        public decimal TotalMonthly { get; set; }
    }
}
