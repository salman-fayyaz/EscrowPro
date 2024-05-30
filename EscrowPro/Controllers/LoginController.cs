using EscrowPro.Core.Dtos;
using EscrowPro.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscrowPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost()]
        public async Task<IActionResult> CheckLoginStatusAsync(CreateLoginDto createLoginDto)
        {
            if (createLoginDto == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
               var (status,userStatus,id)= await _loginService.CheckLoginStatusAsync(createLoginDto);
                string response = $"{status},{userStatus},{id}";
                return Ok(response);
            }
        }

    }
}
