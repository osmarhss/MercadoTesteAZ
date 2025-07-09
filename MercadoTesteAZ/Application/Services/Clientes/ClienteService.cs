using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Application.Repositories.Clientes;
using MercadoTesteAZ.Application.Services;
using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Domain.Exceptions;

namespace MercadoTesteAZ.Application.Services.Clientes
{
    public class ClienteService : CrudService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(UnityOfWork uow, IClienteRepository clienteRepository) : base(uow, clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task ObterPorCpfAsync(string cpf)
        {
            var cliente = await _clienteRepository.ObterPorCpfAsync(cpf);

            if (cliente is null)
                throw new ExcecaoPersonalizada("Cliente não encontrado pelo CPF.");
        }

        public override async Task AdicionarAsync(Cliente entity)
        {
            await VerificarCpfExistenteAsync(entity.Cpf);
            await base.AdicionarAsync(entity);
        }
        public async Task VerificarCpfExistenteAsync(string cpf)
        {
            var cliente = await _clienteRepository.ObterPorCpfAsync(cpf);
            
            if (cliente != null)
                throw new InvalidOperationException("CPF já cadastro no sistema");
        }
    }
}
