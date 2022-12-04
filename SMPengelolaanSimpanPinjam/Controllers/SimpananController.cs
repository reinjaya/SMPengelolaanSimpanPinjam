using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpananController : ControllerBase
    {
        private readonly SimpananRepository _repository;
        public SimpananController(SimpananRepository simpananRepository)
        {
            _repository = simpananRepository;
        }

        [HttpGet("DaftarSimpananAnggota")]
        public ActionResult DaftarSimpananAnggota(int idUser)
        {
            try
            {
                var data = _repository.DaftarSimpananAnggota(idUser);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data not found"
                    }); ;
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

        [HttpPost("TambahSimpananWajib")]
        public ActionResult TambahSimpananWajib(int idUser, string userEntry)
        {
            try
            {
                var data = _repository.TambahSimpananWajib(idUser, userEntry);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data failed to update"
                    }); ;
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Sukses menambahkan simpanan wajib"
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

        [HttpPost("TambahSimpananSukarela")]
        public ActionResult TambahSimpananSukarela(int idUser, int jumlahUang, string userEntry)
        {
            try
            {
                var data = _repository.TambahSimpananSukarela(idUser, jumlahUang, userEntry);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data failed to update"
                    }); ;
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Sukses menambahkan simpanan sukarela"
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
