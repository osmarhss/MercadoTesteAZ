using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.ViewModels.Produtos
{
    public class ProdutoVendedorViewModel
    {
        public string ProdutoId { get; set; } = string.Empty;
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int QtdVendida { get; set; }
        public bool Ativo { get; set; }
        public string ImagemURL { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public string VendedorId { get; set; } = string.Empty;
        public string CategoriaId { get; set; } = string.Empty;
    }
}
