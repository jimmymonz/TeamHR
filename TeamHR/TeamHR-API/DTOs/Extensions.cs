using teamhr_api.DAO;

namespace teamhr_api.DTOs
{
    public static class Extensions
    {
        public static EmployeeDto ExEmployeeDto(this EmployeeEntity employeeEntity)
        {
            return new EmployeeDto
            {
                EmployeeId = employeeEntity.EmployeeId,
                FirstName = employeeEntity.FirstName,
                LastName = employeeEntity.LastName,
                PhoneNumber = employeeEntity.PhoneNumber,
                Email = employeeEntity.Email,
                Location = employeeEntity.Location
            };
        }
    }
}
