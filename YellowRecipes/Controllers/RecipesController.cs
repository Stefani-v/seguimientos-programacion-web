using YellowRecipes.Data;
using YellowRecipes.Models;
using Microsoft.AspNetCore.Mvc;

namespace YellowRecipes.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index(string? search, string? category)
        {
            var recipes = RecipeRepository.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                recipes = recipes
                    .Where(r => r.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                             || r.Ingredients.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                recipes = recipes
                    .Where(r => r.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(recipes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe model)
        {
            if (!ModelState.IsValid) return View(model);

            RecipeRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var recipe = RecipeRepository.GetById(id);
            if (recipe == null) return NotFound();

            return View(recipe);
        }
    }
}
