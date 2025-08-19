using MercadoTesteAZ.Domain.Entities.Clientes;
using MercadoTesteAZ.Domain.Entities;
using MercadoTesteAZ.Infra.Context;
using Microsoft.EntityFrameworkCore;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Clientes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cliente?> ObterPorCpfAsync(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf);
        }
    }
}
