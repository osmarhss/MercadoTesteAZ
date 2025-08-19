using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Task<IEnumerable<Usuario>> ObterTodosCliente();
        public Task<IEnumerable<Usuario>> ObterTodosVendedores();
    }
}
