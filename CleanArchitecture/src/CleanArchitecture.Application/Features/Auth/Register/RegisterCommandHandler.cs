﻿using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CTS.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Auth.Register;

public sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken = default)
    {
        bool isEmailExist = await userManager.Users.AnyAsync(p => p.Email == request.Email,cancellationToken);

        if (isEmailExist)
        {
            return Result<string>.Failure( "Email already exist.");
        }

        bool isUserNameExist = await userManager.Users.AnyAsync(p => p.UserName == request.UserName, cancellationToken);
        if (isUserNameExist)
        {
            return Result<string>.Failure("Username already exist.");
        }


        //db işlemleri : Bunun için neye ihtiyacım var=? UserManager

        AppUser user = new()
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.ToLower().Trim(),
            UserName = CommonService.ReplaceAllTurkishCharacters(request.UserName).ToLower().Trim()
        };

       IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
           List<string> errorMessages = result.Errors.Select(s => s.Description).ToList();
            return Result<string>.Failure(errorMessages);
        }

        return Result<string>.Succeed("User created successfully.");
    }
}