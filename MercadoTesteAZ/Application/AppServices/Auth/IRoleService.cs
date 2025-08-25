namespace MercadoTesteAZ.Application.AppServices.Auth
{
    public interface IRoleService
    {
        Task CreateRole(string roleName);
        Task AddRoleToUser(string roleName, string email);
    }
}
