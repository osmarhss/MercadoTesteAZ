using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Domain.Entities.Categorias
{
    public class Categoria : IEntity
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public List<Produto>? Produtos { get; private set; } = new List<Produto>();

        public static Categoria Criar(string? id, string nome, string imagemUrl) 
        {
            return new Categoria()
            {
                Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id,
                Nome = nome,
                ImagemUrl = imagemUrl
            };
        }

        public static Categoria Criar(string? id, string nome, string imagemUrl, IEnumerable<Produto> produtos) 
        {
            return new Categoria()
            {
                Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id,
                Nome = nome,
                ImagemUrl = imagemUrl,
                Produtos = produtos.ToList()
            };
        }
    }
}
