using MercadoTesteAZ.Application.AppServices.Produtos;
using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Application.ViewModels.Produtos;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService<ProdutoVendedorViewModel, ProdutoDraft, Produto> _produtoAppServ;
        public ProdutoController(IProdutoAppService<ProdutoVendedorViewModel, ProdutoDraft, Produto> produtoAppServ)
        {
            _produtoAppServ = produtoAppServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoVendedorViewModel>>> ObterTodos()
        {
            try
            {
                var produtosVM = await _produtoAppServ.ObterTodosAsync();
                return Ok(produtosVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpGet("{id}", Name = "obterPorProdutoId")]
        public async Task<ActionResult<ProdutoVendedorViewModel>> ObterPorId(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                var produtoVM = await _produtoAppServ.ObterPorIdAsync(id);
                return Ok(produtoVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpGet("obterPorNome/{nome}")]
        public async Task<ActionResult<ProdutoVendedorViewModel>> ObterPorNome(string nome) 
        {
            if (nome is null)
                return BadRequest("O nome não pode ser nulo");

            try
            {
                var produtoVM = await _produtoAppServ.ObterPorNomeAsync(nome);
                return Ok(produtoVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoVendedorViewModel>> Adicionar([FromBody] ProdutoVendedorViewModel vm) 
        {
            if (vm is null)
                return BadRequest("A categoria não pode ser completamente nula");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var produtoAdd = await _produtoAppServ.AdicionarAsync(vm);
                return new CreatedAtRouteResult("obterPorProdutoId", new { id = produtoAdd }, produtoAdd);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoVendedorViewModel>> Atualizar(string id, ProdutoVendedorViewModel vm) 
        {
            if (id != vm.ProdutoId)
                return BadRequest("O id informado e do produto diferem");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var produtoAttVm = await _produtoAppServ.AtualizarAsync(vm);
                return Ok(produtoAttVm);
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
                return BadRequest("O id não pode ser completamente nulo");

            try
            {
                await _produtoAppServ.DeletarAsync(id);

                return Ok($"Produto com id: {id} foi excluído com sucesso!");
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }
    }
}
