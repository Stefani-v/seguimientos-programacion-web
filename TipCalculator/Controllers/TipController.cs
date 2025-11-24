using Microsoft.AspNetCore.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class TipController:Controller
    {
        public IActionResult Index()
        {
            return View(new TipModel());
        }

        [HttpPost]
        public IActionResult Calculate(TipModel model)
        {
            model.TipAmount = (model.BillAmount * model.TipPercentage) / 100;
            model.TotalToPay = model.BillAmount + model.TipAmount;

            return View("Index", model);
        }
    }

}

