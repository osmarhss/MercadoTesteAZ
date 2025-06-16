using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Usuários;

namespace MercadoTesteAZ.Repositorys.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
