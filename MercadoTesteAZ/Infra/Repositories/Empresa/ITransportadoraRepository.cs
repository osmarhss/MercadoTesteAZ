using MercadoTesteAZ.Domain.Entities.Empresas;

namespace MercadoTesteAZ.Infra.Repositories.Empresa
{
    public interface ITransportadoraRepository : IRepository<Transportadora>
    {
        Task<Transportadora?> ObterPorNomeAsync(string nome);
    }
}
