using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Domain.Entities.Pedidos
{
    public class PedidoProduto : IEntity
    {
        public string Id { get; private set; }
        public string PedidoId { get; private set; }
        public Pedido? Pedido { get; private set; }
        public string ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }
        public string TransportadoraId { get; private set; }
        public Transportadora? Transportadora { get; private set; }
        public int Quantidade { get; private set; }
        public string CodDeRastreio { get; private set; }

    }
}
