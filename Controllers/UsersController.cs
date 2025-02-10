using CRUD_MVC_users.Data;
using CRUD_MVC_users.Data.Seeders;
using CRUD_MVC_users.DTOs;
using CRUD_MVC_users.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_users.Controllers;

public class UsersController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        try
        {
            var users = await context.Users.ToListAsync();
            return View(users);
        }
        catch (Exception ex)
        {
            // Registra el error
            Console.WriteLine($"Error en Index: {ex.Message}");

            // Mensaje de error con TempData
            TempData["ErrorMessage"] = "Ocurrió un error al obtener los usuarios. Por favor, inténtalo de nuevo.";

            // Redirige a la misma vista o a otra
            return RedirectToAction("Index");
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto request)
    {
        try
        {
            // Verificación de modelo
            if (!ModelState.IsValid) return View(request);

            // Verificar si la fecha de nacimiento es mayor a la fecha actual
            if (request.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError("DateOfBirth", "La fecha de nacimiento no puede ser en el futuro.");
                return View(request);
            }

            // Verificar si el correo electrónico ya está registrado en la base de datos
            var existingUser = await context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
                return View(request);
            }

            // Crear el nuevo usuario
            var newUser = new User(request.Name, request.Lastname, request.Email, request.DateOfBirth, request.Gender);
            context.Add(newUser);
            await context.SaveChangesAsync();

            // Agregar mensaje de éxito a TempData
            TempData["SuccessMessage"] = "El usuario se ha creado exitosamente.";

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            // Log del error (se recomienda usar ILogger en lugar de Console.WriteLine)
            Console.WriteLine($"Error en Create: {ex.Message}");

            // Almacenar mensaje de error en TempData
            TempData["ErrorMessage"] = "Ocurrió un error al crear el usuario. Por favor, inténtalo de nuevo.";

            return RedirectToAction(nameof(Index));
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        // Buscamos al usuario por su ID
        var user = await context.Users.FindAsync(id);

        // Si el usuario no existe, retornamos un 404
        if (user == null)
        {
            return NotFound();
        }

        // Creamos un UserDto con los datos actuales del usuario para pasarlo a la vista
        var userDto = new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Lastname = user.Lastname,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            Gender = user.Gender
        };

        // Regresamos la vista con el DTO que contiene los datos del usuario
        return View(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserDto request)
    {
        // Verificación de modelo
        if (!ModelState.IsValid) return View(request);

        // Verificar si la fecha de nacimiento es mayor a la fecha actual
        if (request.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
        {
            ModelState.AddModelError("DateOfBirth", "La fecha de nacimiento no puede ser en el futuro.");
            return View(request);
        }

        // Verificar si el correo electrónico ya está registrado en la base de datos, exceptuando al usuario actual
        var existingUser = await context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email && u.Id != request.Id);

        if (existingUser != null)
        {
            ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
            return View(request);
        }

        // Buscamos al usuario por su ID
        var user = await context.Users.FindAsync(request.Id);

        // Si el usuario no existe, retornamos un 404
        if (user == null)
        {
            return NotFound();
        }

        // Actualizamos los datos del usuario
        user.Name = request.Name;
        user.Lastname = request.Lastname;
        user.Email = request.Email;
        user.DateOfBirth = request.DateOfBirth;
        user.Gender = request.Gender;

        // Guardamos los cambios en la base de datos
        await context.SaveChangesAsync();

        // Agregar mensaje de éxito a TempData
        TempData["SuccessMessage"] = "El usuario se ha actualizado exitosamente.";

        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        // Buscamos al usuario por su ID
        var user = await context.Users.FindAsync(id);

        // Si el usuario no existe, retornamos un 404
        if (user == null)
        {
            return NotFound();
        }

        // Eliminamos al usuario de la base de datos
        context.Users.Remove(user);
        await context.SaveChangesAsync();

        // Agregar mensaje de éxito a TempData
        TempData["SuccessMessage"] = "El usuario se ha eliminado exitosamente.";

        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> SeedUsers()
    {
        var fakeUsers = UserSeeder.GenerateFakeUsers(100);

        await context.Users.AddRangeAsync(fakeUsers);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ClearUsers()
    {
        var users = context.Users.ToList();

        context.Users.RemoveRange(users);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}