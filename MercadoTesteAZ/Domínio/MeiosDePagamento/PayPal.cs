using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Models.Clientes;

namespace MercadoTesteAZ.Models.MeiosDePagamento
{
    public class PayPal : IMetodosPagamento, IEntity
    {
        private PayPal(){}
        public PayPal(string id, string email, string nomeTitular, string clienteId)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            Email = email;
            NomeTitular = nomeTitular;
            ClienteId = clienteId;
        }

        public string Id { get; private set; }
        public string Email { get; private set; }
        public string NomeTitular { get; private set; }
        public string ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
    }
}
