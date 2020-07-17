using Microsoft.AspNetCore.Mvc;
using JsonInterrogator.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonInterrogator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private IEnumerable<Person> People;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            string filePath = Path.Combine(_environment.WebRootPath, "data.json");
            using (StreamReader file = System.IO.File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                People = (IEnumerable<Person>)serializer.Deserialize(file, typeof(IEnumerable<Person>));
            }
            var viewModel = new AppViewModel(People);
            return View(viewModel);
        }
    }
}
