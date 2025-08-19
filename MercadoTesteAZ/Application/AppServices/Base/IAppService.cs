namespace MercadoTesteAZ.Application.AppServices.Base
{
    public interface IAppService<TViewModel, TDraft, TEntity> : IAppServiceReadOnly<TViewModel, TEntity>
    {
        public Task<string> AdicionarAsync(TViewModel vm);
        public Task<TViewModel> AtualizarAsync(TViewModel vm);
        public Task DeletarAsync (string id);
    }

    public interface IAppServiceReadOnly<TViewModel, TEntity> 
    {
        Task <IEnumerable<TViewModel>> ObterTodosAsync();
        Task<TViewModel> ObterPorIdAsync(string id);
    }
}
