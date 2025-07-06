using MercadoTesteAZ.Context;
using MercadoTesteAZ.Exceptions;
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

            //if (categoria != null)
            //    return categoria;

            //throw new ExcecaoPersonalizada("Cliente não encontrado");
        }
    }
}
