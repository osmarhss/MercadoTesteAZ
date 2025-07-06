using MercadoTesteAZ.Domínio.Interfaces;

namespace MercadoTesteAZ.Models.Produtos
{
    public class HistoricoPreco : IEntity
    {
        public string Id { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime Data { get; private set; }
        public string ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }

    }
}
