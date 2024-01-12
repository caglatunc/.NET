using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Auth.WebApi.Models;


[Index("Email", IsUnique = true)]
public sealed class AppUser
{
    [Key]
    public Guid Id { get; set; }

    [Column(Order=1, TypeName="varchar(50)" )]
    [Required(ErrorMessage ="FirstName is required!")]
    public string FirstName { get; set; } = string.Empty;

    [Column(Order = 2, TypeName = "varchar(50)")]
    [Required(ErrorMessage = "LastNameis required!")]
    public string lastName { get; set; } = string.Empty;

    [Required]
    [Column(Order = 4)]
    public byte[] PasswordSalt { get; set; } = new byte[64];

    [Required]
    [Column(Order = 5)]
    public byte[] PasswordHash { get; set; } = new byte[128];

    [Column(Order = 3, TypeName = "varchar(200)")]
    [Required]
    public string Email { get; set; } = string.Empty;

    [Column(Order = 6, TypeName = "varchar(20)")]
    public string? PhoneNumber { get; set; }
}
