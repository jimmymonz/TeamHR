using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Services;

namespace TeamhrUnitTests
{
    [TestClass]
    public class DepartmentUnitTests
    {
        [TestMethod]
        public void ExtDepartmentDtoTest()
        {
            // Arrange
            var mockDepartmentId = Guid.NewGuid();
            var mockDepartmentDto = new DepartmentDto
            {
                DepartmentId = mockDepartmentId,
                DepartmentName = "Operations",
                DepartmentDescription = "Department for the operations of the compay."
            };

            var departmentEntity = new DepartmentEntity
            {
                DepartmentId = mockDepartmentId,
                DepartmentName = "Operations",
                DepartmentDescription = "Department for the operations of the compay."
            };

            // Act
            var departmentDto = departmentEntity.ExtDepartmentDto();

            // Assert
            Assert.AreEqual(mockDepartmentDto, departmentDto);
        }
    }
}