using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Entities.Usuários;

namespace MercadoTesteAZ.Domain.Entities.Empresas
{
    public class Vendedor : IEntity
    {
        private readonly List<ContaBancaria> _contaBancariaList = new();
        private readonly List<Produto> _produtosList = new();
        protected Vendedor() { }
        private Vendedor(string id, string razaoSocial, string nomeFantasia, string cnpj, int qtdVendida, string appUserId, double? notaAvaliacao = null) 
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            QtdDeVendas = qtdVendida;
            NotaAvaliacao = notaAvaliacao;
            ApplicationUserId = appUserId;
        }

        public string Id { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }
        public int QtdDeVendas { get; private set; }
        public double? NotaAvaliacao { get; private set; }
        public string ApplicationUserId { get; private set; }
        public ApplicationUser? User { get; private set; }
        public IReadOnlyCollection<ContaBancaria> ContasBancarias => _contaBancariaList.AsReadOnly();
        public IReadOnlyCollection<Produto> MeusProdutos => _produtosList.AsReadOnly();

        public static Vendedor Adicionar(string razaoSocial, string nomeFantasia, string cnpj, string usuarioId) 
            => new Vendedor(Guid.NewGuid().ToString("D"), razaoSocial, nomeFantasia, cnpj, 0, usuarioId);

        public void Atualizar(string razaoSocial, string nomeFantasia) 
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }
    }
}
