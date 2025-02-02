using Bogus;
using CRUD_MVC_users.Models;
using CRUD_MVC_users.Models.Enums;

namespace CRUD_MVC_users.Data.Seeders;

public static class UserSeeder
{
    public static List<User> GenerateFakeUsers(int numberOfUsers = 50)
    {
        var faker = new Faker(); // Usamos Faker general en lugar de crear un User específico

        var users = new List<User>();

        for (var i = 0; i < numberOfUsers; i++)
        {
            var name = faker.Name.FirstName();
            var lastname = faker.Name.LastName();
            var email = faker.Internet.Email(name, lastname);
            var dateOfBirth = DateOnly.FromDateTime(faker.Date.Between(DateTime.Now.AddYears(-30), DateTime.Now.AddYears(-18)));
            var gender = faker.PickRandom<Gender>();
            var createdAt = faker.Date.Past(1);
            var updatedAt = faker.Date.Recent();

            var user = new User(name, lastname, email, dateOfBirth, gender)
            {
                // Creamos el usuario con el constructor y asignamos valores para CreatedAt y UpdatedAt
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };

            users.Add(user);
        }

        return users;
    }
}