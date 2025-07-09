using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Domain.Entities.MeiosDePagamento
{
    public class CartaoDeCredito : IMetodosPagamento, IEntity
    {
        public string Nome => "Cartão de Crédito";
        public string Id { get; private set; }
        public string NumeroDoCartao { get; private set; }
        public string NomeTitular { get; private set; }
        public string DataVencimento { get; private set; }
        public string CVV { get; private set; }
        public string ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }

    }
}
