using MercadoTesteAZ.Models.Categorias;
using MercadoTesteAZ.Repositorys;
using MercadoTesteAZ.Repositorys.Categorias;
using MercadoTesteAZ.Repositorys.Produtos;

namespace MercadoTesteAZ.Services.Categorias
{
    public class CategoriaService : CrudService<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(UnityOfWork uow, ICategoriaRepository repository) : base(uow, repository)
        {
            _categoriaRepository = repository;
        }

        public override async Task AdicionarAsync(Categoria entity)
        {
            await VerificarCategoriaExistente(entity.Nome);
            await base.AdicionarAsync(entity);
        }

        public async Task VerificarCategoriaExistente(string nome)
        {
            var categoriaExistente = await _categoriaRepository.ObterPorNome(nome);

            if (categoriaExistente != null)
                throw new Exception("Já existe uma categoria com esse nome");
        }
    }
}
