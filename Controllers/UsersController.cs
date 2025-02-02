using CRUD_MVC_users.Data;
using CRUD_MVC_users.Data.Seeders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC_users.Controllers;

public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
    }
    
    public async Task<IActionResult> SeedUsers()
    {
        var fakeUsers = UserSeeder.GenerateFakeUsers(100);
        
        await _context.Users.AddRangeAsync(fakeUsers);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> ClearUsers()
    {
        var users = _context.Users.ToList();
        
        _context.Users.RemoveRange(users);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
}