using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Pagamentos
{
    public class CartaoDeCreditoRepository : Repository<CartaoDeCredito>, ICartaoDeCreditoRepository
    {
        public CartaoDeCreditoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
