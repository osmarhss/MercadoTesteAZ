using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Domain.Entities.Empresas
{
    public class Transportadora : IEntity
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public bool Ativo { get; private set; }
    }
}
