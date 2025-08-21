using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Presentation.ViewModels.ContasBancarias;
using MercadoTesteAZ.Presentation.ViewModels.Usuarios;

namespace MercadoTesteAZ.Presentation.ViewModels.Vendedores
{
    public class VendedorViewModel
    {
        public string VendedorId { get; set; } = string.Empty;
        public string RazaoSocial {  get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string UsuarioId { get; set; } = string.Empty;
        public int QtdVendida { get; set; }
        public double? NotaAvaliacao { get; set; }
        public IEnumerable<ContaBancariaViewModel>? ContaBancaria { get; set; }
        public UsuarioViewModel? UsuarioViewModel { get; set; }
    }
}
