using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Infra.Repositories;

namespace MercadoTesteAZ.Infra.Repositories.Empresa
{
    public interface IVendedorRepository : IRepository<Vendedor>
    {
        Task<Vendedor?> ObterPorCnpjAsync(string cnpj);
        Task<Vendedor?> ObterPorRazaoSocialAsync(string nome);
        Task<Vendedor?> ObterComContaBancariaAsync(string id);
    }
}
