namespace MercadoTesteAZ.Application.DTOs
{
    public class ProdutoDraft : IDraft
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public int Estoque { get; set; }
        public string ImagemURL { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public string VendedorId { get; set; }
        public string CategoriaId { get; set; }
    }
}
