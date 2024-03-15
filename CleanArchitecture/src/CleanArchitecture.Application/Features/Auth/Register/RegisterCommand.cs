using CTS.Result;
using MediatR;

namespace CleanArchitecture.Application.Features.Auth.Register;
public sealed record class RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password) : IRequest<Result<string>>;
