using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Presentation.ViewModels.Vendedores;

namespace MercadoTesteAZ.Application.AppServices.Empresas.Vendedores
{
    public class VendedorAppService : AppService<VendedorViewModel, VendedorDraft, Vendedor>, IVendedorAppService
    {
        private readonly IVendedorRepository _vendedorRepository;
        public VendedorAppService(IVendedorRepository vendedorRepository, IUnityOfWork uow, IMapper<VendedorViewModel, VendedorDraft, Vendedor> mapping) 
            : base(vendedorRepository, uow, mapping)
        {
            _vendedorRepository = vendedorRepository;
        }

        public override async Task<string> AdicionarAsync(VendedorViewModel vm)
        {
            var draft = ToDraft(vm);
            var entidade = CriarEntidade(draft);

            await base.VerificarEntidadeExistentePorId(entidade.Id);
            await VerificarVendedorExistentePorCnpj(entidade.CNPJ);

            await _vendedorRepository.AdicionarAsync(entidade);

            return entidade.Id;
        }

        public async Task<VendedorViewModel> ObterPorCnpjAsync(string cnpj)
        {
            var entidade = await _vendedorRepository.ObterPorCnpjAsync(cnpj);
            if (entidade is null)
                throw new ExcecaoPersonalizada($"Vendedor não encontrado pelo CNPJ: {cnpj}");

            return _mapping.ToViewModel(entidade);
        }

        public async Task<VendedorViewModel> ObterPorRazaoSocialAsync(string razaoSocial)
        {
            var entidade = await _vendedorRepository.ObterPorCnpjAsync(razaoSocial);
            if (entidade is null)
                throw new ExcecaoPersonalizada($"Vendedor não encontrado pela razão social: {razaoSocial}");

            return _mapping.ToViewModel(entidade);
        }

        private async Task VerificarVendedorExistentePorCnpj(string cnpj) 
        {
            var entidadeExistente = await _vendedorRepository.ObterPorCnpjAsync(cnpj);
            
            if (entidadeExistente != null)
                throw new ExcecaoPersonalizada("Já existe um Vendedor com esse CNPJ.");
        }

        protected override void AtualizarEntidade(VendedorDraft draft, Vendedor antiga)
        {
            antiga.Atualizar(draft.RazaoSocial, draft.NomeFantasia);
        }

        protected override Vendedor CriarEntidade(VendedorDraft draft)
        {
            return Vendedor.Adicionar(draft.RazaoSocial, draft.NomeFantasia, draft.CNPJ, draft.UsuarioId);
        }

        protected override VendedorDraft ToDraft(VendedorViewModel vm)
        {
            return _mapping.ToDraft(vm);
        }

    }
}
