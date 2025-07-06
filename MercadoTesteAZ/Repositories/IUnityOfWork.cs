using MercadoTesteAZ.Repositorys.Categorias;
using MercadoTesteAZ.Repositorys.Clientes;
using MercadoTesteAZ.Repositorys.Empresa;
using MercadoTesteAZ.Repositorys.Pagamentos;
using MercadoTesteAZ.Repositorys.Pedidos;
using MercadoTesteAZ.Repositorys.Produtos;
using MercadoTesteAZ.Repositorys.Usuarios;

namespace MercadoTesteAZ.Repositorys
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
