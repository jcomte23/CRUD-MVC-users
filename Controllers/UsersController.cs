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
        if (!ModelState.IsValid) return View(request);
        
        var existingUser = await context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (existingUser != null)
        {
            ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
            return View(request);
        }

        var newUser = new User(request.Name, request.Lastname, request.Email, request.DateBirth, request.Gender);
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