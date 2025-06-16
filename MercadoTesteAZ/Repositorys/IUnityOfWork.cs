using MercadoTesteAZ.Repositorys.Categorias;
using MercadoTesteAZ.Repositorys.Produtos;

namespace MercadoTesteAZ.Repositorys
{
    public interface IUnityOfWork
    {
        public ICategoriaRepository CategoriaRepository { get; }
        public IProdutoRepository ProdutoRepository { get; }
        public Task Commit();
    }
}
