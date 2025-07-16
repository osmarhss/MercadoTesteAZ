namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class CondicaoPromocional
    {
        public CondicaoPromocional(string? id)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
        }

        public string Id { get; private set; }
        public bool Ativa { get; private set; }
        public DateTime? InicioPromocao { get; private set; }
        public DateTime? TerminoPromocao { get; private set; }
        public string ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }
    }
}
