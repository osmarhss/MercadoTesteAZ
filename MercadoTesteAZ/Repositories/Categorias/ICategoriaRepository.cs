using MercadoTesteAZ.Models.Categorias;

namespace MercadoTesteAZ.Repositorys.Categorias
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        public Task<Categoria?> ObterPorNome(string nome);
    }
}
