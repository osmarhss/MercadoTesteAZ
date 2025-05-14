using MercadoTesteAZ.Models.MeiosDePagamento;

namespace MercadoTesteAZ.Models.Clientes
{
    public class MeusDadosPagamento
    {
        public MeusDadosPagamento(string id, string clienteId)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            ClienteId = clienteId;
        }
        public string Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public IEnumerable<CartaoDeCredito>? MeusCartoes { get; set; }
    }
}
