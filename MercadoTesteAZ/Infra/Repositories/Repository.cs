using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity 
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            var lista = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            return lista;
        }

        public async Task<TEntity?> ObterPorIdAsync(string id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<string> AdicionarAsync(TEntity entity)
        {        
            await _context.Set<TEntity>().AddAsync(entity);
            return entity.Id;
        }

        public Task AtualizarAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeletarAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
