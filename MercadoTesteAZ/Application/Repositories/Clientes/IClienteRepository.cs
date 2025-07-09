using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Clientes;

namespace MercadoTesteAZ.Application.Repositories.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public Task<Cliente?> ObterPorCpfAsync(string cpf);
    }
}
