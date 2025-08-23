using System.IdentityModel.Tokens.Jwt;

namespace MercadoTesteAZ.Application.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
