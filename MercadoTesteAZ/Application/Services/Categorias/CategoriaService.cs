using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Application.Repositories.Categorias;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Exceptions;

namespace MercadoTesteAZ.Application.Services.Categorias
{
    public class CategoriaService : CrudService<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(IUnityOfWork uow, ICategoriaRepository categoriaRepository) : base(uow, categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public override async Task AdicionarAsync(Categoria categoria)
        {
            await VerificarCategoriaExistentePorNome(categoria.Nome);
            await base.AdicionarAsync(categoria);
        }

        public async Task VerificarCategoriaExistentePorNome(string nome)
        {
            var categoriaExistente = await _categoriaRepository.ObterPorNome(nome);

            if (categoriaExistente != null)
                throw new ExcecaoPersonalizada("Já existe uma categoria com esse nome");
        }
    }
}
