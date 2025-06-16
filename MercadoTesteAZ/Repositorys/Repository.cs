using MercadoTesteAZ.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class 
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

        public async Task<T> ObterPorIdAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(predicate);

            if (result is null)
                throw new ArgumentNullException();

            return result;
        }

        public async Task<T> AdicionarAsync(T entity)
        {        
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> AtualizarAsync(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeletarAsync(string id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result is null)
                throw new ArgumentNullException();

            _context.Set<T>().Remove(result);
            
            return result;
        }
    }
}
