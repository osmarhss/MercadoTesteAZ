using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.Clientes;

namespace MercadoTesteAZ.Repositorys.Clientes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
