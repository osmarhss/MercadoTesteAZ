using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Domain.Entities.Usuários;
using MercadoTesteAZ.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MercadoTesteAZ.Application.AppServices.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto?> RealizarLogin(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserInput) 
                ?? await _userManager.FindByNameAsync(dto.UserInput);

            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return null;

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = _tokenService.GenerateAccessToken(authClaims, _configuration);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
                        out int refreshTokenValidityInMinutes);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

            await _userManager.UpdateAsync(user);

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }

        public async Task<string> RealizarCadastro(RegisterDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
                throw new ExcecaoPersonalizada("O endereço de e-mail informado já foi utilizado");

            if (await _userManager.FindByNameAsync(dto.Username) != null)
                throw new ExcecaoPersonalizada("Nome de usuário informado já foi utilizado");

            var user = new ApplicationUser 
            {
                UserName = dto.Username,
                Email = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new ExcecaoPersonalizada("Ocorreu um erro ao cadastrar");

            return "Cadastro realizado com sucesso";
        }

        public async Task<AuthResponseDto> RenovarSessao(TokenModelDto dto)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(dto.AccessToken, _configuration);

            if (principal is null)
                throw new ExcecaoPersonalizada("Token inválido");

            var username = principal.Identity!.Name; 
            var user = await _userManager.FindByNameAsync(username!);

            if (user is null || user.RefreshToken != dto.RefreshToken
                || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new ExcecaoPersonalizada("AccessToken/RefreshToken inválido");

            var newToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _configuration);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(newToken),
                RefreshToken = newRefreshToken,
                Expiration = newToken.ValidTo
            };
        }

        public async Task RevogarRefreshToken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user is null)
                throw new ExcecaoPersonalizada($"Usuário não encontrado pelo nome: {username}");

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }
    }
}
