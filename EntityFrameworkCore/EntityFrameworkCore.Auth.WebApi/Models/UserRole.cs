using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Auth.WebApi.Models;

public sealed class UserRole
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("AppUser")] //AppUserId'nın hangı tabloda ilişkili olduğunu ForeignKey'e göre bağlamış oluyor.
    public Guid AppUserId { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)] //AppUser silindiğinde UserRole'de silinsin.
    public AppUser? AppUser { get; set; }


    [ForeignKey("Role")]
    public Guid RoleId { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Role? Role { get; set; }
}
