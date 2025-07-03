using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Usuários;

namespace MercadoTesteAZ.Repositorys.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
