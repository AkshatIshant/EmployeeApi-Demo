using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Step one Of DI
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
            public AccountController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
                this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)//Model binding
        {
            var token = jwtAuthenticationManager.Authenticate(user.Username, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
