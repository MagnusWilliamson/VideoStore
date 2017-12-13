using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieMaster.Models;

namespace MovieMaster.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();     
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
