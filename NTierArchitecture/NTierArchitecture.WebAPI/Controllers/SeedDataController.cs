using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Repositories;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace NTierArchitecture.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SeedDataController(
    AppDbContext context,
     IStudentRepository studentRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CreateRandomStudentsAsync()
    {
        var classRooms = await context.ClassRooms.ToListAsync();
        var random = new Random();
        var batchSize = 1000; // Her batch'te kaç öğrenci ekleyeceğinizi belirleyin
        var studentsToAdd = new List<Student>();

        for (int i = 0; i < 1000000; i++) // 1 milyon öğrenci
        {
            Faker faker = new();
            int studentNumber = studentRepository.GetNewStudentNumber();
            string identityNumber = Math.Ceiling(faker.Person.Random.Decimal(11111111111, 999999999998)).ToString();

            while (context.Students.Any(p => p.IdentityNumber == identityNumber))
            {
                identityNumber = Math.Ceiling(faker.Person.Random.Decimal(11111111111, 999999999998)).ToString();
            }

            Student student = new()
            {
                ClassRoomId = classRooms[random.Next(0, classRooms.Count)].Id,
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                IdentityNumber = identityNumber,
                StudentNumber = studentNumber,
                CreatedDate = DateTime.Now,
                CreatedBy = "Admin",
                IsDeleted = false
            };

            studentsToAdd.Add(student);

            if (studentsToAdd.Count == batchSize)
            {
                context.AddRange(studentsToAdd);
                await context.SaveChangesAsync();
                studentsToAdd.Clear(); // Listeyi temizleyin ve yeni bir batch başlatın
            }
        }

        if (studentsToAdd.Count > 0)
        {
            context.AddRange(studentsToAdd);
            await context.SaveChangesAsync();
        }

        return NoContent();
    }


}

