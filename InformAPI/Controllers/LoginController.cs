using InformAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InformAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("default")]
    public class LoginController : ControllerBase
    {
        RegistrationContext _loginContext;
        public LoginController(RegistrationContext loginContext)
        {
            _loginContext = loginContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetReg()
        {
            var reg = await _loginContext.Logins.ToListAsync();
            return Ok(reg);
        }

        [HttpPost]
        public async Task<IActionResult> PostReg(Login log)
        {
            var issuer = _loginContext["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var signingCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha512Signature
                                );


            _loginContext.Logins.Add(log);
            await _loginContext.SaveChangesAsync();
            return Ok();
        }





        
    }
}
