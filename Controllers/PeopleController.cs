using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}