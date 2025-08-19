using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels.Categorias;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Categorias;

namespace MercadoTesteAZ.Application.AppServices.Categorias
{
    public class CategoriaAppService : AppService<CategoriaAdminViewModel, CategoriaDraft, Categoria>, ICategoriaAppService<CategoriaAdminViewModel, CategoriaDraft, Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaAppService(IUnityOfWork uow, IMapper<CategoriaAdminViewModel, CategoriaDraft, Categoria> mapping, ICategoriaRepository categoriaRepository) : base(categoriaRepository, uow, mapping)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaAdminViewModel> ObterPorNomeAsync(string nome)
        {
            var categoria = await _categoriaRepository.ObterPorNomeAsync(nome);
            if (categoria is null)
                throw new ExcecaoPersonalizada("Categoria não encontrada");

            return _mapping.ToViewModel(categoria);
        }

        public override async Task<string> AdicionarAsync(CategoriaAdminViewModel vm)
        {
            await VerificaEntidadeExistentePeloNome(vm.Nome);
            return await base.AdicionarAsync(vm);
        }

        public override async Task<CategoriaAdminViewModel> AtualizarAsync(CategoriaAdminViewModel vm)
        {
            await VerificaEntidadeExistentePeloNome(vm.Nome);
            return await base.AtualizarAsync(vm);
        }

        private async Task VerificaEntidadeExistentePeloNome(string nome) 
        {
            var entidade = await _categoriaRepository.ObterPorNomeAsync(nome);
            if (entidade != null)
                throw new ExcecaoPersonalizada($"Categoria já existente com o nome: {nome}");
        }

        protected override CategoriaDraft ToDraft(CategoriaAdminViewModel vm)
        {
            return _mapping.ToDraft(vm);
        }

        protected override Categoria CriarEntidade(CategoriaDraft draft)
        {
            return Categoria.Adicionar(draft.Nome, draft.ImagemUrl);
        }

        protected override void AtualizarEntidade(CategoriaDraft draft, Categoria antiga)
        {
            antiga.Atualizar(draft.Nome, draft.ImagemUrl);
        }

    }
}
