using teamhr_api.DAO;
using teamhr_api.DTOs;

namespace teamhr_api.Services
{
    public static class Extensions
    {
        public static DepartmentDto ExtDepartmentDto(this DepartmentEntity departmentEntity)
        {
            return new DepartmentDto
            {
                DepartmentId = departmentEntity.DepartmentId,
                DepartmentName = departmentEntity.DepartmentName,
                DepartmentDescription = departmentEntity.DepartmentDescription
            };
        }

        public static EmployeeDto ExtEmployeeDto(this EmployeeEntity employee)
        {
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Location = employee.Location,
            };
        }
    }
}
