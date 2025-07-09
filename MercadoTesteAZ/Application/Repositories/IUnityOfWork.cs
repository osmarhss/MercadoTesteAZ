using MercadoTesteAZ.Application.Repositories.Categorias;
using MercadoTesteAZ.Application.Repositories.Clientes;
using MercadoTesteAZ.Application.Repositories.Empresa;
using MercadoTesteAZ.Application.Repositories.Pagamentos;
using MercadoTesteAZ.Application.Repositories.Pedidos;
using MercadoTesteAZ.Application.Repositories.Produtos;
using MercadoTesteAZ.Application.Repositories.Usuarios;

namespace MercadoTesteAZ.Application.Repositories
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
