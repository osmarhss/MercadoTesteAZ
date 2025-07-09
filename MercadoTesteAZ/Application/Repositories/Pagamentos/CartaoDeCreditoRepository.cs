using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Infra.Context;

namespace MercadoTesteAZ.Application.Repositories.Pagamentos
{
    public class CartaoDeCreditoRepository : Repository<CartaoDeCredito>, ICartaoDeCreditoRepository
    {
        public CartaoDeCreditoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
