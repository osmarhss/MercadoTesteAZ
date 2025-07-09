using MercadoTesteAZ.Application.Services;
using MercadoTesteAZ.Domain.Entities.Clientes;

namespace MercadoTesteAZ.Application.Services.Clientes
{
    public interface IClienteService : ICrudService<Cliente>
    {
        public Task VerificarCpfExistenteAsync(string cpf);
        public Task ObterPorCpfAsync(string cpf);
    }
}
