using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Auth.WebApi.Models;

public sealed class AppUser
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;

}
