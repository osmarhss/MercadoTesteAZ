namespace MercadoTesteAZ.Application.ViewModels
{
    public class ContaBancariaViewModel
    {
        public string ContaId { get; set; }
        public string InstituicaoBancaria { get; set; }
        public int TipoConta { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public bool ContaPrincipal { get; set; }
        public string VendedorId { get; set; }
    }
}
