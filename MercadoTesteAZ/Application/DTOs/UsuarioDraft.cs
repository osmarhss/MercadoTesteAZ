namespace MercadoTesteAZ.Application.DTOs
{
    public class UsuarioDraft : IDraft
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
    }
}
