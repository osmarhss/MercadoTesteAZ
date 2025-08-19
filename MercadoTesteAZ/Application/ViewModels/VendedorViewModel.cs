using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Application.ViewModels
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
