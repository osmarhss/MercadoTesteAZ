using MercadoTesteAZ.Domain.Entities.Usuários;
using MercadoTesteAZ.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace MercadoTesteAZ.Application.AppServices.Auth
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateRole(string roleName)
        {
            var roleExist = await _roleManager.FindByNameAsync(roleName);

            if (roleExist != null)
                throw new ExcecaoPersonalizada($"The role '{roleName}' already exists", 400);

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (!result.Succeeded)
                throw new ExcecaoPersonalizada($"Não foi possível adicionar a role: '{roleName}'", 400);
        }

        public async Task AddRoleToUser(string roleName, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _roleManager.FindByNameAsync(roleName);

            if (user is null || role is null)
                throw new ExcecaoPersonalizada("The role or user wasn't found.");

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded)
                throw new ExcecaoPersonalizada("The operation failed due to an internal error.", 400);
        }
    }
}
