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

        public IActionResult TambahPinjaman()
        {
            return View();
        }

        public IActionResult BayarAngsuran()
        {
            return View();
        }

        public IActionResult DetailPinjaman()
        {
            return View();
        }
    }
}
