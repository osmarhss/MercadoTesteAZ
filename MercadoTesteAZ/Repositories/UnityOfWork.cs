using MercadoTesteAZ.Context;
using MercadoTesteAZ.Repositorys.Categorias;
using MercadoTesteAZ.Repositorys.Clientes;
using MercadoTesteAZ.Repositorys.Empresa;
using MercadoTesteAZ.Repositorys.Pagamentos;
using MercadoTesteAZ.Repositorys.Pedidos;
using MercadoTesteAZ.Repositorys.Produtos;
using MercadoTesteAZ.Repositorys.Usuarios;

namespace MercadoTesteAZ.Repositorys
{
    public class UnityOfWork : IUnityOfWork
    {
        private ICategoriaRepository? _categoriaRepository;
        private IProdutoRepository? _produtoRepository;
        private IClienteRepository? _clienteRepository;
        private IVendedorRepository? _vendedorRepository;
        private ICartaoDeCreditoRepository? _cartaoDeCreditoRepository;
        private IContaBancariaRepository? _contaBancariaRepository;
        private IPedidoRepository? _pedidoRepository;
        private IUsuarioRepository? _usuarioRepository;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICategoriaRepository CategoriaRepository { get { return _categoriaRepository ??= new CategoriaRepository(_context); } }
        public IProdutoRepository ProdutoRepository { get { return _produtoRepository ??= new ProdutoRepository(_context); } }
        public IClienteRepository ClienteRepository { get { return _clienteRepository ??= new ClienteRepository(_context); } }
        public IVendedorRepository VendedorRepository { get { return _vendedorRepository ??= new VendedorRepository(_context); } }
        public ICartaoDeCreditoRepository CartaoDeCreditoRepository { get { return _cartaoDeCreditoRepository ??= new CartaoDeCreditoRepository(_context); } }
        public IContaBancariaRepository ContaBancariaRepository { get { return _contaBancariaRepository ??= new ContaBancariaRepository(_context); } }
        public IPedidoRepository PedidoRepository { get { return _pedidoRepository ??= new PedidoRepository(_context); } }
        public IUsuarioRepository UsuarioRepository { get { return _usuarioRepository ??= new UsuarioRepository(_context); } }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
