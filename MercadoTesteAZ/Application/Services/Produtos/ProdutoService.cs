
using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Application.Repositories.Produtos;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Exceptions;

namespace MercadoTesteAZ.Application.Services.Produtos
{
    public class ProdutoService : CrudService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IUnityOfWork uow, IProdutoRepository produtoRepository) : base(uow, produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public override async Task AdicionarAsync(Produto entity)
        {
            await VerificaProdutoDuplicadoPeloVendedorAsync(entity.Nome, entity.VendedorId);
            await base.AdicionarAsync(entity);
        }
        public async Task VerificaProdutoDuplicadoPeloVendedorAsync(string nome, string vendedorId)
        {
            var produto = await _produtoRepository.ObterProdutoPorNomeEhVendedorId(nome, vendedorId);

            if (produto != null)
                throw new ExcecaoPersonalizada($"Já existe um produto com o nome: {nome} do vendedor {vendedorId}");
        }
    }
}
