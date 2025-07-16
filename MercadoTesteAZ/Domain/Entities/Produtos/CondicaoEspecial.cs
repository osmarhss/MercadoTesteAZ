using MercadoTesteAZ.Domain.Entities.Empresas;

namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class CondicaoEspecial
    {
        public CondicaoEspecial(string? id)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id;
        }

        public string Id { get; private set; }
        public CondicaoPromocional? Promocao { get; private set; }
        public CondicaoPreVenda? PreVenda { get; private set; }
        public bool Esgotado { get; private set; }
        public string ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }
    }
}
