using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.Mappings.HistoricoPrecos
{
    public class HistoricoPrecoMapper : IMapperToViewModel<HistoricoPrecoViewModel, HistoricoPreco>
    {
        public HistoricoPrecoViewModel ToViewModel(HistoricoPreco entity)
        {
            return new HistoricoPrecoViewModel()
            {
                HistoricoId = entity.Id,
                Preco = entity.Preco,
                Data = entity.Data,
                ProdutoId = entity.ProdutoId,
            };
        }
    }
}
