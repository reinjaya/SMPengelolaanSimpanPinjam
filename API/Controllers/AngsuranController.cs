using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AngsuranController : ControllerBase
    {
        private readonly AngsuranRepository _repository;
        public AngsuranController(AngsuranRepository simpananRepository)
        {
            _repository = simpananRepository;
        }

        [HttpPost("TambahAngsuranPinjaman")]
        public ActionResult TambahAngsuranPinjaman(int idPinjaman, string userEntry)
        {
            try
            {
                var data = _repository.TambahAngsuranPinjaman(idPinjaman, userEntry);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data failed to update",
                        Response = 1
                    }); ;
                }
                else if (data == 2)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Pinjaman sudah lunas",
                        Response = 2
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Sukses menambahkan angsuran",
                        Response = 2
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

        [HttpGet("GetDataAngsuranPinjaman")]
        public ActionResult GetDataAngsuranPinjaman(int idPinjaman)
        {
            try
            {
                var data = _repository.GetDataAngsuranPinjaman(idPinjaman);
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


        [HttpGet("RiwayatAngsuran")]
        public ActionResult RiwayatAngsuran(int idPinjaman)
        {
            try
            {
                var data = _repository.RiwayatAngsuran(idPinjaman);
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
    }
}
