using Microsoft.AspNetCore.Mvc;
using NotesManager.Models;
using NotesManager.Data;

namespace NotesManager.Controllers
{
    public class NotesController : Controller
    {
        public IActionResult Index(string search)
        {
            List<Note> notes = string.IsNullOrEmpty(search)
                ? NoteRepository.GetAll()
                : NoteRepository.Search(search);

            ViewBag.Search = search;
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                NoteRepository.Add(note);
                return RedirectToAction("Index");
            }

            return View(note);
        }

        public IActionResult Delete(int id)
        {
            NoteRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
