using Microsoft.AspNetCore.Mvc;
using Tekus.Providers.Application.Contracts.Identity;
using Tekus.Providers.Application.Models.Identity;

namespace Tekus.Providers.Api.Controllers
{
    public class AccountController :  ApiControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }
    }
}
