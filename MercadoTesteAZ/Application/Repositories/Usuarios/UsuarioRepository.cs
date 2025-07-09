using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Infra.Context;

namespace MercadoTesteAZ.Application.Repositories.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
