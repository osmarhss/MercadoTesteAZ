using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Entities.Usuário;

namespace MercadoTesteAZ.Domain.Entities.Empresas
{
    public class Vendedor : IEntity
    {
        private readonly List<ContaBancaria> _contaBancariaList = new List<ContaBancaria>();
        protected Vendedor() { }
        private Vendedor(string id, string razaoSocial, string nomeFantasia, string cnpj, int qtdVendida, string usuarioId, IEnumerable<ContaBancaria>? conta, double? notaAvaliacao = null) 
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            QtdDeVendas = qtdVendida;
            NotaAvaliacao = notaAvaliacao;
            UsuarioId = usuarioId;
            _contaBancariaList = conta?.ToList() ?? new List<ContaBancaria>();
        }

        public string Id { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }
        public int QtdDeVendas { get; private set; }
        public double? NotaAvaliacao { get; private set; }
        public string UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public IReadOnlyCollection<ContaBancaria> ContasBancarias => _contaBancariaList.AsReadOnly();
        public IReadOnlyCollection<Produto> MeusProdutos { get; private set; } = new List<Produto>();

        public static Vendedor Adicionar(string razaoSocial, string nomeFantasia, string cnpj, string usuarioId, IEnumerable<ContaBancaria>? conta) 
            => new Vendedor(Guid.NewGuid().ToString("D"), razaoSocial, nomeFantasia, cnpj, 0, usuarioId, conta);

        public void Atualizar(string razaoSocial, string nomeFantasia) 
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public void AdicionarContasBancarias(IEnumerable<ContaBancaria> contas) 
        {
            foreach (var conta in contas) 
            {
                _contaBancariaList.Add(conta);
            }
        }
    }
}
