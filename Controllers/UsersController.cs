using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC_users.Controllers;

public class UsersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}