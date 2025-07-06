using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Exceptions;
using MercadoTesteAZ.Repositorys;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, IEntity
    {
        private readonly IUnityOfWork _uow;
        private readonly IRepository<T> _repository;
        public CrudService(IUnityOfWork uow, IRepository<T> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async virtual Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async virtual Task<T> ObterPorIdAsync(string id)
        {
            var entidadeExistente = await _repository.ObterPorIdAsync(e => e.Id == id);

            if (entidadeExistente is null)
                throw new ExcecaoPersonalizada($"Não há registro com o id {id}.");

            return entidadeExistente;
        }

        public async virtual Task AdicionarAsync(T entity)
        {
            await VerificarEntidadeNaoExistentePorId(entity.Id);

            await _repository.AdicionarAsync(entity);
            await _uow.CommitAsync();
        }

        public async virtual Task AtualizarAsync(T entity)
        {
            await VerificarEntidadeNaoExistentePorId(entity.Id);

            await _repository.AtualizarAsync(entity);
            await _uow.CommitAsync();
        }

        public async virtual Task DeletarAsync(string id)
        {
            var entidade = await VerificarEntidadeNaoExistentePorId(id);

            await _repository.DeletarAsync(entidade);
            await _uow.CommitAsync();
        }

        public async Task<T> VerificarEntidadeNaoExistentePorId(string id) 
        {
            var entidadeExistente = await _repository.ObterPorIdAsync(e => e.Id == id);

            if (entidadeExistente != null)
                return entidadeExistente;
                
            throw new ExcecaoPersonalizada($"Não foi encontrada entidade com o id {id}.");
        }

        public async Task VerificarEntidadeExistentePorId(string id) 
        {
            var entidadeExistente = await _repository.ObterPorIdAsync(c => c.Id == id);

            if (entidadeExistente != null)
                throw new ExcecaoPersonalizada($"Entidade já existente com o id: {id}.");
        }
    }
}
