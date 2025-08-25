using MercadoTesteAZ.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MercadoTesteAZ.Domain.Entities.Usuários
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
