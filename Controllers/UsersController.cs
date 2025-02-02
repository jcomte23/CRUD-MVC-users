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
        // var users = await _context.Users.ToListAsync();
        //
        // return View(users);
        
        var fakeUsers = UserSeeder.GenerateFakeUsers(1000);
        return View(fakeUsers);
    }
}