using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SeedDataController(
    AppDbContext context,
    IStudentRepository studentRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult CreateRandomStudents()
    {
       
        var classRooms = context.ClassRooms.ToList();
        var random= new Random();

        for(int i=0; i<1000; i++)
        {
            Faker faker = new();

            int studentnumber = studentRepository.GetNewStudentNumber();
            string identityNumber = Math.Ceiling(faker.Random.Decimal(11111111111, 99999999998)).ToString();

           while(context.Students.Any(p=>p.IdentityNumber == identityNumber))
            {
              identityNumber = Math.Ceiling(faker.Random.Decimal(11111111111, 99999999998)).ToString();
            }


            Student student = new()
            {
                ClassRoomId = classRooms[random.Next(0, classRooms.Count)].Id,
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                IdentityNumber = identityNumber,
                StudentNumber = studentnumber,
                CreatedDate = DateTime.Now,
                CreatedBy = "Admin",
                IsDeleted = false
            };
            context.Add(student);
            context.SaveChanges();
        }
        return NoContent();
    }
}
