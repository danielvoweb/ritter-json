using Microsoft.AspNetCore.Mvc;
using JsonInterrogator.Models;

namespace JsonInterrogator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var people = _repository.Get<Person>();
            var viewModel = new AppViewModel(people);
            return View(viewModel);
        }
    }
}
