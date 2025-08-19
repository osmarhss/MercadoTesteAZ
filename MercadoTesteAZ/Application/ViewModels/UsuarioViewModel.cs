using MercadoTesteAZ.Domain.Enums;

namespace MercadoTesteAZ.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int TipoUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
