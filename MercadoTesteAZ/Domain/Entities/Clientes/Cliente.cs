using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.SharedValues;
using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Pedidos;


namespace MercadoTesteAZ.Domain.Entities.Clientes
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
