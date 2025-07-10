using Humanizer;
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
                ImagemUrl = categoria.ImagemUrl
            };
            return categoriaVM;
        }

        public static Categoria ToCategoria(this CategoriaViewModel categoriaVM)
        {
            var categoria = Categoria.Criar(categoriaVM.CategoriaId, categoriaVM.Nome, categoriaVM.ImagemUrl);
            return categoria;
        }

        public static IEnumerable<CategoriaViewModel> ToCategoriaViewModelList(List<Categoria> categorias) 
        {
            var categoriasViewModel = new List<CategoriaViewModel>();
            foreach (var categoria in categorias)
            {
                var categoriaVM = new CategoriaViewModel() 
                {
                    CategoriaId = categoria.Id,
                    Nome = categoria.Nome,
                    ImagemUrl = categoria.ImagemUrl
                };
                categoriasViewModel.Add(categoriaVM);
            }

            return categoriasViewModel;
        }
    }
}
