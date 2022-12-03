using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Base;
using WebAPI.Models;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabunganController : BaseController<TabunganRepository, Tabungan>
    {
        private readonly TabunganRepository _repository;
        public TabunganController(TabunganRepository tabunganRepository) : base(tabunganRepository)
        {
            _repository = tabunganRepository;
        }
    }
}
