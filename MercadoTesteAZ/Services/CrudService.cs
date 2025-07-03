using MercadoTesteAZ.Repositorys;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly UnityOfWork _uow;
        private readonly IRepository<T> _repository;
        public CrudService(UnityOfWork uow, IRepository<T> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async virtual Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async virtual Task<T> ObterPorIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.ObterPorIdAsync(predicate);
        }

        public async virtual Task AdicionarAsync(T entity)
        {
            var entidadeSalva = await _repository.AdicionarAsync(entity);
            await _uow.CommitAsync();
        }

        public async virtual Task AtualizarAsync(T entity)
        {
            var entidadeAtt = await _repository.AtualizarAsync(entity);
            await _uow.CommitAsync();
        }

        public async virtual Task DeletarAsync(string id)
        {
            var entidadeExc = await _repository.DeletarAsync(id);
            await _uow.CommitAsync();
        }

    }
}
