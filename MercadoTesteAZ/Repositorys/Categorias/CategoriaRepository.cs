using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Categorias;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Repositorys.Categorias
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Categoria?> ObterPorNome(string nome)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Nome == nome);
        }
    }
}
