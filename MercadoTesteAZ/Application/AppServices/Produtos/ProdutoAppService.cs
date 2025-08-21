using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Produtos;
using MercadoTesteAZ.Presentation.ViewModels.Produtos;

namespace MercadoTesteAZ.Application.AppServices.Produtos
{
    public class ProdutoAppService : AppService<ProdutoVendedorViewModel, ProdutoDraft, Produto>, IProdutoAppService<ProdutoVendedorViewModel, ProdutoDraft, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoAppService(IUnityOfWork uow, IMapper<ProdutoVendedorViewModel, ProdutoDraft, Produto> mapping, IProdutoRepository produtoRepository) : base(produtoRepository, uow, mapping)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoVendedorViewModel>> ObterPorNomeAsync(string nome)
        {
            var produtos = await _produtoRepository.ObterPorNomeAsync(nome);
            return produtos.Select(p => _mapping.ToViewModel(p));
        }

        protected override Produto CriarEntidade(ProdutoDraft draft)
        {
            return Produto.AdicionarEntidade(draft.Nome, draft.Descricao, draft.Fabricante, draft.Preco, draft.Estoque, draft.ImagemURL, draft.VendedorId, draft.CategoriaId);
        }

        protected override void AtualizarEntidade(ProdutoDraft draft, Produto antiga)
        {
            antiga.AtualizarEntidade(draft.Nome, draft.Descricao, draft.Fabricante, draft.Preco, draft.Ativo, draft.Estoque, draft.ImagemURL);
        }

        protected override ProdutoDraft ToDraft(ProdutoVendedorViewModel vm)
        {
            return _mapping.ToDraft(vm);
        }

    }
}
