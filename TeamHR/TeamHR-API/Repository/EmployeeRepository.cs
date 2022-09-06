using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Services;

namespace teamhr_api.Repository
{
    public interface IEmployeeRepository
    {
        EmployeeDto AddEmpByDepId(Guid departmentId, EmployeeDto newEmployeeDto);
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

        public EmployeeDto AddEmpByDepId(Guid departmentId, EmployeeDto newEmployee)
        {
            var findDeparmtnet = _dbContext.Departments.Find(departmentId);

            if (findDeparmtnet == null) return null;

            else
            {
                EmployeeEntity addEmployee = new()
                {
                    EmployeeId = new Guid(),
                    FirstName = newEmployee.FirstName,
                    LastName = newEmployee.LastName,
                    PhoneNumber = newEmployee.PhoneNumber,
                    Email = newEmployee.Email,
                    Location = newEmployee.Location
                };

                findDeparmtnet.Employees.Add(addEmployee);

                _dbContext.SaveChanges();

                return addEmployee.ExtEmployeeDto();
            }

        }

        public void DeleteEmployeeById(Guid employeeId)
        {
            var employeeEntity = _dbContext.Employees.Find(employeeId);

            _dbContext.Remove(employeeEntity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return _dbContext.Employees.Select(employees => employees.ExtEmployeeDto());
        }

        public EmployeeDto GetEmployeeById(Guid employeeId)
        {
            EmployeeEntity employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

            if (employee == null) return null;

            else return employee.ExtEmployeeDto();
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

                return employeeEntity.ExtEmployeeDto() with
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