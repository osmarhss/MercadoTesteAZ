using MercadoTesteAZ.Application.AppServices.Auth;
using MercadoTesteAZ.Presentation.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoTesteAZ.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create([FromQuery] string roleName) 
        {
            if (roleName is null)
            {
                return BadRequest("The role name can't be null.");
            }

            await _roleService.CreateRole(roleName);

            return Ok($"The role '{roleName}' was created successfully.");
        }

        [HttpPost("addToUser")]
        public async Task<IActionResult> AddToUser(RoleUserModel model) 
        {
            if (model is null)
                return BadRequest("The model can't be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _roleService.AddRoleToUser(model.RoleName, model.Email);

            return Ok($"The role has been successfully assigned to the user: {model.Email}.");
        }
    }
}
