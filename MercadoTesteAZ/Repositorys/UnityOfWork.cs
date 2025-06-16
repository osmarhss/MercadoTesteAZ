using MercadoTesteAZ.Context;
using MercadoTesteAZ.Repositorys.Categorias;
using MercadoTesteAZ.Repositorys.Produtos;

namespace MercadoTesteAZ.Repositorys
{
    public class UnityOfWork : IUnityOfWork
    {
        private ICategoriaRepository? _categoriaRepository;
        private IProdutoRepository? _produtoRepository;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICategoriaRepository CategoriaRepository { get { return _categoriaRepository ??= new CategoriaRepository(_context); } }
        public IProdutoRepository ProdutoRepository { get { return _produtoRepository ??= new ProdutoRepository(_context); } }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
