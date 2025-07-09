using System.Linq.Expressions;

namespace MercadoTesteAZ.Application.Repositories
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> ObterTodosAsync();
        public Task<T?> ObterPorIdAsync(Expression<Func<T, bool>> predicate);
        public Task AdicionarAsync(T entity);
        public Task AtualizarAsync(T entity);
        public Task DeletarAsync(T entity);
    }
}
