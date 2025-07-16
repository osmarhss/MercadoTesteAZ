using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Presentation.ViewModels
{
    public class CategoriaViewModel
    {
        public string CategoriaId { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public IEnumerable<ProdutoViewModel>? Produtos { get; set;} 
    }
}
