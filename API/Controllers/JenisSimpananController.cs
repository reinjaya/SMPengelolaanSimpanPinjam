using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Base;
using WebAPI.Models;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisSimpananController : BaseController<JenisSimpananRepository, JenisSimpanan>
    {
        private readonly JenisSimpananRepository _repository;
        public JenisSimpananController(JenisSimpananRepository jenisSimpananRepository) : base(jenisSimpananRepository)
        {
            _repository = jenisSimpananRepository;
        }
    }
}
