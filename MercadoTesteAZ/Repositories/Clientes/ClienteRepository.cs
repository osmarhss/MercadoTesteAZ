using MercadoTesteAZ.Context;
using MercadoTesteAZ.Exceptions;
using MercadoTesteAZ.Models.Clientes;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Repositorys.Clientes
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
