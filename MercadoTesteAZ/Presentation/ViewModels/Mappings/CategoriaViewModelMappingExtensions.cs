using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Presentation.ViewModels;

namespace MercadoTesteAZ.Presentation.ViewModels.Mappings
{
    public static class CategoriaViewModelMappingExtensions
    {
        public static CategoriaViewModel ToCategoriaViewModel(this Categoria categoria)
        {
            var categoriaVM = new CategoriaViewModel()
            {
                CategoriaId = categoria.Id,
                Nome = categoria.Nome,
                ImagemUrl = categoria.ImagemUrl,
                Produtos = categoria.Produtos?.ToProdutoViewModelList()
            };
            return categoriaVM;
        }

        public static Categoria ToCategoria(this CategoriaViewModel categoriaVM)
        {
            if(categoriaVM.Produtos is null)
                return Categoria.Criar(categoriaVM.CategoriaId, categoriaVM.Nome, categoriaVM.ImagemUrl);
            
            return Categoria.Criar(categoriaVM.CategoriaId, categoriaVM.Nome, categoriaVM.ImagemUrl, categoriaVM.Produtos.ToProdutoList());
        }

        public static IEnumerable<CategoriaViewModel> ToCategoriaViewModelList(this IEnumerable<Categoria> categorias) 
        {
            return categorias.Select(x => ToCategoriaViewModel(x) ?? new());
        }
    }
}
