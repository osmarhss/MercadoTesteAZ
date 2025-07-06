using MercadoTesteAZ.Models.Categorias;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Services.Categorias
{
    public interface ICategoriaService : ICrudService<Categoria>
    {
        public Task VerificarCategoriaExistentePorNome(string nome);
    }
}
