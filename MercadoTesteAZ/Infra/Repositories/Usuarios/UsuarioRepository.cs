using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Domain.Enums;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Infra.Repositories.Usuarios
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> ObterTodosCliente()
        {
            return await _context.Usuarios.Where(u => u.TipoUsuario == TipoUsuario.Cliente).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterTodosVendedores()
        {
            return await _context.Usuarios.Where(u => u.TipoUsuario == TipoUsuario.Vendedor).AsNoTracking().ToListAsync();
        }
    }
}
