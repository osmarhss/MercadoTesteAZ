using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MercadoTesteAZ.Infra.Repositories.Empresa
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Vendedor?> ObterComContaBancariaAsync(string id)
        {
            return await _context.Vendedores.Include(v => v.ContasBancarias).AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vendedor?> ObterPorCnpjAsync(string cnpj)
        {
            return await _context.Vendedores.AsNoTracking().FirstOrDefaultAsync(v => v.CNPJ == cnpj);
        }

        public Task<Vendedor?> ObterPorRazaoSocialAsync(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
