using MercadoTesteAZ.Application.AppServices.Base;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.Mappings.Interfaces;
using MercadoTesteAZ.Domain.Entities.Usuário;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Usuarios;
using MercadoTesteAZ.Presentation.ViewModels.Usuarios;

namespace MercadoTesteAZ.Application.AppServices.Usuarios
{
    public class UsuarioAppService : AppService<UsuarioViewModel, UsuarioDraft, Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IUnityOfWork uow, IMapper<UsuarioViewModel, UsuarioDraft, Usuario> mapping) : base(usuarioRepository, uow, mapping)
        {
            _usuarioRepository = usuarioRepository;
        }

        protected override void AtualizarEntidade(UsuarioDraft draft, Usuario antiga)
        {
            antiga.Atualizar(draft.Email);
        }

        protected override Usuario CriarEntidade(UsuarioDraft draft)
        {
            return Usuario.Adicionar(draft.Email, draft.TipoUsuario);
        }

        protected override UsuarioDraft ToDraft(UsuarioViewModel vm)
        {
            return new UsuarioDraft()
            {
                Email = vm.Email,
                TipoUsuario = vm.TipoUsuario,
            };
        }
    }
}
