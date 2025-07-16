using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Presentation.ViewModels.Mappings
{
    public static class ProdutoViewModelMappingExtensions
    {
        public static Produto ToProduto(this ProdutoViewModel produtoVM) 
        {
            return Produto.Criar(produtoVM.ProdutoId, produtoVM.Nome, produtoVM.Descricao, produtoVM.Fabricante, produtoVM.Preco, produtoVM.Estoque, produtoVM.Ativo, produtoVM.ImagemURL,
                    produtoVM.Condicao, produtoVM.VendedorId, produtoVM.CategoriaId, produtoVM.HistoricoDePrecos);
        }

        public static ProdutoViewModel ToProdutoViewModel(this Produto produto) 
        {
            return new ProdutoViewModel()
            {
                ProdutoId = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Fabricante = produto.Fabricante,
                Preco = produto.Preco,
                Estoque = produto.Estoque,
                QtdVendida = produto.QtdVendida,
                Ativo = produto.Ativo,
                ImagemURL = produto.ImagemURL,
                Condicao = produto.Condicao,
                VendedorId = produto.VendedorId,
                CategoriaId = produto.CategoriaId,
                HistoricoDePrecos = produto.HistoricoDePrecos
            };
        }

        public static IEnumerable<ProdutoViewModel> ToProdutoViewModelList(this IEnumerable<Produto> listaProdutos) 
        {
            return listaProdutos.Select(x => ToProdutoViewModel(x) ?? new());
        }

        public static IEnumerable<Produto> ToProdutoList(this IEnumerable<ProdutoViewModel> listaProdutosVM) 
        {
            return listaProdutosVM.Select(x => ToProduto(x) ?? new());
        }
    }
}
