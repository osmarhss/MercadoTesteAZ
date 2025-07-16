using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.Services.Produtos
{
    public interface IProdutoService : ICrudService<Produto>
    {
        public Task VerificaProdutoDuplicadoPeloVendedorAsync(string nome, string idVendedor); 
    }
}
