using MercadoTesteAZ.Infra.Repositories.Categorias;
using MercadoTesteAZ.Infra.Repositories.Clientes;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Infra.Repositories.Pagamentos;
using MercadoTesteAZ.Infra.Repositories.Pedidos;
using MercadoTesteAZ.Infra.Repositories.Produtos;
using MercadoTesteAZ.Infra.Repositories.Usuarios;

namespace MercadoTesteAZ.Infra.Repositories
{
    public interface IUnityOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IVendedorRepository VendedorRepository { get; }
        ICartaoDeCreditoRepository CartaoDeCreditoRepository { get; }
        IContaBancariaRepository ContaBancariaRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        Task CommitAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
