using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Application.AppServices.Empresas.Transportadoras
{
    public interface ITransportadoraAppService<TViewModel, TDraft, TEntity> : IAppService<TViewModel, TDraft, TEntity>, ITransportadoraReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
        where TDraft : class, IDraft
    {
        Task<TViewModel> ObterPorNomeAsync(string nome);
    }
    public interface ITransportadoraReadOnly<TViewModel, TEntity> : IAppServiceReadOnly<TViewModel, TEntity>
        where TEntity : class, IEntity
    {
    
    }
}
