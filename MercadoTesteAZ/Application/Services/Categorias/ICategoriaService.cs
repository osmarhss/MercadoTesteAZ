using MercadoTesteAZ.Application.Services;
using MercadoTesteAZ.Domain.Entities.Categorias;
using System.Linq.Expressions;

namespace MercadoTesteAZ.Application.Services.Categorias
{
    public interface ICategoriaService : ICrudService<Categoria>
    {
        public Task VerificarCategoriaExistentePorNome(string nome);
    }
}
