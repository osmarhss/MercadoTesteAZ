using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels.Categorias;
using MercadoTesteAZ.Application.ViewModels.Produtos;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.Mappings.Categorias
{
    public class CategoriaConsumidorMapper : IMapperToViewModel<CategoriaConsumidorViewModel, Categoria>
    {
        private readonly IMapperToViewModel<ProdutoConsumidorViewModel, Produto> _produtoMapping;

        public CategoriaConsumidorMapper(IMapperToViewModel<ProdutoConsumidorViewModel, Produto> produtoMapping)
        {
            _produtoMapping = produtoMapping;
        }

        public CategoriaConsumidorViewModel ToViewModel(Categoria entity)
        {
            return new CategoriaConsumidorViewModel()
            {
                Nome = entity.Nome,
                ImagemUrl = entity.ImagemUrl,
                Produtos = entity.Produtos.Select(p => _produtoMapping.ToViewModel(p))
            };
        }
    }
}
