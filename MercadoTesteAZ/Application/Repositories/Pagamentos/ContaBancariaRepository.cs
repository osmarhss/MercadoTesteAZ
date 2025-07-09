using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Infra.Context;

namespace MercadoTesteAZ.Application.Repositories.Pagamentos
{
    public class ContaBancariaRepository : Repository<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
