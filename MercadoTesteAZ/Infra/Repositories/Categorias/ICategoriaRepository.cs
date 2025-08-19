using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Categorias
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        public Task<Categoria?> ObterPorNomeAsync(string nome);
    }
}
