using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Application.Mappings.ContasBancárias
{
    public class ContaBancariaMapper : IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria>
    {
        public ContaBancariaDraft ToDraft(ContaBancariaViewModel vm)
            => new ContaBancariaDraft() 
            {
                InstituicaoBancaria = vm.InstituicaoBancaria,
                TipoConta = vm.TipoConta,
                Agencia = vm.Agencia,
                NumConta = vm.NumConta,
                ContaPrincipal = vm.ContaPrincipal,
                VendedorId = vm.VendedorId,
            };

        public ContaBancaria ToEntity(ContaBancariaViewModel vm)
            => ContaBancaria.Criar(vm.ContaId, vm.InstituicaoBancaria, vm.TipoConta, vm.Agencia, vm.NumConta, vm.ContaPrincipal, vm.VendedorId);

        public ContaBancariaViewModel ToViewModel(ContaBancaria entity)
            => new ContaBancariaViewModel()
            { 
                ContaId = entity.Id,
                InstituicaoBancaria = entity.InstituicaoBancaria,
                TipoConta = (int)entity.TipoConta,
                Agencia = entity.Agencia,
                NumConta = entity.NumConta,
                ContaPrincipal = entity.ContaPrincipal,
                VendedorId = entity.VendedorId,
            };
    }
}
