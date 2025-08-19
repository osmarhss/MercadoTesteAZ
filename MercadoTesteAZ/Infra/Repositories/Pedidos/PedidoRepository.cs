using MercadoTesteAZ.Domain.Entities.Pedidos;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Infra.Repositories.Pedidos
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pedido>> ObterPorClienteIdAsync(string id)
        {
            return await _context.Pedidos.Include(p => p.ProdutosComprados).Where(p => p.ProdutosComprados.Any(p => p.ProdutoId == id)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterPorVendedorIdAsync(string id) 
        {
            return await _context.Pedidos.Where(p => p.VendedorId == id).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterPorProdutoIdAsync(string id) 
        {
            return await _context.Pedidos.Where(p => p.ProdutosComprados.Any(p => p.ProdutoId == id)).AsNoTracking().ToListAsync();
        }

        public async Task<Pedido?> ObterPorIdComIncludesAsync(string id, params Expression<Func<Pedido, object>>[] includes)
        {
            var query = _context.Pedidos.AsQueryable();

            foreach (var include in includes) 
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
