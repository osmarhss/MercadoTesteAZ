using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Produtos;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Repositorys.Produtos
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(string categoriaId) 
        {
            var result = await _context.Produtos.Where(p => p.CategoriaId == categoriaId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Produto>> ObterProdutoPorPreco(decimal[] faixaPreco) 
        {
            var result = await _context.Produtos.Where(p => p.Preco >= faixaPreco[0] && p.Preco <= faixaPreco[1]).ToListAsync();
            return result;
        }
    }
}
