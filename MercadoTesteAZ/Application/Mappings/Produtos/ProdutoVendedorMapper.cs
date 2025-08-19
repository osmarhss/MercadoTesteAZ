using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels.Produtos;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.Mappings.Produtos
{
    public class ProdutoVendedorMapper : IMapper<ProdutoVendedorViewModel, ProdutoDraft, Produto>
    {
        public ProdutoDraft ToDraft(ProdutoVendedorViewModel vm)
            => new ProdutoDraft()
            {
                Id = vm.ProdutoId,
                Nome = vm.Nome,
                Descricao = vm.Descricao,
                Fabricante = vm.Fabricante,
                Preco = vm.Preco,
                Estoque = vm.Estoque,
                ImagemURL = vm.ImagemURL,
                DataCadastro = vm.DataCadastro,
                UltimaAtualizacao = vm.UltimaAtualizacao,
                VendedorId = vm.VendedorId,
                CategoriaId = vm.CategoriaId,
            };

        public ProdutoVendedorViewModel ToViewModel(Produto entity)
            => new ProdutoVendedorViewModel()
            {
                ProdutoId = entity.Id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
                Fabricante = entity.Fabricante,
                Preco = entity.Preco,
                Estoque = entity.Estoque,
                QtdVendida = entity.QtdVendida,
                Ativo = entity.Ativo,
                ImagemURL = entity.ImagemURL,
                VendedorId = entity.VendedorId,
                CategoriaId = entity.CategoriaId,
            };
    }
}
