using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Presentation.ViewModels.ContasBancarias;

namespace MercadoTesteAZ.Application.AppServices.MeiosDePagamento
{
    public interface IContaBancariaAppService : IAppService<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria>
    {
        Task<string> AdicionarSemCommitAsync(ContaBancariaViewModel vm);
    }

}
