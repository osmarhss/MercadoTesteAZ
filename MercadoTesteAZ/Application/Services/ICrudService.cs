using System.Linq.Expressions;

namespace MercadoTesteAZ.Application.Services
{
    public interface ICrudService<T>
    {
        public Task<IEnumerable<T>> ObterTodosAsync();
        public Task<T> ObterPorIdAsync(string id);
        public Task AdicionarAsync(T entity);
        public Task AtualizarAsync(T entity);
        public Task DeletarAsync(string id);
    }
}
