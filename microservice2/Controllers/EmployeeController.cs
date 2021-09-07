using Microsoft.AspNetCore.Mvc;

namespace microservice2
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private  IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData) 
        {
            _employeeData=employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(int id)
        {
            return Ok(_employeeData.GetEmployee(id));
        }

        [HttpPost]
        [Route("api/[controller]")]
         public IActionResult AddEmployee(Employee employeeData)
        {
            _employeeData.AddEmployee(employeeData);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employeeData.Id,employeeData);
            
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeData.DeleteEmployee(id);
            return NotFound();

        }

         [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateEmployee(int id,Employee employee)
        {
            _employeeData.UpdateEmployee(id,employee);
            return Ok(employee);

        }
    }
}