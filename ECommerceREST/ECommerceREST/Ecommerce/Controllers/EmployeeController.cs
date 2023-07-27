using Microsoft.AspNetCore.Mvc;
using DAL;
using BOL;
namespace Ecommerce.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController:ControllerBase
    {
         private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name= "employees")]
    [HttpGet]
    public IEnumerable<Employee> GetAll(){
        
          Console.WriteLine("inside the employee controller");
        List <Employee> elist=DBManager.GetAllEmployees();
        return elist;
    }
        
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Employee> GetById(int id)
        {
            Employee e = DBManager.GetById(id);
            if (e == null) {
                return NotFound();
            }
            return e;
       
        }


    }
}