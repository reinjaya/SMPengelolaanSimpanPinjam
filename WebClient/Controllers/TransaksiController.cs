using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TransaksiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Simpanan()
        {
            return View();
        }

        public IActionResult Pinjaman()
        {
            return View();
        }

        public IActionResult TambahSimpanan()
        {
            return View();
        }

        public IActionResult Angsuran()
        {
            return View();
        }
    }
}
