using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinjamanController : ControllerBase
    {
        private readonly PinjamanRepository _repository;
        public IConfiguration _configuration;

        public PinjamanController(PinjamanRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet("DaftarPinjamanAnggota")]
        public ActionResult DaftarPinjamanAnggota(int idUser)
        {
            try
            {
                var data = _repository.DaftarPinjamanAnggota(idUser);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data not found"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data has been retrieved",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
