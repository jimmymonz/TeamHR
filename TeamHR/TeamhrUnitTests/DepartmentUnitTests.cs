using teamhr_api.DAO;
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
            var departmentEntity = new DepartmentEntity
            {
                DepartmentId = Guid.NewGuid(),
                DepartmentName = "Operations",
                DepartmentDescription = "Department for the operations of the compay."
            };

            // Act
            var departmentDto = departmentEntity.ExtDepartmentDto();

            // Assert
            Assert.AreEqual(departmentEntity.DepartmentId, departmentDto.DepartmentId);
            Assert.AreEqual(departmentEntity.DepartmentName, departmentDto.DepartmentName);
            Assert.AreEqual(departmentEntity.DepartmentDescription, departmentDto.DepartmentDescription);
        }
    }
}