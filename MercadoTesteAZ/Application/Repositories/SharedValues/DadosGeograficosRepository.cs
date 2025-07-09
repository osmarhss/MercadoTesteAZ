using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.SharedValues;
using MercadoTesteAZ.Infra.Context;

namespace MercadoTesteAZ.Application.Repositories.SharedValues
{
    public class DadosGeograficosRepository : Repository<DadosGeograficos>
    {
        public DadosGeograficosRepository(AppDbContext context) : base(context)
        {
        }
    }
}
