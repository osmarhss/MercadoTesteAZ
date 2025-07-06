using MercadoTesteAZ.Models.Clientes;

namespace MercadoTesteAZ.Services.Clientes
{
    public interface IClienteService : ICrudService<Cliente>
    {
        public Task VerificarCpfExistenteAsync(string cpf);
        public Task ObterPorCpfAsync(string cpf);
    }
}
