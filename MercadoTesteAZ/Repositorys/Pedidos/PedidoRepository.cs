using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Repositorys.Pedidos
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pedido>> ObterPedidosPorClienteId(string id)
        {
            return await _context.Pedidos.Include(p => p.ProdutosComprados).Where(p => p.ProdutosComprados.Any(p => p.ProdutoId == id)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterPedidosPorVendedorId(string id) 
        {
            return await _context.Pedidos.Where(p => p.VendedorId == id).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterPedidosPorProdutoId(string id) 
        {
            return await _context.Pedidos.Where(p => p.ProdutosComprados.Any(p => p.ProdutoId == id)).AsNoTracking().ToListAsync();
        }
    }
}
