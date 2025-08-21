using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Categorias;
using MercadoTesteAZ.Presentation.ViewModels.Categorias;

namespace MercadoTesteAZ.Application.AppServices.Categorias
{
    public class CategoriaAppServiceReadOnly : AppServiceReadOnly<CategoriaConsumidorViewModel, Categoria>, ICategoriaAppServiceReadOnly<CategoriaConsumidorViewModel, Categoria>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaAppServiceReadOnly(ICategoriaRepository categoriaRepository, IMapperToViewModel<CategoriaConsumidorViewModel, Categoria> mapping) : base(categoriaRepository, mapping)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaConsumidorViewModel> ObterPorNomeAsync(string nome)
        {
            var categoria = await _categoriaRepository.ObterPorNomeAsync(nome);
            if (categoria is null)
                throw new ExcecaoPersonalizada($"Categoria não encontrada com o nome: {nome}");

            return _mapping.ToViewModel(categoria);
        }
    }
}
