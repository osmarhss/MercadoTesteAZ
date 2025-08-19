using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public Task<Cliente?> ObterPorCpfAsync(string cpf);
    }
}
