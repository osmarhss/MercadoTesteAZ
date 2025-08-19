using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.ViewModels.Categorias;

namespace MercadoTesteAZ.Application.AppServices.Categorias
{
    public interface ICategoriaAppService<TViewModel, TDraft, TEntity> : IAppService<TViewModel, TDraft, TEntity>, ICategoriaAppServiceReadOnly<TViewModel, TEntity>
    {
    }

    public interface ICategoriaAppServiceReadOnly<TViewModel, TEntity> : IAppServiceReadOnly<TViewModel, TEntity>
    {
        Task<TViewModel> ObterPorNomeAsync(string nome);
    }
}
