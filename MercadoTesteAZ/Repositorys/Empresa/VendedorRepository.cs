using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Empresa;

namespace MercadoTesteAZ.Repositorys.Empresa
{
    public class VendedorRepository : Repository<Vendedor>
    {
        public VendedorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
