using MercadoTesteAZ.Application.AppServices.Aggregations;
using MercadoTesteAZ.Application.AppServices.Empresas.Vendedores;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Presentation.ViewModels.Vendedores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private readonly IVendedorAppService _vendedorAppServ;
        private readonly IVendedorOrquestradorService _vendedorOrquestradorServ;
        public VendedorController(IVendedorAppService vendedorAppServ, IVendedorOrquestradorService vendedorOrquestradorService)
        {
            _vendedorAppServ = vendedorAppServ;
            _vendedorOrquestradorServ = vendedorOrquestradorService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendedorViewModel>>> ObterTodos()
        {
            var vendedores = await _vendedorAppServ.ObterTodosAsync();
            return Ok(vendedores);
        }

        [HttpGet("{id}", Name = "ObterPorVendedorId")]
        public async Task<ActionResult<VendedorViewModel>> ObterPorId(string id)
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                var vendedor = await _vendedorAppServ.ObterPorIdAsync(id);
                return Ok(vendedor);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPost]
        public async Task<ActionResult<VendedorViewModel>> Adicionar([FromBody] VendedorViewModel vm)
        {
            if (vm == null)
                return BadRequest("A entidade vm não pode ser completamente nula");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var vendedorId = await _vendedorAppServ.AdicionarAsync(vm);

                return new CreatedAtRouteResult("ObterPorVendedorId", new { id = vendedorId });
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Vendor")]
        public async Task<ActionResult<VendedorViewModel>> Atualizar([FromBody] VendedorViewModel vendedorVM, string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (vendedorVM.VendedorId != id)
                return BadRequest("Id's não conferem");

            try
            {
                var vmAtt = await _vendedorAppServ.AtualizarAsync(vendedorVM);
                return Ok(vmAtt);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Deletar(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                await _vendedorAppServ.DeletarAsync(id);

                return Ok($"O vendedor com o id: {id} foi apagado com sucesso");
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }
    }
}
