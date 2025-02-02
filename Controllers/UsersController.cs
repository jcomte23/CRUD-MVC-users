using CRUD_MVC_users.Data;
using CRUD_MVC_users.Data.Seeders;
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