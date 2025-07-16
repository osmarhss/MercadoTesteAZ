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
            await VerificarCategoriaExistentePorNomeAsync(categoria.Nome);
            await base.AdicionarAsync(categoria);
        }

        public async Task<Categoria> ObterPorNomeAsync(string nome) 
        {
            var categoria = await _categoriaRepository.ObterPorNomeAsync(nome);

            if (categoria != null)
                return categoria;

            throw new ExcecaoPersonalizada("Não há categoria com esse nome");
        }

        public async Task VerificarCategoriaExistentePorNomeAsync(string nome)
        {
            var categoriaExistente = await _categoriaRepository.ObterPorNomeAsync(nome);

            if (categoriaExistente != null)
                throw new ExcecaoPersonalizada("Já existe uma categoria com esse nome");
        }
    }
}
