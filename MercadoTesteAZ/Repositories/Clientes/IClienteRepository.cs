using MercadoTesteAZ.Models.Clientes;

namespace MercadoTesteAZ.Repositorys.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public Task<Cliente?> ObterPorCpfAsync(string cpf);
    }
}
