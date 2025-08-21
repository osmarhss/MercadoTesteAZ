using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Presentation.ViewModels.Usuarios;

namespace MercadoTesteAZ.Application.AppServices.Usuarios
{
    public interface IUsuarioAppService : IAppService<UsuarioViewModel, UsuarioDraft, Usuario>
    {

    }
}
