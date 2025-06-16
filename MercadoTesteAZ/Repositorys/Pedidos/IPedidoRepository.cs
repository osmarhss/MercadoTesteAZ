using MercadoTesteAZ.Models.Pedidos;

namespace MercadoTesteAZ.Repositorys.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        public Task<IEnumerable<Pedido>> ObterPedidosPorClienteId(string id);
        public Task<IEnumerable<Pedido>> ObterPedidosPorVendedorId(string id);
        public Task<IEnumerable<Pedido>> ObterPedidosPorProdutoId(string id);
    }
}
