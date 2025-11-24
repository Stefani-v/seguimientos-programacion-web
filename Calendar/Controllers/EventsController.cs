using Calendar.Data;
using Calendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Json(events);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event model)
        {
            _context.Events.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent([FromBody] Event model)
        {
            _context.Events.Update(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
