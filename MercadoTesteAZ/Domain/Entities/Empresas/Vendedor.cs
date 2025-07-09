using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Entities.MeiosDePagamento;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Domain.Entities.Empresas
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
