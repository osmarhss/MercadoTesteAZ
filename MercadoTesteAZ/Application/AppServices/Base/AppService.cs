using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Application.AppServices.Base
{
    public abstract class AppService<TViewModel, TDraft, TEntity> : IAppService<TViewModel, TDraft, TEntity> 
        where TEntity : class, IEntity
        where TDraft : class, IDraft
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnityOfWork _uow;
        protected readonly IMapper<TViewModel, TDraft, TEntity> _mapping;
        protected AppService(IRepository<TEntity> repository, IUnityOfWork uow, IMapper<TViewModel, TDraft, TEntity> mapping)
        {
            _repository = repository;
            _uow = uow;
            _mapping = mapping;
        }

        public virtual async Task<string> AdicionarAsync(TViewModel vm)
        {
            var draft = ToDraft(vm);
            var entity = CriarEntidade(draft);

            await VerificarEntidadeExistentePorId(entity.Id);

            await _repository.AdicionarAsync(entity);
            await _uow.CommitAsync();

            return entity.Id;
        }

        public virtual async Task<TViewModel> AtualizarAsync(TViewModel vm)
        {
            var draft = ToDraft(vm);
            var entidadeAntiga = await _repository.ObterPorIdAsync(draft.Id);

            if (entidadeAntiga is null)
                throw new ExcecaoPersonalizada($"{typeof(TEntity).Name} a ser atualizada não foi encontrada pelo id: {draft.Id}");

            AtualizarEntidade(draft, entidadeAntiga);

            await _repository.AtualizarAsync(entidadeAntiga);
            await _uow.CommitAsync();

            return _mapping.ToViewModel(entidadeAntiga);
        }

        public virtual async Task<TViewModel> ObterPorIdAsync(string id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);

            if (entidade is null)
                throw new ExcecaoPersonalizada($"{typeof(TEntity).Name} não encontrada pelo id: {id}");

            return _mapping.ToViewModel(entidade);
        }

        public virtual async Task<IEnumerable<TViewModel>> ObterTodosAsync()
        {
            var entidades = await _repository.ObterTodosAsync();
            return entidades.Select(e => _mapping.ToViewModel(e));
        }

        public virtual async Task DeletarAsync(string id)
        {
            var entidade = await _repository.ObterPorIdAsync(id);
            if (entidade is null)
                throw new ExcecaoPersonalizada($"{typeof(TEntity).Name} a ser excluída não foi encontrada pelo id: {id}");

            await _repository.DeletarAsync(entidade);
        }

        protected virtual async Task VerificarEntidadeExistentePorId(string id) 
        {
            var entidadeExistente = await _repository.ObterPorIdAsync(id);

            if (entidadeExistente != null)
                throw new ExcecaoPersonalizada($"{typeof(TEntity).Name} já existente com o id: {id}");
        }

        protected abstract TDraft ToDraft(TViewModel vm);
        protected abstract TEntity CriarEntidade(TDraft draft);
        protected abstract void AtualizarEntidade(TDraft draft, TEntity antiga);
    }
}
