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
        var users = await context.Users.ToListAsync();
        return View(users);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(UserDto request)
    {
        // verificación de modelo
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

        var newUser = new User(request.Name, request.Lastname, request.Email, request.DateOfBirth, request.Gender);
        context.Add(newUser);
        await context.SaveChangesAsync();
        
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