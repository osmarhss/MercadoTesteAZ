using System.Linq.Expressions;

namespace MercadoTesteAZ.Repositorys
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> ObterTodosAsync();
        public Task<T> ObterPorIdAsync(Expression<Func<T, bool>> predicate);
        public Task<T> AdicionarAsync(T entity);
        public Task<T> AtualizarAsync(T entity);
        public Task<T> DeletarAsync(string id);
    }
}
