using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Presentation.ViewModels.Categorias;
using MercadoTesteAZ.Presentation.ViewModels.Produtos;

namespace MercadoTesteAZ.Application.Mappings.Categorias
{
    public class CategoriaMapper : IMapper<CategoriaAdminViewModel, CategoriaDraft, Categoria>
    {
        private readonly IMapperToViewModel<ProdutoConsumidorViewModel, Produto> _produtoMapping;

        public CategoriaMapper(IMapperToViewModel<ProdutoConsumidorViewModel, Produto> produtoMapping)
        {
            _produtoMapping = produtoMapping;
        }

        public CategoriaDraft ToDraft(CategoriaAdminViewModel vm)
            => new CategoriaDraft() 
            {
                Id = vm.CategoriaId,
                Nome = vm.Nome,
                ImagemUrl = vm.ImagemUrl
            };

        public CategoriaAdminViewModel ToViewModel(Categoria entity)
        {
            return new CategoriaAdminViewModel() 
            {
                CategoriaId = entity.Id,
                Nome = entity.Nome,
                ImagemUrl = entity.ImagemUrl,
                Produtos = entity.Produtos.Select(p => _produtoMapping.ToViewModel(p))
            };
        }
    }
}
