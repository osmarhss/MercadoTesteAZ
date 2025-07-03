using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.MeiosDePagamento;

namespace MercadoTesteAZ.Repositorys.Pagamentos
{
    public class CartaoDeCreditoRepository : Repository<CartaoDeCredito>, ICartaoDeCreditoRepository
    {
        public CartaoDeCreditoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
