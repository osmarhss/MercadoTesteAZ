using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Application.DTOs
{
    public class ContaBancariaDraft : IDraft
    {
        public string Id { get; set; }
        public string Cnpj { get; set; }
        public string InstituicaoBancaria { get; set; }
        public TipoContaBancaria TipoConta { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public bool ContaPrincipal { get; set; }
        public string ProprietarioId { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }
    }
}
