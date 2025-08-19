using MercadoTesteAZ.Domain.Entities.SharedValues;
using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.SharedValues
{
    public class DadosGeograficosRepository : Repository<DadosGeograficos>
    {
        public DadosGeograficosRepository(AppDbContext context) : base(context)
        {
        }
    }
}
