namespace MercadoTesteAZ.Application.DTOs
{
    public class ContaBancariaDraft
    {
        public string InstituicaoBancaria { get; set; }
        public int TipoConta { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public bool ContaPrincipal { get; set; }
        public string VendedorId { get; set; }
    }
}
