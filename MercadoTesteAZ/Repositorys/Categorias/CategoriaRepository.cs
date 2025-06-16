using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Categorias;

namespace MercadoTesteAZ.Repositorys.Categorias
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
