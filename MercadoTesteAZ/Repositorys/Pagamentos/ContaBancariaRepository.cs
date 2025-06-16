using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.MeiosDePagamento;

namespace MercadoTesteAZ.Repositorys.Pagamentos
{
    public class ContaBancariaRepository : Repository<ContaBancaria>
    {
        public ContaBancariaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
