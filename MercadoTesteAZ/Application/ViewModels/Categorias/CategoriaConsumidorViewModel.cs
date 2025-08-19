using MercadoTesteAZ.Application.ViewModels.Produtos;

namespace MercadoTesteAZ.Application.ViewModels.Categorias
{
    public class CategoriaConsumidorViewModel
    {
        public string Nome { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public IEnumerable<ProdutoConsumidorViewModel> Produtos { get; set; } = new List<ProdutoConsumidorViewModel>();
    }
}
