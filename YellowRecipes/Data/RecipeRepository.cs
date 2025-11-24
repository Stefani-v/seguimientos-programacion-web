using YellowRecipes.Models;
namespace YellowRecipes.Data
{
    public class RecipeRepository
    {
        private static List<Recipe> _recipes = new List<Recipe>()
        {
            new Recipe { Id = 1, Title = "Pancakes", Description="Revuelve todos los ingredientes y pasa a un sartén, dale la forma que quieras", Ingredients="Harina, Leche, Huevo", Category="Desayuno"},
            new Recipe { Id = 2, Title = "Ensalada César", Description="Ralla el queso, pollo al horno y luego revuelve todos los ingredientes", Ingredients="Lechuga, Pollo, Queso", Category="Almuerzo"},
            new Recipe { Id = 3, Title = "Tortilla Francesa", Description="Batir huevos, echar al sartén y le vas dando forma", Ingredients="2 huevos, atún, Queso,cebolla,aceite de oliva", Category="Cena"},
            new Recipe { Id = 4, Title = "Arroz con Huevo", Description="Cocer el arroz, hacer huevos revueltos y emplatar o mezclalos", Ingredients="2 huevos,Arroz blanco,aceite de oliva", Category="Cena"}

        };

        public static List<Recipe> GetAll() => _recipes;

        public static Recipe? GetById(int id) =>
            _recipes.FirstOrDefault(r => r.Id == id);

        public static void Add(Recipe r)
        {
            r.Id = _recipes.Max(x => x.Id) + 1;
            _recipes.Add(r);
        }
    }
}

