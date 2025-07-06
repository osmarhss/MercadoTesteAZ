using MercadoTesteAZ.Context;
using MercadoTesteAZ.Domínio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class, IEntity 
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            var lista = await _context.Set<T>().AsNoTracking().ToListAsync();
            return lista;
        }

        public async Task<T?> ObterPorIdAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task AdicionarAsync(T entity)
        {        
            await _context.Set<T>().AddAsync(entity);
        }

        public Task AtualizarAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeletarAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
