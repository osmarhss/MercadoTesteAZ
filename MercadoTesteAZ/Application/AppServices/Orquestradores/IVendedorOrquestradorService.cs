using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Empresas;

namespace MercadoTesteAZ.Application.AppServices.Aggregations
{
    public interface IVendedorOrquestradorService
    {
        public Task<string> AdicionarComUsuarioAsync(VendedorViewModel entity);
    }
}
