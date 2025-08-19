using System.Linq.Expressions;

namespace MercadoTesteAZ.Infra.Repositories
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> ObterTodosAsync();
        public Task<TEntity?> ObterPorIdAsync(string id);
        public Task<string> AdicionarAsync(TEntity entity);
        public Task AtualizarAsync(TEntity entity);
        public Task DeletarAsync(TEntity entity);
    }
}
