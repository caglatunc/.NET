using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Relational.WebApi.Models;

[Index("Name", IsUnique = true)]
public sealed class Category
{
    public Guid Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; } = string.Empty;
   // public  List<Product>? Products { get; set; }
}

//Virtual Örneklemesi
//public class A
//{
//    public virtual void Method1()
//    {

//    }

//    public virtual int Id { get; set; }
//}

//public class  B:A 
//{
//    [NotMapped]
//    public override int Id { get=>base.Id; set=>base.Id=value; }
//}