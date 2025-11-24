using Microsoft.AspNetCore.Mvc;
using PasswordG.Models;
using System.Security.Cryptography;
using System.Text;

namespace PasswordG.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            return View(new PasswordOptions());
        }

        [HttpPost]
        public IActionResult Generate(PasswordOptions options)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*()_-+=<>?/{}[]|";

            StringBuilder charPool = new StringBuilder();

            if (options.IncludeLowercase) charPool.Append(lowercase);
            if (options.IncludeUppercase) charPool.Append(uppercase);
            if (options.IncludeNumbers) charPool.Append(numbers);
            if (options.IncludeSymbols) charPool.Append(symbols);

            if (charPool.Length == 0)
            {
                options.GeneratedPassword = "Please select at least one character type.";
                return View("Index", options);
            }

            options.GeneratedPassword = GeneratePassword(options.Length, charPool.ToString());

            return View("Index", options);
        }

        private string GeneratePassword(int length, string charPool)
        {
            StringBuilder password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[4];

                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(buffer);
                    int randomIndex = BitConverter.ToInt32(buffer, 0);
                    randomIndex = Math.Abs(randomIndex % charPool.Length);

                    password.Append(charPool[randomIndex]);
                }
            }

            return password.ToString();
        }
    }
}
