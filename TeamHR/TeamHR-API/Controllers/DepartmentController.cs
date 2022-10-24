using Microsoft.AspNetCore.Mvc;
using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Repository;
using teamhr_api.Services;

namespace teamhr_api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("departments")]
        public ActionResult<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();

            return Ok(departments);
        }

        [HttpGet("department/{departmentId}")]
        public ActionResult<DepartmentDto> GetDepartmentById([FromRoute] Guid departmentId)
        {

            var department = _departmentRepository.GetDepartmentById(departmentId);

            if (department == null) return NotFound();
            else return Ok(department);
        }
        [HttpPost("department")]
        public ActionResult<DepartmentDto> PostNewDepartment([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            DepartmentEntity newDepartment = new()
            {
                DepartmentId = Guid.NewGuid(),
                DepartmentName = createDepartmentDto.DepartmentName,
                DepartmentDescription = createDepartmentDto.DepartmentDescription,
            };

            _departmentRepository.CreateDeparment(newDepartment);
            return Created("GetDepartmentById", newDepartment.ExtDepartmentDto());
        }

        [HttpPatch("department/{departmentId}")]
        public ActionResult<DepartmentDto> PatchDepartmentById([FromRoute] Guid departmentId, [FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            var updatedDepartment = _departmentRepository.UpdateDepartmentById(departmentId, updateDepartmentDto);
            if (updatedDepartment == null) return NotFound();
            return Ok(updatedDepartment);
        }

        [HttpDelete("department/{departmentId}")]
        public ActionResult DeleteDepartmentById(Guid departmentId)
        {
            var currentDepartment = _departmentRepository.GetDepartmentById(departmentId);

            if (currentDepartment == null) return NotFound();
            else
            {
                _departmentRepository.DeleteDepartmentById(departmentId);
                return Ok();
            }
        }
    }
}
