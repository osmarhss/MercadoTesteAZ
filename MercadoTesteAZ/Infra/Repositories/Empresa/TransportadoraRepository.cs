using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Infra.Repositories.Empresa
{
    public class TransportadoraRepository : Repository<Transportadora>, ITransportadoraRepository
    {
        public TransportadoraRepository(AppDbContext context) : base(context) 
        { 
        }
        
        public async Task<Transportadora?> ObterPorNomeAsync(string nome)
        {
            return await _context.Transportadoras.AsNoTracking().FirstOrDefaultAsync(t => t.Nome == nome);
        }
    }
}
