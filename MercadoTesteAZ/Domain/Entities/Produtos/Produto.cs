using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using System.Collections.ObjectModel;

namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class Produto : IEntity
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Fabricante { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public int QtdVendida { get; private set; }
        public bool Ativo { get; private set; }
        public string ImagemURL { get; private set; }
        public DateTime? DataCadastro { get; private set; }
        public DateTime? UltimaAtualizacao { get; private set; }
        public CondicaoEspecial Condicao { get; private set; }
        public string VendedorId { get; private set; }
        public Vendedor? Vendedor { get; private set; }
        public string CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public List<HistoricoPreco> HistoricoDePrecos { get; private set; } = new List<HistoricoPreco>();

        public static Produto Criar(string? id, string nome, string descricao, string fabricante, decimal preco, int estoque, bool ativo,
            string imagemURL, CondicaoEspecial condicao, string vendedorId, string categoriaId, IEnumerable<HistoricoPreco> historicoPreco) 
        {
            return new Produto()
            {
                Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString("D") : id,
                Nome = nome,
                Descricao = descricao,
                Fabricante = fabricante,
                Preco = preco,
                Estoque = estoque,
                Ativo = ativo,
                ImagemURL = imagemURL,
                Condicao = condicao,
                VendedorId = vendedorId,
                CategoriaId = categoriaId,
                HistoricoDePrecos = historicoPreco.ToList()
            };
        }
    }
}
