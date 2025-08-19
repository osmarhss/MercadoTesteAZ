using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Application.Mappings.Interfaces
{
    public interface IMapper<TViewModel, TDraft, TEntity> : IMapperToViewModel<TViewModel, TEntity>, IMapperToEntity<TViewModel, TDraft, TEntity> where TEntity : class, IEntity
    {
    }

    public interface IMapperToViewModel<TViewModel, TEntity> where TEntity : class, IEntity 
    {
        TViewModel ToViewModel(TEntity entity); //Utilizado por VMs de CRUD completo e por VMs de apenas consultas.
    }

    public interface IMapperToEntity<TViewModel, TDraft, TEntity> where TEntity : class, IEntity
    {
        TDraft ToDraft(TViewModel vm); // Utilizado para montar o objeto pela primeira vez do qual uma entidade será criada // POST
        // TEntity ToEntity(TViewModel vm); // Utilizado para montar o objeto para operações de atualização de uma entidade. // PUT
    }
}
