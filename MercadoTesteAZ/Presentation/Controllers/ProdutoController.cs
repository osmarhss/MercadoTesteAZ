using MercadoTesteAZ.Application.Services.Produtos;
using MercadoTesteAZ.Domain.Entities.Produtos;
using MercadoTesteAZ.Domain.Exceptions;
using MercadoTesteAZ.Presentation.ViewModels;
using MercadoTesteAZ.Presentation.ViewModels.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoServ;
        public ProdutoController(IProdutoService produtoServ)
        {
            _produtoServ = produtoServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> ObterTodos()
        {
            try
            {
                var produtos = await _produtoServ.ObterTodosAsync();
                var produtosVM = produtos.ToProdutoViewModelList();
                return Ok(produtosVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }

        [HttpGet("{id}", Name = "obterPorProdutoId")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(string id) 
        {
            if (id is null)
                return BadRequest("O id não pode ser nulo");

            try
            {
                var produto = await _produtoServ.ObterPorIdAsync(id);
                var produtoVM = produto.ToProdutoViewModel();
                return Ok(produtoVM);
            }
            catch (ExcecaoPersonalizada ex)
            {
                return BadRequest(ex.Mensagem);
            }
        }
    }
}
