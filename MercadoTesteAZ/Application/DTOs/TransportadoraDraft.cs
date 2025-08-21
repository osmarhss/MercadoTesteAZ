namespace MercadoTesteAZ.Application.DTOs
{
    public class TransportadoraDraft : IDraft
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
        public ContaBancariaDraft ContaBancaria { get; set; }
        
    }
}
