using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Domain.Entities.Categorias
{
    public class Categoria : IEntity
    {
        private readonly List<Produto> produtosList = new List<Produto>();
        protected Categoria() { }
        private Categoria(string id, string nome, string imagemUrl) 
        {
            Id = id;
            Nome = nome;
            ImagemUrl = imagemUrl;
        }
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string ImagemUrl { get; private set; }
        public IReadOnlyCollection<Produto> Produtos => produtosList;

        public static Categoria Adicionar(string nome, string imagemUrl) => new Categoria(Guid.NewGuid().ToString("D"), nome, imagemUrl);
        public void Atualizar(string nome, string imagemUrl) 
        {
            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}
