using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Application.ViewModels;

namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class HistoricoPreco : IEntity
    {
        protected HistoricoPreco() { }
        private HistoricoPreco(string id, decimal preco, DateTime data, string produtoId) 
        {
            Id = id;
            Preco = preco;
            Data = data;
            ProdutoId = produtoId;
        }
        public string Id { get; private set; } = string.Empty;
        public decimal Preco { get; private set; }
        public DateTime Data { get; private set; }
        public string ProdutoId { get; private set; } = string.Empty;
        public Produto? Produto { get; private set; }

        public static HistoricoPreco Criar(string id, decimal preco, DateTime data, string produtoId) 
            => new HistoricoPreco(id, preco, data, produtoId);
        public static HistoricoPreco Adicionar(decimal preco, string produtoId) 
            => new HistoricoPreco(Guid.NewGuid().ToString("D"), preco, DateTime.Now, produtoId);
        
    }
}
