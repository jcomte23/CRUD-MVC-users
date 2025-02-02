using Bogus;
using CRUD_MVC_users.Models;
using CRUD_MVC_users.Models.Enums;

namespace CRUD_MVC_users.Data.Seeders;

public static class UserSeeder
{
    public static List<User> GenerateFakeUsers(int numberOfUsers = 50)
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid()) 
            .RuleFor(u => u.Name, f => f.Name.FirstName())
            .RuleFor(u => u.Lastname, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Name, u.Lastname))
            .RuleFor(u => u.DateOfBirth, f => DateOnly.FromDateTime(f.Date.Between(DateTime.Now.AddYears(-30), DateTime.Now.AddYears(-18)))) 
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>()) 
            .RuleFor(u => u.CreatedAt, f => f.Date.Past(1))
            .RuleFor(u => u.UpdatedAt, f => f.Date.Recent());

        return faker.Generate(numberOfUsers); // Genera 50 usuarios por defecto
    }
}