using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Presentation.ViewModels.HistoricosDePreco;

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
