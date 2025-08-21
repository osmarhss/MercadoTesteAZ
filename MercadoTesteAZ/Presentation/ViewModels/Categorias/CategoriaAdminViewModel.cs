using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Presentation.ViewModels.Produtos;

namespace MercadoTesteAZ.Presentation.ViewModels.Categorias
{
    public class CategoriaAdminViewModel
    {
        public string CategoriaId { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public IEnumerable<ProdutoConsumidorViewModel> Produtos { get; set; } = new List<ProdutoConsumidorViewModel>();
    }
}
