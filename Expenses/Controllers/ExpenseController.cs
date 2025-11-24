using Expenses.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Controllers
{
    public class ExpenseController : Controller
    {
        private static List<Expense> _expenses = new();
        private static int _idCounter = 1;

        public IActionResult Index()
        {
            ExpenseView vm = new ExpenseView
            {
                Expenses = _expenses.ToList(),
                TotalMonthly = _expenses
                    .Where(e => e.Date.Month == DateTime.Now.Month && e.Date.Year == DateTime.Now.Year)
                    .Sum(e => e.Amount)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ExpenseView vm)
        {
            vm.NewExpense.Id = _idCounter++;
            _expenses.Add(vm.NewExpense);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Expense? exp = _expenses.FirstOrDefault(e => e.Id == id);
            if (exp != null)
            {
                _expenses.Remove(exp);
            }

            return RedirectToAction("Index");
        }
    }
}

