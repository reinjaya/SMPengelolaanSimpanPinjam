using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class TabunganController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Penarikan()
		{
			return View();
		}
	}
}
