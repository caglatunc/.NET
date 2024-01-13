﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.Relational.WebApi.Models;

[Index("Name", IsUnique=true)]
public sealed class Product
{
    public Guid Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; } = string.Empty;
    public AdditionalProduct? AdditionalProduct { get; set; }
    public Guid CategoryId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Category? Category { get; set; } //Product bilgisini çekerken CategoryId üzerinden kategori bilgisini çekebilmek için yapıyoruz.
}
