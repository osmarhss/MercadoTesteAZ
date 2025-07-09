using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Domain.Entities.Categorias
{
    public class Categoria : IEntity
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public ICollection<Produto>? Produtos { get; private set; }

        public static Categoria Criar(string? id, string nome, string imagemUrl) 
        {
            return new Categoria()
            {
                Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id,
                Nome = nome,
                ImagemUrl = imagemUrl
            };
        }
    }
}
