using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities;
using MercadoTesteAZ.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Application.Repositories.Categorias
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Categoria?> ObterPorNomeAsync(string nome)
        {
            return await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == nome);
        }
    }
}
