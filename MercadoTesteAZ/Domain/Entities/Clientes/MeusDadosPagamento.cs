using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Domain.Entities.Clientes
{
    public class MeusDadosPagamento : IEntity
    {
        public string Id { get; private set; }
        public string ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
        public IEnumerable<CartaoDeCredito>? MeusCartoes { get; private set; }
    }
}
