using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Application.AppServices.Base
{
    public interface IAppService<TViewModel, TDraft, TEntity> : IAppServiceReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
        where TDraft : class, IDraft
    {
        public Task<string> AdicionarAsync(TViewModel vm);
        public Task<TViewModel> AtualizarAsync(TViewModel vm);
        public Task DeletarAsync (string id);
    }

    public interface IAppServiceReadOnly<TViewModel, TEntity> where TEntity : class, IEntity
    {
        Task <IEnumerable<TViewModel>> ObterTodosAsync();
        Task<TViewModel> ObterPorIdAsync(string id);
    }
}
