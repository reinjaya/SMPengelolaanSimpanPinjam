using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Repositories.Data;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _repository;
        public IConfiguration _configuration;
        public AccountController(AccountRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginVM login)
        {
            try
            {
                var data = _repository.GetLoginData(login.UserName, login.Password);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Gagal login, password atau username tidak valid"
                    });
                }
                else
                {
                    //var claims = new[] {
                    //    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    //    new Claim("userId", data.Id.ToString()),
                    //    new Claim("fullName", data.FullName),
                    //    new Claim("role", data.RoleName),
                    //    new Claim("email", data.Email)
                    //};

                    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    //var token = new JwtSecurityToken(
                    //    _configuration["Jwt:Issuer"],
                    //    _configuration["Jwt:Audience"],
                    //    claims,
                    //    expires: DateTime.UtcNow.AddMinutes(10),
                    //    signingCredentials: signIn);

                    //string tokenCode = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil login",
                        //Token = tokenCode
                        Data = data
                    });

                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
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
