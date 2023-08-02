
using InformAPI.Helpers;
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
        private  RegistrationContext _loginContext;
        private IConfiguration _config;
        public LoginController(RegistrationContext loginContext, IConfiguration configuration)
        {
            _loginContext = loginContext;
            _config = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetReg()
        {
            var reg = await _loginContext.Logins.ToListAsync();
            return Ok(reg);
        }

        private string GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               _config["Jwt:Issuer"],
               _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credential
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> PostReg(Login log)
        {
            log.Password = EncDscPassword.EncryptPassword(log.Password);
            _loginContext.Logins.Add(log);
            await _loginContext.SaveChangesAsync();
            var token = GenerateToken();
            return Ok(new {token=token,user=log.User});
        }







        
    }
}
