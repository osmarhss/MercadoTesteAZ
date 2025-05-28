using MercadoTesteAZ.Models.Produtos;

namespace MercadoTesteAZ.Models.Categorias
{
    public class Categoria
    {
        public Categoria(string id, string nome, string imagemUrl)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
            Nome = nome;
            ImagemUrl = imagemUrl;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public ICollection<Produto>? Produtos { get; private set; }

    }
}
