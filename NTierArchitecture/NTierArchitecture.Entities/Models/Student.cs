﻿using NTierArchitecture.Entities.Abstractions;

namespace NTierArchitecture.Entities.Models;
public sealed class Student :Entity
{
    public static double Count { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", this.FirstName, this.LastName);
    public int StudentNumber { get; set; }
    public  string IdentityNumber { get; set; }= string.Empty;
    
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }

    public static object Skip(int v)
    {
        throw new NotImplementedException();
    }
}
