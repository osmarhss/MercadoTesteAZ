using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Presentation.ViewModels.Usuarios;

namespace MercadoTesteAZ.Application.Mappings.Usuarios
{
    public class UsuarioMapper : IMapper<UsuarioViewModel, UsuarioDraft, Usuario>
    {
        public UsuarioDraft ToDraft(UsuarioViewModel vm)
        {
            return new UsuarioDraft()
            {
                Id = vm.Id,
                Email = vm.Email,
                TipoUsuario = vm.TipoUsuario,
            };
        }

        public UsuarioViewModel ToViewModel(Usuario entity)
        {
            return new UsuarioViewModel() 
            {
                Id = entity.Id,
                Email = entity.Email,
                TipoUsuario = (int)entity.TipoUsuario,
                DataCadastro = entity.DataCadastro
            };
        }
    }
}
