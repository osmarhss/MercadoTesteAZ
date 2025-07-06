using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Models.Pedidos;
using MercadoTesteAZ.Models.Produtos;

namespace MercadoTesteAZ.Models.Pedidos
{
    public class PedidoProduto : IEntity
    {
        public string Id { get; private set; }
        public string PedidoId { get; private set; }
        public Pedido? Pedido { get; private set; }
        public string ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }
        public int Quantidade { get; set; }

    }
}
