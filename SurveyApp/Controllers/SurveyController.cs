using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    public class SurveyController : Controller
    {

        public IActionResult Index()
        {
            return View(SurveyData.Surveys);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string question, string[] options)
        {
            SurveyData.Surveys.Add(new SurveyModel
            {
                Id = SurveyData.Surveys.Count + 1,
                Question = question,
                Options = options.ToList()
            });

            return RedirectToAction("Index");
        }

        public IActionResult Vote(int id)
        {
            Models.SurveyModel survey = SurveyData.Surveys.First(x => x.Id == id);
            return View(survey);
        }

        [HttpPost]
        public IActionResult Vote(int id, string option)
        {
            SurveyData.Responses.Add(new SurveyResponse
            {
                SurveyId = id,
                SelectedOption = option
            });

            return RedirectToAction("Results", new { id });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var survey = SurveyData.Surveys.FirstOrDefault(x => x.Id == id);

            if (survey != null)
            {
                // Eliminar la encuesta
                SurveyData.Surveys.Remove(survey);

                // Eliminar todas las respuestas asociadas
                SurveyData.Responses.RemoveAll(r => r.SurveyId == id);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Results(int id)
        {
            Models.SurveyModel survey = SurveyData.Surveys.First(x => x.Id == id);
            IEnumerable<SurveyResponse> responses = SurveyData.Responses.Where(r => r.SurveyId == id);

            ViewBag.Counts = survey.Options
                .ToDictionary(opt => opt, opt => responses.Count(r => r.SelectedOption == opt));

            return View(survey);
        }
    }
}
