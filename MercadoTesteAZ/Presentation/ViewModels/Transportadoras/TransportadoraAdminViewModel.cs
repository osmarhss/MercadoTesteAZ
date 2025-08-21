using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;

namespace MercadoTesteAZ.Presentation.ViewModels.Transportadoras
{
    public class TransportadoraAdminViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
        public int NumDeEntregas { get; set; }
        public double NotaAvaliacao { get; set; }
        public ContaBancaria? ContaBancaria { get; set; }
    }
}
