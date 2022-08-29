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
    }
}
