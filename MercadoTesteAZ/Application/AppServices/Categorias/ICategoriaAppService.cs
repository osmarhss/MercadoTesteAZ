using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Application.AppServices.Categorias
{
    public interface ICategoriaAppService<TViewModel, TDraft, TEntity> : IAppService<TViewModel, TDraft, TEntity>, ICategoriaAppServiceReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
        where TDraft : class, IDraft
    {
    }

    public interface ICategoriaAppServiceReadOnly<TViewModel, TEntity> : IAppServiceReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
    {
        Task<TViewModel> ObterPorNomeAsync(string nome);
    }
}
