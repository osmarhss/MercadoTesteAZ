using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.AppServices.Empresas.Vendedores;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Enums;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Infra.Repositories.Pagamentos;
using MercadoTesteAZ.Presentation.ViewModels.ContasBancarias;

namespace MercadoTesteAZ.Application.AppServices.MeiosDePagamento
{
    public class ContaBancariaAppService : AppService<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria>, IContaBancariaAppService
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly ITransportadoraRepository _transportadoraRepository;
        public ContaBancariaAppService(IContaBancariaRepository contaBancariaRepository, IVendedorRepository vendedorRepository, ITransportadoraRepository transportadoraRepository,
            IUnityOfWork uow, IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria> mapping) : base(contaBancariaRepository, uow, mapping)
        {
            _contaBancariaRepository = contaBancariaRepository;
            _vendedorRepository = vendedorRepository;
            _transportadoraRepository = transportadoraRepository;
        }

        public override async Task<string> AdicionarAsync(ContaBancariaViewModel vm)
        {
            var idConta = await AdicionarSemCommitAsync(vm);

            await _uow.CommitAsync();
            return idConta;
        }
        public async Task<string> AdicionarSemCommitAsync(ContaBancariaViewModel vm)
        {
            var contaDraft = ToDraft(vm);

            IEntity? entidade = contaDraft.TipoEmpresa switch
            {
                TipoEmpresa.Vendedor => await _vendedorRepository.ObterPorIdAsync(contaDraft.ProprietarioId),
                TipoEmpresa.Transportadora => await _transportadoraRepository.ObterPorIdAsync(contaDraft.ProprietarioId),
                _ => throw new ExcecaoPersonalizada($"Tipo de empresa inválido: {contaDraft.TipoEmpresa}")
            };

            if (entidade is null)
                throw new ExcecaoPersonalizada($"Entidade não encontrada pelo idConta: {contaDraft.ProprietarioId}");

            var conta = CriarEntidade(contaDraft);
            var idConta = await _contaBancariaRepository.AdicionarAsync(conta);

            return idConta;
        }

        protected override void AtualizarEntidade(ContaBancariaDraft draft, ContaBancaria antiga)
        {
            antiga.Atualizar(draft.Cnpj, draft.InstituicaoBancaria, draft.TipoConta, draft.Agencia, draft.NumConta, draft.ContaPrincipal);
        }

        protected override ContaBancaria CriarEntidade(ContaBancariaDraft draft)
        {
            return ContaBancaria.Adicionar(draft.Cnpj, draft.InstituicaoBancaria, draft.TipoConta, draft.Agencia, draft.NumConta, draft.ContaPrincipal, draft.ProprietarioId, draft.TipoEmpresa);
        }

        protected override ContaBancariaDraft ToDraft(ContaBancariaViewModel vm)
        {
            return _mapping.ToDraft(vm);
        }
    }
}
