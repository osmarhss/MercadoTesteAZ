using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels.Produtos;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Infra.Repositories.Produtos;

namespace MercadoTesteAZ.Application.AppServices.Produtos
{
    public class ProdutoAppServiceReadOnly : AppServiceReadOnly<ProdutoConsumidorViewModel, Produto>, IProdutoAppServiceReadOnly<ProdutoConsumidorViewModel, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppServiceReadOnly(IProdutoRepository produtoRepository, IMapperToViewModel<ProdutoConsumidorViewModel, Produto> mapping) : base(produtoRepository, mapping)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoConsumidorViewModel>> ObterPorNomeAsync(string nome)
        {
            var produtos = await _produtoRepository.ObterPorNomeAsync(nome);
            return produtos.Select(p => _mapping.ToViewModel(p));
        }
    }
}
