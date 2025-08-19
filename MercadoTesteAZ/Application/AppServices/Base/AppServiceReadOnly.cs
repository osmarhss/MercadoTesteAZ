using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Application.AppServices.Base
{
    public class AppServiceReadOnly<TViewModel, TEntity> : IAppServiceReadOnly<TViewModel, TEntity> where TEntity : class, IEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapperToViewModel<TViewModel, TEntity> _mapping;

        public AppServiceReadOnly(IRepository<TEntity> repository, IMapperToViewModel<TViewModel, TEntity> mapping)
        {
            _repository = repository;
            _mapping = mapping;
        }

        public virtual async Task<IEnumerable<TViewModel>> ObterTodosAsync()
        {
            var entidades = await _repository.ObterTodosAsync();
            return entidades.Select(e => _mapping.ToViewModel(e));
        }

        public virtual async Task<TViewModel> ObterPorIdAsync(string id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);
            if (entidade is null)
                throw new ExcecaoPersonalizada($"{typeof(TEntity).Name} não encontrada pelo id: {id}");

            return _mapping.ToViewModel(entidade);
        }
    }
}
