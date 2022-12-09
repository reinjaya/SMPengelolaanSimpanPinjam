using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Login/")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Unauthorized/")]
        public IActionResult Unauthorized()
        {
            return View();
        }

        [HttpGet("Forbidden/")]
        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpGet("NotFound/")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}