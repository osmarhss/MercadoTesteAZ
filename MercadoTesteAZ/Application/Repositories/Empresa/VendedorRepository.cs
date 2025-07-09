using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Infra.Context;

namespace MercadoTesteAZ.Application.Repositories.Empresa
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
