using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Services;

namespace teamhr_api.Repository
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(EmployeeEntity newEmployee);
        IEnumerable<EmployeeDto> GetAllEmployees();

        EmployeeDto GetEmployeeById(Guid employeeId);

        EmployeeDto UpdateEmployeeById(Guid employeeId, UpdateEmployeeDto updateEmployeeDto);

        void DeleteEmployeeById(Guid employeeId);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TeamContext _dbContext;

        public EmployeeRepository(TeamContext teamdbContext)
        {
            _dbContext = teamdbContext;
        }

        public void CreateEmployee(EmployeeEntity newEmployee)
        {
            var employee = _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployeeById(Guid employeeId)
        {
            var employeeEntity = _dbContext.Employees.Find(employeeId);

            _dbContext.Remove(employeeEntity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return _dbContext.Employees.Select(employees => employees.ExEmployeeDto());
        }

        public EmployeeDto GetEmployeeById(Guid employeeId)
        {
            EmployeeEntity employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (employee == null) return null;

            else return employee.ExEmployeeDto();
        }

        public EmployeeDto UpdateEmployeeById(Guid employeeId, UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeEntity = _dbContext.Employees.Find(employeeId);

            if (employeeEntity == null) return null;

            else
            {
                if (employeeEntity.FirstName != updateEmployeeDto.FirstName) employeeEntity.FirstName = updateEmployeeDto.FirstName;

                if (employeeEntity.LastName != updateEmployeeDto.LastName) employeeEntity.LastName = updateEmployeeDto.LastName;

                if (employeeEntity.PhoneNumber != updateEmployeeDto.PhoneNumber) employeeEntity.PhoneNumber = updateEmployeeDto.PhoneNumber;

                if (employeeEntity.Email != updateEmployeeDto.Email) employeeEntity.Email = updateEmployeeDto.Email;

                if (employeeEntity.Location != updateEmployeeDto.Location) employeeEntity.Location = updateEmployeeDto.Location;

                _dbContext.SaveChanges();

                return employeeEntity.ExEmployeeDto() with
                {
                    FirstName = employeeEntity.FirstName,
                    LastName = employeeEntity.LastName,
                    PhoneNumber = employeeEntity.PhoneNumber,
                    Email = employeeEntity.Email,
                    Location = employeeEntity.Location,
                };
            }
        }
    }
}