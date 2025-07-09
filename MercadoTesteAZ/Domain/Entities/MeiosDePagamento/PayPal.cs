using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Domain.Entities.MeiosDePagamento
{
    public class PayPal : IMetodosPagamento, IEntity
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string NomeTitular { get; private set; }
        public string ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
    }
}
