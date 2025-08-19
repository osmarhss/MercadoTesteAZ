using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.ViewModels.Produtos;
using MercadoTesteAZ.Domain.Entities.Produtos;
using System.Security.Cryptography.X509Certificates;

namespace MercadoTesteAZ.Application.AppServices.Produtos
{
    public interface IProdutoAppService<TViewModel, TDraft, TEntity> : IAppService<TViewModel, TDraft, TEntity>, IProdutoAppServiceReadOnly<TViewModel, TEntity> 
    {
    }

    public interface IProdutoAppServiceReadOnly<TViewModel, TEntity> : IAppServiceReadOnly<TViewModel, TEntity> 
    {
        Task<IEnumerable<TViewModel>> ObterPorNomeAsync(string nome);
    }


    //public interface IProdutoAppService : IAppService<ProdutoVendedorViewModel, ProdutoDraft, Produto>
    //{
    //    public Task<IEnumerable<ProdutoVendedorViewModel>> ObterPorNomeAsync(string nome);
    //}
}
