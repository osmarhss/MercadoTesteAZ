using MercadoTesteAZ.Exceptions;
using MercadoTesteAZ.Models.Categorias;
using MercadoTesteAZ.Repositorys;
using MercadoTesteAZ.Repositorys.Categorias;
using MercadoTesteAZ.Repositorys.Produtos;

namespace MercadoTesteAZ.Services.Categorias
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
