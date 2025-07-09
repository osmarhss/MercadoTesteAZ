using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Application.Repositories.Produtos
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
