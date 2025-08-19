using MercadoTesteAZ.Application.AppServices.Usuarios;
using MercadoTesteAZ.Application.AppServices.Vendedores;
using MercadoTesteAZ.Application.ViewModels;
using MercadoTesteAZ.Domain.Entities.Empresas;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Infra.Repositories.Empresa;
using MercadoTesteAZ.Infra.Repositories.Usuarios;

namespace MercadoTesteAZ.Application.AppServices.Aggregations
{
    public class VendedorOrquestradorService : IVendedorOrquestradorService
    {
        private readonly IUsuarioAppService _usuarioAppServ;
        private readonly IVendedorAppService _vendedorAppServ;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnityOfWork _uow;

        public VendedorOrquestradorService(IUsuarioAppService usuarioAppServ, IVendedorAppService vendedorAppServ, IVendedorRepository vendedorRepository, IUsuarioRepository usuarioRepository, IUnityOfWork uow)
        {
            _vendedorAppServ = vendedorAppServ;
            _vendedorRepository = vendedorRepository;
            _usuarioAppServ = usuarioAppServ;
            _usuarioRepository = usuarioRepository;
            _uow = uow;
        }

        public Task<string> AdicionarComUsuarioAsync(VendedorViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
