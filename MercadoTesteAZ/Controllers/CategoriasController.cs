using MercadoTesteAZ.Exceptions;
using MercadoTesteAZ.Models.Categorias;
using MercadoTesteAZ.Services.Categorias;
using MercadoTesteAZ.ViewModels;
using MercadoTesteAZ.ViewModels.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaServ;

        public CategoriasController(ICategoriaService categoriaServ)
        {
            _categoriaServ = categoriaServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaViewModel>>> ObterCategorias()
        {
            try
            {
                var categorias = await _categoriaServ.ObterTodosAsync();
                return Ok(categorias);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpGet("{id}", Name = "ObterPorId")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                var categoria = await _categoriaServ.ObterPorIdAsync(id);
                var categoriaVM = categoria.ToCategoriaViewModel();

                return Ok(categoriaVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaVM) 
        {
            if (categoriaVM is null)
                return BadRequest("Categoria não pode ser nula");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categoria = categoriaVM.ToCategoria();
                await _categoriaServ.AdicionarAsync(categoria);

                var categoriaCriadaVM = categoria.ToCategoriaViewModel();

                return new CreatedAtRouteResult("ObterPorId", new { id = categoria.Id }, categoriaCriadaVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(string id, CategoriaViewModel categoriaViewModel) 
        {
            if (id != categoriaViewModel.CategoriaId)
                return BadRequest("Não foi possível identificar a categoria a ser atualizado");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categoria = categoriaViewModel.ToCategoria();
                await _categoriaServ.AtualizarAsync(categoria);
                var categoriaAtt = categoria.ToCategoriaViewModel();

                return Ok(categoriaAtt);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaViewModel>> Deletar(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                await _categoriaServ.DeletarAsync(id);

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
