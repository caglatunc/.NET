using CleanArchitecture.Application.Utilities;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using CTS.Result;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace CleanArchitecture.Application.Features.Auth.Register;
public sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMediator mediator) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken = default)
    {

        //db işlemleri : Bunun için neye ihtiyacım var=? UserManager

        AppUser user = new()
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.ToLower().Trim(),
            UserName = request.UserName.ReplaceAllTurkishCharacters().ToLower().Trim(),
        };

       IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
           List<string> errorMessages = result.Errors.Select(s => s.Description).ToList();
            return Result<string>.Failure(errorMessages);
        }

       await mediator.Publish(new AuthDomainEvent(user));

        return Result<string>.Succeed("User created successfully.");
    }
}