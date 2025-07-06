using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Enums;

namespace MercadoTesteAZ.Models.Usuários
{
    public class Usuario : IEntity
    {
        public string Id { get; private set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; private set; }

    }
}
