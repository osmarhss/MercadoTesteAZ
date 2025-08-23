using MercadoTesteAZ.Application.DTOs;
using MercadoTesteAZ.Presentation.ViewModels.Auth;
using System.IdentityModel.Tokens.Jwt;

namespace MercadoTesteAZ.Presentation.ViewModels.VMExtensions
{
    public static class AuthModelExtensions
    {
        public static AuthTokenResViewModel ToViewModel(this AuthResponseDto dto) 
        {
            return new AuthTokenResViewModel 
            {
                Token = dto.Token,
                RefreshToken = dto.RefreshToken,
                Expiration = dto.Expiration,
            };
        }

        public static LoginDto ToDto(this LoginModel vm)
        {
            return new LoginDto
            { 
                UserInput = vm.UserInput,
                Password = vm.Password
            };
        }

        public static RegisterDto ToDto(this RegisterModel vm) 
        {
            return new RegisterDto 
            {
                Username = vm.Username,
                Email = vm.Email,
                Password = vm.Password
            };
        }

        public static TokenModelDto ToDto(this TokenModel vm) 
        {
            return new TokenModelDto 
            {
                AccessToken = vm.AccessToken,
                RefreshToken = vm.RefreshToken
            };
        }
    }
}
