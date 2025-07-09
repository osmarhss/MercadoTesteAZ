using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Domain.Entities.Usuário
{
    public class Usuario : IEntity
    {
        public string Id { get; private set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; private set; }

    }
}
