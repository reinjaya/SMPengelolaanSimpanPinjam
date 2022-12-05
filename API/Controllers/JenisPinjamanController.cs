using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Base;
using WebAPI.Models;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisPinjamanController : BaseController<JenisPinjamanRepository, JenisPinjaman>
    {
        private readonly JenisPinjamanRepository _repository;
        public JenisPinjamanController(JenisPinjamanRepository jenisPinjamantRepository) : base(jenisPinjamantRepository)
        {
            _repository = jenisPinjamantRepository;
        }
    }
}
