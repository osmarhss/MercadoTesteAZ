namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class CondicaoPreVenda
    {
        public CondicaoPreVenda(string? id) 
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
        }

        public string Id { get; private set; }
        public bool EmPreVenda { get; private set; }
        public DateTime? FimPreVenda { get; private set; }
        public DateTime? FimDaPreVenda { get; private set; }
        public string ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }
    }
}
