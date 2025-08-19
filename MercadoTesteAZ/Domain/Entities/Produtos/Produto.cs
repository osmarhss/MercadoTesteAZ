using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class Produto : IEntity
    {
        private readonly List<HistoricoPreco> _historicoPrecoList = new List<HistoricoPreco>();
        protected Produto() { }
        private Produto(string id, string nome, string descricao, string fabricante, decimal preco, int estoque, int qtdVendida, bool ativo,
            string imagemUrl, DateTime? dataCadastro, DateTime? ultimaAtualizacao, string vendedorId, string categoriaId) 
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Fabricante = fabricante;
            Preco = preco;
            Estoque = estoque;
            QtdVendida = qtdVendida;
            Ativo = ativo;
            ImagemURL = imagemUrl;
            DataCadastro = dataCadastro;
            UltimaAtualizacao = ultimaAtualizacao;
            VendedorId = vendedorId;
            CategoriaId = categoriaId;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Fabricante { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public int QtdVendida { get; private set; }
        public bool Ativo { get; private set; }
        public string ImagemURL { get; private set; }
        public DateTime? DataCadastro { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        //public CondicaoEspecial? Condicao { get; private set; }
        public string VendedorId { get; private set; }
        public Vendedor? Vendedor { get; private set; }
        public string CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public IReadOnlyCollection<HistoricoPreco> HistoricoDePrecos => _historicoPrecoList.AsReadOnly();

        public static Produto AdicionarEntidade(string nome, string descricao, string fabricante, decimal preco, int estoque, string imagemUrl, string vendedorId, string categoriaId)
        {
            var produto = new Produto(Guid.NewGuid().ToString("D"), nome, descricao, fabricante, preco, estoque, 0, true, imagemUrl, DateTime.Now, DateTime.Now, vendedorId, categoriaId);
            produto._historicoPrecoList.Add(HistoricoPreco.Adicionar(preco, produto.Id));

            return produto;
        }

        public void AtualizarEntidade(string nome, string descricao, string fabricante, decimal preco, bool ativo, int estoque, string imagemUrl) 
        {
            Nome = nome;
            Descricao = descricao;
            Fabricante = fabricante;
            Preco = preco;
            Ativo = ativo;
            Estoque = estoque;
            ImagemURL = imagemUrl;
            UltimaAtualizacao = DateTime.Now;

            if (Preco != preco)
                _historicoPrecoList.Add(HistoricoPreco.Adicionar(preco, Id));
        }
    }
}
