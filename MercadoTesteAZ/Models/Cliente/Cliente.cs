using MercadoTesteAZ.Models.MeiosDePagamento;
using MercadoTesteAZ.Models.Pedidos;
using MercadoTesteAZ.Models.SharedValues;
using MercadoTesteAZ.Models.Usuários;


namespace MercadoTesteAZ.Models.Clientes
{
    public class Cliente
    {
        public Cliente(string id, string primeiroNome, string sobrenome, string cpf, string usuarioId, DadosContato dadosContato) 
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            UsuarioId = usuarioId;
            DadosContato = dadosContato;
        }

        public string Id { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cpf { get; private set; }
        public string UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public DadosContato DadosContato { get; private set; }
        public IEnumerable<DadosGeograficos>? MeusEnderecosDeEntrega { get; private set; } = null;
        public IEnumerable<IMetodosPagamento>? MeusMeiosDePagamento { get; private set; }
        public IEnumerable<Pedido>? MeusPedidos { get; private set; }

    }
}
