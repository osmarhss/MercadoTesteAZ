using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Pedidos;
using MercadoTesteAZ.Infra.Repositories;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Infra.Repositories.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        public Task<IEnumerable<Pedido>> ObterPorClienteIdAsync(string id);
        public Task<IEnumerable<Pedido>> ObterPorVendedorIdAsync(string id);
        public Task<IEnumerable<Pedido>> ObterPorProdutoIdAsync(string id);
        public Task<Pedido?> ObterPorIdComIncludesAsync(string id, params Expression<Func<Pedido, object>>[] includes);
    }
}
