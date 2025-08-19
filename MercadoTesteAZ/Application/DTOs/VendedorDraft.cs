using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Usuário;

namespace MercadoTesteAZ.Application.DTOs
{
    public class VendedorDraft : IDraft
    {
        public string Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public IEnumerable<ContaBancariaDraft>? ContasBancariasDraft { get; set; }
    }
}
