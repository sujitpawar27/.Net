using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCOperation.Models;



namespace MVCOperation.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

        [HttpGet]
       public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
       public IActionResult Login(string mail, string pwd)
    {
        
        if(mail=="my@gmail.com" && pwd == "123")
        {
            return RedirectToAction("DeptList", "Department");
        }
        return View();
    }
}