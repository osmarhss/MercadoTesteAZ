using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels.Produtos;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.Mappings.Produtos
{
    public class ProdutoConsumidorMapper : IMapperToViewModel<ProdutoConsumidorViewModel, Produto>
    {
        public ProdutoConsumidorViewModel ToViewModel(Produto entity)
            => new ProdutoConsumidorViewModel()
            {
                Nome = entity.Nome,
                Descricao = entity.Descricao,
                Fabricante = entity.Fabricante,
                Preco = entity.Preco,
                ImagemURL = entity.ImagemURL
            };
    }
}
