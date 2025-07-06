using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Models.MeiosDePagamento;
using MercadoTesteAZ.Models.Pedidos;
using MercadoTesteAZ.Models.SharedValues;
using MercadoTesteAZ.Models.Usuários;


namespace MercadoTesteAZ.Models.Clientes
{
    public class Cliente : IEntity
    {
        public string Id { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }
        public string UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public DadosContato DadosContato { get; private set; }
        public IEnumerable<DadosGeograficos>? MeusEnderecosDeEntrega { get; private set; } = null;
        public IEnumerable<MeusDadosPagamento>? MeusMeiosDePagamento { get; private set; }
        public IEnumerable<Pedido>? MeusPedidos { get; private set; }

    }
}
