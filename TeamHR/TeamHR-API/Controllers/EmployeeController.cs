using Microsoft.AspNetCore.Mvc;
using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Repository;

namespace teamhr_api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("employee")]
        public ActionResult<EmployeeDto> PostNewEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            EmployeeEntity newEmployee = new()
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                PhoneNumber = createEmployeeDto.PhoneNumber,
                Email = createEmployeeDto.Email,
                Location = createEmployeeDto.Location,
            };

            _employeeRepository.CreateEmployee(newEmployee);

            return Created("GetEmployeeByEmployeeId", newEmployee.ExEmployeeDto());
        }

        [HttpGet("employees")]
        public ActionResult<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("employee/{employeeId}")]
        public ActionResult<EmployeeDto> GetEmployeeById([FromRoute] Guid employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            if (employee == null) return NotFound();
            else return Ok(employee);
        }

        [HttpPatch("employee/{employeeId}")]
        public ActionResult<EmployeeDto> PatchEmployeeByEmployeeId([FromRoute] Guid employeeId, [FromBody] UpdateEmployeeDto updateStoreDto)
        {
            var updatedEmployee = _employeeRepository.UpdateEmployeeById(employeeId, updateStoreDto);
            if (updatedEmployee == null) return NotFound();
            return Ok(updatedEmployee);
        }

        [HttpDelete("employee/{employeeId}")]
        public ActionResult DeleteEmployeeById(Guid employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            if (employee == null) return NotFound();

            else
            {
                _employeeRepository.DeleteEmployeeById(employeeId);
                return Ok();
            }
        }
    }
}
