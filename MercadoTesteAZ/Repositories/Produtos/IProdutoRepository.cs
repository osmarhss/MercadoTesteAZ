using MercadoTesteAZ.Models.Produtos;

namespace MercadoTesteAZ.Repositorys.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(string categoriaId);
    }
}
