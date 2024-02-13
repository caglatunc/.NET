using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Business.Constants;
using NTierArchitecture.Business.Validator;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
namespace NTierArchitecture.Business.Services;

public sealed class AuthService(
    UserManager<AppUser> userManager,
    TokenManager tokenManager) 
{
    public async Task<string> Login(LoginDto request)
    {
        LoginDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        AppUser? appUser = await userManager.FindByNameAsync(request.UserNameOrEmail);
        if (appUser == null)
        {
            appUser = await userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (appUser == null)
            {
                throw new ArgumentException(MessageConstants.DataNotFound);
            }
        }

        bool result2
          = await userManager.CheckPasswordAsync(appUser, request.Password);
        if (!result2)
        {
            throw new ArgumentException(MessageConstants.PasswordIsWrong);
        }

        return tokenManager.CreateToken(appUser);
        
    }
  


}
