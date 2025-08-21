using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Presentation.ViewModels.Transportadoras;

namespace MercadoTesteAZ.Application.AppServices.Empresas.Transportadoras
{
    public class TransportadoraAppService : AppService<TransportadoraAdminViewModel, TransportadoraDraft, Transportadora>, 
        ITransportadoraAppService<TransportadoraAdminViewModel, TransportadoraDraft, Transportadora>
    {
        private readonly ITransportadoraRepository _transportadoraRepository;
        public TransportadoraAppService(ITransportadoraRepository transportadoraRepository, IUnityOfWork uow, 
            IMapper<TransportadoraAdminViewModel, TransportadoraDraft, Transportadora> mapping) : base(transportadoraRepository, uow, mapping)
        {
            _transportadoraRepository = transportadoraRepository;
        }

        public async Task<TransportadoraAdminViewModel> ObterPorNomeAsync(string nome)
        {
            var transportadora = await _transportadoraRepository.ObterPorNomeAsync(nome);

            if (transportadora is null)
                throw new ExcecaoPersonalizada($"Transportadora não encontrada pelo nome: {nome}");

            return _mapping.ToViewModel(transportadora);
        }

        protected override void AtualizarEntidade(TransportadoraDraft draft, Transportadora antiga)
        {
            antiga.Atualizar(draft.Nome, draft.Ativo);
        }

        protected override Transportadora CriarEntidade(TransportadoraDraft draft)
        {
            var conta = ContaBancaria.Adicionar(draft.Cnpj, draft.ContaBancaria.InstituicaoBancaria, draft.ContaBancaria.TipoConta,
                draft.ContaBancaria.Agencia, draft.ContaBancaria.NumConta, draft.ContaBancaria.ContaPrincipal, draft.ContaBancaria.ProprietarioId, draft.ContaBancaria.TipoEmpresa);
            
            return Transportadora.Adicionar(draft.Nome, draft.Cnpj, draft.Ativo, conta);
        }

        protected override TransportadoraDraft ToDraft(TransportadoraAdminViewModel vm)
        {
            return _mapping.ToDraft(vm);
        }
    }
}
