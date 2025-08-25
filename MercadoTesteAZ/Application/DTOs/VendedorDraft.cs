using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Application.DTOs
{
    public class VendedorDraft : IDraft
    {
        public string Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string UsuarioId { get; set; }
        public IEnumerable<ContaBancariaDraft>? ContasBancariasDraft { get; set; }
    }
}
