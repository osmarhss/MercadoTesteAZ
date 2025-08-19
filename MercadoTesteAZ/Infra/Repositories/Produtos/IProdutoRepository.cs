using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public Task<IEnumerable<Produto>> ObterPorCategoriaAsync(string categoriaId);
        public Task<IEnumerable<Produto>> ObterPorNomeAsync(string nome);
        public Task<IEnumerable<Produto>> ObterPorPreco(decimal[] faixaPreco);
        public Task<IEnumerable<Produto>> ObterPorFabricante(string fabricante);
        public Task<Produto?> ObterPorNomeEhVendedorId(string nome, string vendedorId);
    }
}
