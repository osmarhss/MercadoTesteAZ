using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Presentation.ViewModels.Vendedores;

namespace MercadoTesteAZ.Application.AppServices.Empresas.Vendedores
{
    public interface IVendedorAppService : IAppService<VendedorViewModel, VendedorDraft, Vendedor>
    {
        Task<VendedorViewModel> ObterPorRazaoSocialAsync(string razaoSocial);
        Task<VendedorViewModel> ObterPorCnpjAsync(string cnpj);
    }
}
