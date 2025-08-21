using MercadoTesteAZ.Application.AppServices.Empresas.Vendedores;
using MercadoTesteAZ.Application.AppServices.MeiosDePagamento;
using MercadoTesteAZ.Application.AppServices.Usuarios;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Infra.Repositories;
using MercadoTesteAZ.Presentation.ViewModels.Vendedores;

namespace MercadoTesteAZ.Application.AppServices.Aggregations
{
    public class VendedorOrquestradorService : IVendedorOrquestradorService
    {
        private readonly IUsuarioAppService _usuarioAppServ;
        private readonly IVendedorAppService _vendedorAppServ;
        private readonly IContaBancariaAppService _contaBancariaAppService;
        private readonly IUnityOfWork _uow;

        public VendedorOrquestradorService(IUsuarioAppService usuarioAppServ, IVendedorAppService vendedorAppServ, IContaBancariaAppService contaBancariaAppService, IUnityOfWork uow)
        {
            _vendedorAppServ = vendedorAppServ;
            _usuarioAppServ = usuarioAppServ;
            _contaBancariaAppService = contaBancariaAppService;
            _uow = uow;
        }

        public async Task<string> AdicionarComUsuarioAsync(VendedorViewModel vm)
        {
            if (vm.UsuarioViewModel is null)
                throw new ExcecaoPersonalizada("Usuario não pode ser nulo");

            await _uow.BeginTransactionAsync();

            try
            {
                var usuarioId = await _usuarioAppServ.AdicionarAsync(vm.UsuarioViewModel);
                vm.UsuarioId = usuarioId;

                var vendedorId = await _vendedorAppServ.AdicionarAsync(vm);
                await _uow.CommitAsync();
                await _uow.CommitTransactionAsync();

                if(vm.ContaBancaria !=  null && vm.ContaBancaria.Any())
                {
                    foreach (var conta in vm.ContaBancaria)
                    {
                        await _contaBancariaAppService.AdicionarSemCommitAsync(conta);
                    }
                }

                return vendedorId;
            }
            catch (Exception e)
            {
                await _uow.RollbackTransactionAsync();
                throw new ExcecaoPersonalizada($"{e.Message}");
            }
        }
    }
}
