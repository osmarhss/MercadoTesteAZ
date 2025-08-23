using MercadoTesteAZ.Application.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace MercadoTesteAZ.Application.AppServices.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> RealizarLogin(LoginDto dto);
        Task<string> RealizarCadastro(RegisterDto dto);
        Task<AuthResponseDto> RenovarSessao(TokenModelDto dto);
        Task RevogarRefreshToken(string username);
    }
}
