using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Presentation.ViewModels
{
    public class HistoricoPrecoViewModel
    {
        public string HistoricoId { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime Data { get; private set; }
        public string ProdutoId { get; private set; }
    }
}
