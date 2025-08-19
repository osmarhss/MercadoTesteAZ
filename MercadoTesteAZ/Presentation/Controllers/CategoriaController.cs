using MercadoTesteAZ.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using MercadoTesteAZ.Application.AppServices.Categorias;
using MercadoTesteAZ.Application.ViewModels.Categorias;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Categorias;

namespace MercadoTesteAZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppService<CategoriaAdminViewModel, CategoriaDraft, Categoria> _categoriaAppServ;

        public CategoriaController(ICategoriaAppService<CategoriaAdminViewModel, CategoriaDraft, Categoria> categoriaAppServ)
        {
            _categoriaAppServ = categoriaAppServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaAdminViewModel>>> ObterCategorias()
        {
            try
            {
                var categorias = await _categoriaAppServ.ObterTodosAsync();
                return Ok(categorias);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpGet("{id}", Name = "obterCategoriaPorId")]
        public async Task<ActionResult<CategoriaAdminViewModel>> ObterPorId(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                var categoriaVM = await _categoriaAppServ.ObterPorIdAsync(id);
                return Ok(categoriaVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }
        
        [HttpGet("obterPorNome/{nome}")]
        public async Task<ActionResult<CategoriaAdminViewModel>> ObterPorNome(string nome) 
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("O nome da categoria não pode ser completamente nula ou vazia");

            try
            {
                var categoriaVM = await _categoriaAppServ.ObterPorNomeAsync(nome);
                return Ok(categoriaVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaAdminViewModel>> Adicionar([FromBody] CategoriaAdminViewModel vm) 
        {
            if (vm is null)
                return BadRequest("Categoria não pode ser nula");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categoriaAdd = await _categoriaAppServ.AdicionarAsync(vm);
                return new CreatedAtRouteResult("obterCategoriaPorId", new { id = categoriaAdd }, categoriaAdd);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaAdminViewModel>> Atualizar(string id, [FromBody] CategoriaAdminViewModel vm) 
        {
            if (id != vm.CategoriaId)
                return BadRequest("Não foi possível identificar a categoria a ser atualizado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categoriaAtt = await _categoriaAppServ.AtualizarAsync(vm);
                return Ok(categoriaAtt);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaAdminViewModel>> Deletar(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                await _categoriaAppServ.DeletarAsync(id);

                return Ok("Categoria excluída com sucesso!");
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
