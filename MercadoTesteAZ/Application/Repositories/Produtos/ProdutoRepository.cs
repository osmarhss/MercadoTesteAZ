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
            return await _context.Produtos.Where(p => p.CategoriaId == categoriaId).Include(p => p.Categoria).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorPreco(decimal[] faixaPreco)
        {
            return await _context.Produtos.Where(p => p.Preco >= faixaPreco[0] && p.Preco <= faixaPreco[1]).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFabricante(string fabricante)
        {
            return await _context.Produtos.Where(p => p.Fabricante == fabricante).AsNoTracking().ToListAsync();
        }
    }
}
