using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Application.AppServices.Produtos
{
    public interface IProdutoAppService<TViewModel, TDraft, TEntity> : IAppService<TViewModel, TDraft, TEntity>, IProdutoAppServiceReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
        where TDraft : class, IDraft
    {
    }

    public interface IProdutoAppServiceReadOnly<TViewModel, TEntity> : IAppServiceReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
    {
        Task<IEnumerable<TViewModel>> ObterPorNomeAsync(string nome);
    }
}
