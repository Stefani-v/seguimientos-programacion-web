using Microsoft.AspNetCore.Mvc;
using MemoryGame.Models;
using MemoryGame.Data;
using System.Linq;

namespace MemoryGame.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int level = 1)
        {
            var model = new MemoryG
            {
                Level = level,
                CardPairs = level switch
                {
                    1 => 4,
                    2 => 6,
                    3 => 8,
                    _ => 4
                }
            };

            
            ViewBag.Scores = _context.GameResults
                .Where(x => x.Level == level)
                .OrderBy(x => x.Moves)
                .Take(10)
                .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveScore([FromBody] GameResult result)
        {
            result.PlayedAt = DateTime.Now;
            _context.GameResults.Add(result);
            _context.SaveChanges();

            return Ok();
        }
    }
}
