using MercadoTesteAZ.Models.Categorias;

namespace MercadoTesteAZ.Models.Produtos
{
    public class Produto
    {
        public Produto(string id, string nome, string descricao, string fabricante, decimal preco, string imagemURL, string categoriaId)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            Nome = nome;
            Descricao = descricao;
            Fabricante = fabricante;
            Preco = preco;
            ImagemURL = imagemURL;
            CategoriaId = categoriaId;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Fabricante { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemURL { get; private set; }
        public string CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public IEnumerable<HistoricoPreco>? HistoricoDePrecos { get; private set; }

    }
}
