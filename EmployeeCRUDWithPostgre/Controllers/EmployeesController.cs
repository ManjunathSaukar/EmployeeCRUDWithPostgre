using EmployeeCRUDWithPostgre.Models;
using EmployeeCRUDWithPostgre.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDWithPostgre.Controllers
{
    [Route("api/employees")] // Changed the base route to "api/employees"
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")] // Renamed the endpoint to "api/employees/all"
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeService.GetEmployeeList();

            return Ok(result);
        }

        [HttpGet("GetEmployeeById/{id}")] // This is now "api/employees/{id}"
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployee(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("AddEmployee")] // Renamed the endpoint to "api/employees/add"
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var result = await _employeeService.CreateEmployee(employee);

            return Ok(result);
        }

        [HttpPut("UpdateEmployee")] // Renamed the endpoint to "api/employees/update"
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);

            return Ok(result);
        }

        [HttpDelete("DeleteEmployee/{id}")] // This is now "api/employees/{id}"
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);

            return Ok(result);
        }
    }
}
