using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Pagamentos
{
    public class ContaBancariaRepository : Repository<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
