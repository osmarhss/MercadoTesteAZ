using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Pedidos;

namespace MercadoTesteAZ.Application.Repositories.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        public Task<IEnumerable<Pedido>> ObterPedidosPorClienteId(string id);
        public Task<IEnumerable<Pedido>> ObterPedidosPorVendedorId(string id);
        public Task<IEnumerable<Pedido>> ObterPedidosPorProdutoId(string id);
    }
}
