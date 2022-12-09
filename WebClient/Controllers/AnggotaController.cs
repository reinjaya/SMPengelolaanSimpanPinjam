using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnggotaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pengajuan()
        {
            return View();
        }

        public IActionResult TambahPengajuan()
        {
            return View();
        }
    }
}
