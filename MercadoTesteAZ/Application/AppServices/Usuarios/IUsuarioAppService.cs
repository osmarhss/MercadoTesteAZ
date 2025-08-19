using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Usuário;

namespace MercadoTesteAZ.Application.AppServices.Usuarios
{
    public interface IUsuarioAppService : IAppService<UsuarioViewModel, UsuarioDraft, Usuario>
    {

    }
}
