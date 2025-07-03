using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.SharedValues;

namespace MercadoTesteAZ.Repositorys.SharedValues
{
    public class DadosGeograficosRepository : Repository<DadosGeograficos>
    {
        public DadosGeograficosRepository(AppDbContext context) : base(context)
        {
        }
    }
}
