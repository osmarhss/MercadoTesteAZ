using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Enums;
using MercadoTesteAZ.Presentation.ViewModels.ContasBancarias;

namespace MercadoTesteAZ.Application.Mappings.ContasBancárias
{
    public class ContaBancariaMapper : IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria>
    {
        public ContaBancariaDraft ToDraft(ContaBancariaViewModel vm)
            => new ContaBancariaDraft() 
            {
                InstituicaoBancaria = vm.InstituicaoBancaria,
                TipoConta = (TipoContaBancaria)vm.TipoConta,
                Agencia = vm.Agencia,
                NumConta = vm.NumConta,
                ContaPrincipal = vm.ContaPrincipal,
                ProprietarioId = vm.ProprietarioId,
                TipoEmpresa = (TipoEmpresa)vm.TipoEmpresa
            };

        public ContaBancariaViewModel ToViewModel(ContaBancaria entity)
            => new ContaBancariaViewModel()
            { 
                Id = entity.Id,
                InstituicaoBancaria = entity.InstituicaoBancaria,
                TipoConta = (int)entity.TipoConta,
                Agencia = entity.Agencia,
                NumConta = entity.NumConta,
                ContaPrincipal = entity.ContaPrincipal,
                ProprietarioId = entity.ProprietarioId,
                TipoEmpresa = (int)entity.TipoEmpresa
            };
    }
}
