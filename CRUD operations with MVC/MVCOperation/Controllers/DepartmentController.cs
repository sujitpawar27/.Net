using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCOperation.Models;

using BOL;
using BLL;
using modelEmployee;

namespace MVCOperation.Controllers;

public class DepartmentController : Controller
{
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger)
    {
        _logger = logger;
    }

    public IActionResult DeptList()
    {
        List<Department> dlist=Service.getAllDept();
        // foreach(Department d in dlist){
        // Console.WriteLine(d.Name);
        // }
        this.ViewData["departmentlist"]=dlist;
        return View();
    }

    [HttpPost]
    public IActionResult Details(int number)
    {
        Department d = Service.GetDepartmentById(number);
        this.ViewBag.selectDapartment = d;
        return View();
    }

    [HttpGet]
    public JsonResult Employee()
    {
        List<Employee> elist = new List<Employee>();
        elist.Add(new Employee{FirstName="Suyog", LastName="Shejul", Email="SS@gmail.com"});
        elist.Add(new Employee{FirstName="Nishant", LastName="Deshmukh", Email="ND@gmail.com"});
        elist.Add(new Employee{FirstName="Vaibhav", LastName="Sapkal", Email="VS@gmail.com"});
        return Json(elist);
    }
    [HttpPost]
    public IActionResult InsertEmployee(Employee emp)
    {
        Console.WriteLine(emp.FirstName+" "+emp.LastName);
        return RedirectToAction("Login","Auth");
    }

    [HttpPost]
    public IActionResult Insert(int id, string name, string loc)
    {
       Department d = new Department{
                                        Id=id,
                                        Name=name,
                                        Location=loc
       };
        bool s = Service.Insert(d);

        if(s)
           { 
            Console.WriteLine(" in controller inserted successfully");
            return RedirectToAction("DeptList","Department");
           }
        return View();
    }
    
}