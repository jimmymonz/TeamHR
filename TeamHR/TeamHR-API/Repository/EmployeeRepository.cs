using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Services;

namespace teamhr_api.Repository
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(EmployeeEntity newEmployee);
        IEnumerable<EmployeeDto> GetAllEmployees();
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

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return _dbContext.Employees.Select(employees => employees.ExEmployeeDto());
        }
    }
}