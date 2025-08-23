using MercadoTesteAZ.Application.AppServices.Auth;
using MercadoTesteAZ.Presentation.ViewModels.Auth;
using MercadoTesteAZ.Presentation.ViewModels.VMExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenResViewModel>> Login([FromBody] LoginModel model)
        {
            if (model is null)
                return BadRequest("O modelo de login não pode ser nulo");

            var loginDto = model.ToDto();
            var authToken = await _authService.RealizarLogin(loginDto);
            
            if (authToken is null)
                return Unauthorized();

            return Ok(authToken);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] RegisterModel model) 
        {
            if (model is null)
                return BadRequest("O modelo de registro não pode ser nulo");

            var registerDto = model.ToDto();
            var res = await _authService.RealizarCadastro(registerDto);

            return Ok(res);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthTokenResViewModel>> RenovarToken([FromBody] TokenModel model) 
        {
            if (model is null)
                return BadRequest("Token inválido");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tokenModelDto = model.ToDto();
            var authToken = await _authService.RenovarSessao(tokenModelDto);

            if (authToken is null)
                return Unauthorized("Token inválido");

            return Ok(authToken);
        }

        [Authorize]
        [HttpPost("revoke")]
        public async Task<IActionResult> RevogarRefreshToken([FromBody] RevokeRefTokenModel model) 
        {
            if (model.Username is null)
                return BadRequest("Nome de usuário não pode ser nulo");

            await _authService.RevogarRefreshToken(model.Username);

            return NoContent();
        }

    }
}
