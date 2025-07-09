using System.Collections.ObjectModel;
using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.SharedValues;
using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Domain.Entities.Pedidos
{
    public class Pedido : IEntity
    {
        public string Id { get; private set; }
        public decimal Frete { get; private set; }
        public decimal PrecoTotal { get; private set; }
        public DateTime HorarioCompra { get; private set; }
        public StatusPedido StatusPedido { get; private set; }
        public DadosGeograficos EnderecoEntrega { get; private set; }
        public string VendedorId { get; private set; }
        public Vendedor? Vendedor { get; private set; }
        public string ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
        public IEnumerable<PedidoProduto> ProdutosComprados { get; set; } = new List<PedidoProduto>();
    }
}
