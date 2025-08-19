using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Application.Mappings.Vendedores
{
    public class VendedorMapping : IMapper<VendedorViewModel, VendedorDraft, Vendedor>
    {
        private readonly IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria> _contasMapping;
        public VendedorMapping(IMapper<ContaBancariaViewModel, ContaBancariaDraft, ContaBancaria> contasMapping) 
        {
            _contasMapping = contasMapping;
        }
        public VendedorDraft ToDraft(VendedorViewModel vm)
            => new VendedorDraft() 
            {
                RazaoSocial = vm.RazaoSocial,
                NomeFantasia = vm.NomeFantasia,
                CNPJ = vm.CNPJ,
                UsuarioId = vm.UsuarioId,
                ContasBancariasDraft = vm.ContaBancaria?.Select(c => _contasMapping.ToDraft(c))
            };

        public VendedorViewModel ToViewModel(Vendedor entity)
            => new VendedorViewModel()
            { 
                VendedorId = entity.Id,
                RazaoSocial = entity.RazaoSocial,
                NomeFantasia = entity.NomeFantasia,
                CNPJ = entity.CNPJ,
                UsuarioId = entity.UsuarioId,
                NotaAvaliacao = entity.NotaAvaliacao,
                ContaBancaria = entity.ContasBancarias.Select(c => _contasMapping.ToViewModel(c))

            };
    }
}
