using MercadoTesteAZ.Enums;

namespace MercadoTesteAZ.Models.Usuários
{
    public class Usuario
    {
        public Usuario(string id, string email, int tipoUsuario)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            Email = email;
            TipoUsuario = (TipoUsuario)tipoUsuario;
        }
        public string Id { get; private set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; private set; }

    }
}
