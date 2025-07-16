using MercadoTesteAZ.Application.Services.Categorias;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Domain.Entities.Categorias;
using Microsoft.AspNetCore.Mvc;
using MercadoTesteAZ.Presentation.ViewModels;
using MercadoTesteAZ.Presentation.ViewModels.Mappings;

namespace MercadoTesteAZ.Presentation.Controllers
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
                var categoriasVM = categorias.ToCategoriaViewModelList();
                return Ok(categoriasVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpGet("{id}", Name = "obterCategoriaPorId")]
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
        
        [HttpGet("obterPorNome/{nome}")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorNome(string nome) 
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("O nome da categoria não pode ser completamente nula ou vazia");

            try
            {
                var categoria = await _categoriaServ.ObterPorNomeAsync(nome);
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

                return new CreatedAtRouteResult("obterCategoriaPorId", new { id = categoria.Id }, categoriaCriadaVM);
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
