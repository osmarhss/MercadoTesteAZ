using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Infra.Repositories.Produtos
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoriaAsync(string categoriaId)
        {
            return await _context.Produtos.Where(p => p.CategoriaId == categoriaId).Include(p => p.Categoria).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorPreco(decimal[] faixaPreco)
        {
            return await _context.Produtos.Where(p => p.Preco >= faixaPreco[0] && p.Preco <= faixaPreco[1]).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorFabricante(string fabricante)
        {
            return await _context.Produtos.Where(p => p.Fabricante == fabricante).AsNoTracking().ToListAsync();
        }

        public async Task<Produto?> ObterPorNomeEhVendedorId(string nome, string vendedorId) 
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Nome == nome && p.VendedorId == vendedorId);
        }

        public async Task<IEnumerable<Produto>> ObterPorNomeAsync(string nome)
        {
            return await _context.Produtos.Where(p => p.Nome == nome).AsNoTracking().ToListAsync();
        }
    }
}
