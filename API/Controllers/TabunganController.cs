using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Base;
using WebAPI.Models;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabunganController : ControllerBase
    {
        private readonly TabunganRepository _repository;
        public TabunganController(TabunganRepository tabunganRepository)
        {
            _repository = tabunganRepository;
        }

        [HttpGet("DaftarTabungan")]
        public ActionResult GetDaftarTabungan()
        {
            try
            {
                var data = _repository.GetDaftarTabungan();
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

        [HttpGet("TabunganById")]
        public ActionResult GetTabunganById(int tabunganId)
        {
            try
            {
                var data = _repository.GetById(tabunganId);
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

        [HttpGet("RiwayatPenarikan")]
        public ActionResult GetRiwayatPenarikan(int idTabungan)
        {
            try
            {
                var data = _repository.GetRiwayatPenarikan(idTabungan);
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

        [HttpGet("TotalTabungan")]
        public ActionResult TotalTabungan()
        {
            try
            {
                var data = _repository.TotalTabungan();
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

        [HttpPut("Penarikan")]
        public ActionResult DaftarPenarikanAnggota(int idUser, double jumlahPenarikan)
        {
            try
            {
                var data = _repository.PenarikanUang(idUser, jumlahPenarikan);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data failed to update"
                    }); ;
                }
                else if (data == 3)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Saldo tidak cukup untuk melakukan penarikan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Sukses melakukan penarikan"
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
