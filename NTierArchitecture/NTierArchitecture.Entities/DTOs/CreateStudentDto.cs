using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.DTOs;
public sealed record CreateStudentDto(
    string FirstName,
    string LastName,
    int StudentNumber,
    string IdentityNumber,
    Guid ClassRoomId); //  Guid? ClassRoomId ile gönderirsen null veya silinmiş şekilde gönderebilirsin yoksa gönderemezsin.
