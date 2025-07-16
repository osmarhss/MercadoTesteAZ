using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Presentation.ViewModels
{
    public class ProdutoViewModel
    {
        public string ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int QtdVendida { get; set; }
        public bool Ativo { get; set; }
        public string ImagemURL { get; set; }
        public CondicaoEspecial Condicao { get; set; }
        public string VendedorId { get; set; }
        public string CategoriaId { get; set; }
        public IEnumerable<HistoricoPreco> HistoricoDePrecos { get; set; }
    }
}
