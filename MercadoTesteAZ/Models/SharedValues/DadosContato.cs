namespace MercadoTesteAZ.Models.SharedValues
{
    public class DadosContato
    {
        public DadosContato(string email, string usuarioId)
        {
            Email = email;
            UsuarioId = usuarioId;
        }

        public string Email { get; private set; }
        public string? Telefone { get; private set; }
        public string UsuarioId { get; private set; }
    }
}
