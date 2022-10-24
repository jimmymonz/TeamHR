using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Services;

namespace teamhr_api.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartmentById(Guid departmentId);
        void CreateDeparment(DepartmentEntity newDepartment);
        DepartmentDto UpdateDepartmentById(Guid departmentId, UpdateDepartmentDto updateDepartmentDto);
        void DeleteDepartmentById(Guid departmentId);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TeamContext _dbContext;

        public DepartmentRepository(TeamContext teamContext)
        {
            _dbContext = teamContext;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            return _dbContext.Departments.Select(Departments => Departments.ExtDepartmentDto());
        }

        public DepartmentDto GetDepartmentById(Guid departmentId)
        {
            var result = _dbContext.Departments.Where(x => x.DepartmentId == departmentId).Single();
            return result.ExtDepartmentDto();
        }

        public void CreateDeparment(DepartmentEntity newDepartment)
        {
            _dbContext.Departments.Add(newDepartment);
            _dbContext.SaveChanges();
        }

        public DepartmentDto UpdateDepartmentById(Guid departmentId, UpdateDepartmentDto updateDepartmentDto)
        {
            var findDepartment = _dbContext.Departments.Find(departmentId);

            if (findDepartment == null) return null;
            else
            {
                if (updateDepartmentDto.DepartmentName != null) findDepartment.DepartmentName = updateDepartmentDto.DepartmentName;

                if (updateDepartmentDto.DepartmentDescription != null) findDepartment.DepartmentDescription = updateDepartmentDto.DepartmentDescription;

                _dbContext.SaveChanges();

                return findDepartment.ExtDepartmentDto();
            }
        }

        public void DeleteDepartmentById(Guid departmentId)
        {
            var crDepartmentEntity = _dbContext.Departments.Find(departmentId);
            _dbContext.Remove(crDepartmentEntity);
            _dbContext.SaveChanges();
        }
    }
}
