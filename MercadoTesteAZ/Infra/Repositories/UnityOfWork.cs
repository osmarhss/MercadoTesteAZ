using MercadoTesteAZ.Infra.Context;
using MercadoTesteAZ.Infra.Repositories.Categorias;
using MercadoTesteAZ.Infra.Repositories.Clientes;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Infra.Repositories.Pagamentos;
using MercadoTesteAZ.Infra.Repositories.Pedidos;
using MercadoTesteAZ.Infra.Repositories.Produtos;
using Microsoft.EntityFrameworkCore.Storage;

namespace MercadoTesteAZ.Infra.Repositories
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
        private IDbContextTransaction? _transaction;
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

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction is not null)
                return;

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

    }
}
