using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.SharedValues;
using MercadoTesteAZ.Infra.Context;

namespace MercadoTesteAZ.Application.Repositories.SharedValues
{
    public class DadosContatoRepository : Repository<DadosContato>
    {
        public DadosContatoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
