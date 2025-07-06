using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Models.Clientes;

namespace MercadoTesteAZ.Models.MeiosDePagamento
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
