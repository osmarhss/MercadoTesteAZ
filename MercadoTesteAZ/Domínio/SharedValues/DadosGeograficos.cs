using MercadoTesteAZ.Domínio.Interfaces;
using MercadoTesteAZ.Models.Clientes;

namespace MercadoTesteAZ.Models.SharedValues
{
    public class DadosGeograficos : IEntity
    {
        public string Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }

    }
}
