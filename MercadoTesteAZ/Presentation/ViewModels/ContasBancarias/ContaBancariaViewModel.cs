using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Presentation.ViewModels.ContasBancarias
{
    public class ContaBancariaViewModel
    {
        public string Id { get; set; }
        public string Cnpj { get; set; }
        public string InstituicaoBancaria { get; set; }
        public int TipoConta { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public bool ContaPrincipal { get; set; }
        public string ProprietarioId { get; set; }
        public int TipoEmpresa { get; set; }
    }
}
