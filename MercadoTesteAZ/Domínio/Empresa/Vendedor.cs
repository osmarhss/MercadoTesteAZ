using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Models.MeiosDePagamento;
using MercadoTesteAZ.Models.Produtos;

namespace MercadoTesteAZ.Models.Empresa
{
    public class Vendedor : IEntity
    {
        public string Id { get; private set; }
        public string CNPJ { get; private set; }
        public string UsuarioId { get; private set; }
        public ContaBancaria? ContaBancaria { get; private set; }
        public ICollection<Produto>? MeusProdutos { get; private set; }        
    }
}
