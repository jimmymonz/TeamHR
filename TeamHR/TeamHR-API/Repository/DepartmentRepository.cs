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
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            return _dbContext.Departments.Select(Departments => Departments.ExtDepartmentDto());
        }

        public DepartmentRepository(TeamContext teamContext)
        {
            _dbContext = teamContext;
        }
        public DepartmentDto GetDepartmentById(Guid departmentId)
        {
            DepartmentEntity result = _dbContext.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);

            if (result == null) return null;
            else return result.ExtDepartmentDto();
        }

        public void CreateDeparment(DepartmentEntity newDepartment)
        {
            var department = _dbContext.Departments.Add(newDepartment);
            _dbContext.SaveChanges();
        }

        public DepartmentDto UpdateDepartmentById(Guid departmentId, UpdateDepartmentDto updateDepartmentDto)
        {
            var crDepartmentEntity = _dbContext.Departments.Find(departmentId);

            if (crDepartmentEntity == null) return null;
            else
            {
                if (updateDepartmentDto.DepartmentName != null) crDepartmentEntity.DepartmentName = updateDepartmentDto.DepartmentName;

                if (updateDepartmentDto.DepartmentDescription != null) crDepartmentEntity.DepartmentDescription = updateDepartmentDto.DepartmentDescription;

                _dbContext.SaveChanges();

                return crDepartmentEntity.ExtDepartmentDto() with
                {
                    DepartmentName = crDepartmentEntity.DepartmentName,
                    DepartmentDescription = crDepartmentEntity.DepartmentDescription,
                };
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
