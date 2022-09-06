using teamhr_api.DAO;
using teamhr_api.Services;

namespace TeamhrUnitTests
{
    [TestClass]
    public class EmplyeeUnitTests
    {
        [TestMethod]
        public void ExtEmployeeDtoTests()
        {
            // Arrange
            var employeeEntity = new EmployeeEntity
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Lee",
                PhoneNumber = "021727928234",
                Email = "james.lee@teamhr.co.nz",
                Location = "Auckland"
            };
            // Act
            var employeeDto = employeeEntity.ExtEmployeeDto();

            // Assert
            Assert.AreEqual(employeeEntity.EmployeeId, employeeDto.EmployeeId);
            Assert.AreEqual(employeeEntity.FirstName, employeeDto.FirstName);
            Assert.AreEqual(employeeEntity.LastName, employeeDto.LastName);
            Assert.AreEqual(employeeEntity.PhoneNumber, employeeDto.PhoneNumber);
            Assert.AreEqual(employeeEntity.Email, employeeDto.Email);
            Assert.AreEqual(employeeEntity.Location, employeeDto.Location);
        }
    }
}
