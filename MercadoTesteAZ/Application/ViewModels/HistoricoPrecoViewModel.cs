using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.ViewModels
{
    public class HistoricoPrecoViewModel
    {
        public string HistoricoId { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public string ProdutoId { get; set; }
    }
}
