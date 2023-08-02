using InformAPI.Helpers;
using InformAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("default")]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationContext _registrationContext;
        public RegistrationController(RegistrationContext registrationContext)
        {
            _registrationContext = registrationContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetReg()
        {   
            var reg = await _registrationContext.Registrations.Select(r => new Registration
            {
                User=r.User,
                Password = EncDscPassword.DecryptPassword(r.Password)
        }).ToListAsync(); 

            return Ok(reg);
        }

        [HttpPost]
        public async Task<IActionResult> PostReg(Registration reg)
        {
            reg.Password = EncDscPassword.EncryptPassword(reg.Password);
           
            _registrationContext.Registrations.Add(reg);
            await _registrationContext.SaveChangesAsync();
            return Ok();
        }
    }
}

