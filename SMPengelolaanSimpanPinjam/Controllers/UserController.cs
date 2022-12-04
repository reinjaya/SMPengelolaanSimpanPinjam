using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Base;
using WebAPI.Models;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;
        public IConfiguration _configuration;

        public UserController(UserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            try
            {
                var data = _repository.Create(user);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data failed to save"
                    });
                }
                else
                {
                    var result = _repository.AddSaldo(user.IdUser, user.UserEntry, user.TglEntry, user.TglEntry);
                    if (result == 0)
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Data failed to save"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Data saved successfully"
                        });
                    }
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


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _repository.GetAll();
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

        [HttpGet("GetAnggota")]
        public ActionResult GetAnggota()
        {
            try
            {
                var data = _repository.GetAnggota();
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

        [HttpGet("GetAnggotaAktif")]
        public ActionResult GetAnggotaAktif()
        {
            try
            {
                var data = _repository.GetAnggotaAktif();
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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data not found",
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

        [HttpPut("Keluarkan")]
        public ActionResult GantiStatus(int id, bool keluarkan)
        {
            try
            {
                var data = _repository.GantiStatusAnggota(id, keluarkan);
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
                        Message = "Data updated successfully"
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

        [HttpPut]
        public ActionResult Update(User user)
        {
            try
            {
                var data = _repository.Update(user);
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
                        Message = "Data updated successfully"
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

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _repository.Delete(id);
                if (data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data failed to delete"
                    }); ;
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data deleted successfully"
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
