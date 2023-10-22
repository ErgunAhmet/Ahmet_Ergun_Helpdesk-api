using Helpdesk_api.Dto;
using Helpdesk_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Ahmet_Ergun_Helpdesk_api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id:int}", Name = "GetEmployeeRoute")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequest model)
        {
            var serviceResult = await _employeeService.CreateEmployeeAsync(model);
            if (!serviceResult.IsSuccess || serviceResult.Result == null)
            {
                return Ok(serviceResult);
            }

            return CreatedAtRoute("GetEmployeeRoute", new { id = serviceResult.Result.Id }, serviceResult);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeUpdateRequest model)
        {
            var serviceResult = await _employeeService.UpdateEmployeeAsync(id, model);
            return Ok(serviceResult);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var serviceResult = await _employeeService.DeleteEmployeeAsync(id);
            return Ok(serviceResult);
        }
    }
}
