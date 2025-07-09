using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Domain.Entities.Interfaces;
using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Domain.Entities.MeiosDePagamento
{
    public class ContaBancaria : IEntity
    {
        public string Nome => "Conta Bancária";
        public string Id { get; private set; }
        public string InstituicaoBancaria { get; private set; }
        public TipoContaBancaria TipoConta { get; private set; }
        public string Agencia { get; private set; }
        public string NumConta { get; private set; }
        public string VendedorId { get; private set; }
        public Vendedor? Vendedor { get; private set; }

    }
}
