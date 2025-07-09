using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Categorias;

namespace MercadoTesteAZ.Application.Repositories.Categorias
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        public Task<Categoria?> ObterPorNome(string nome);
    }
}
