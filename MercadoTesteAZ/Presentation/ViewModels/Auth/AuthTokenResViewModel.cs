using System.IdentityModel.Tokens.Jwt;

namespace MercadoTesteAZ.Presentation.ViewModels.Auth
{
    public class AuthTokenResViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
