using MercadoTesteAZ.Context;
using MercadoTesteAZ.Models.SharedValues;

namespace MercadoTesteAZ.Repositorys.SharedValues
{
    public class DadosContatoRepository : Repository<DadosContato>
    {
        public DadosContatoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
