using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Empresas;

namespace MercadoTesteAZ.Application.AppServices.Vendedores
{
    public interface IVendedorAppService : IAppService<VendedorViewModel, VendedorDraft, Vendedor>
    {
        Task<VendedorViewModel> ObterPorRazaoSocialAsync(string razaoSocial);
        Task<VendedorViewModel> ObterPorCnpjAsync(string cnpj);
        Task<string> AdicionarContaBancariaAsync(string vendedorId, IEnumerable<ContaBancariaDraft> contasDraft);
    }
}
