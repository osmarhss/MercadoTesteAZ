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
        public ICategoriaRepository CategoriaRepository { get; }
        public IProdutoRepository ProdutoRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IVendedorRepository VendedorRepository { get; }
        public ICartaoDeCreditoRepository CartaoDeCreditoRepository { get; }
        public IContaBancariaRepository ContaBancariaRepository { get; }
        public IPedidoRepository PedidoRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public Task CommitAsync();
    }
}
