using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Domain.Entities.SharedValues
{
    public class DadosContato : IEntity
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; }
        public string UsuarioId { get; private set; }
    }
}
