using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Repositories;

//CRUD işlemleri için kullanılacak metotların tanımlandığı interface
public interface IStudentRepository
{
    void Create(Student student);
    void Update(Student student);
    void DeleteById(Guid id);
    List<Student> GetAll();
    Student? GetStudentById(Guid studentId);
    bool IsStudentNumberExists(string IdentityNumber);
}
