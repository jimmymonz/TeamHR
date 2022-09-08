using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Services;

namespace TeamhrUnitTests
{
    public class EmplyeeUnitTests
    {
        [Fact]
        public void ExtEmployeeDtoTests()
        {
            // Arrange
            var mockEmployeeId = Guid.NewGuid();
            var mockEmployeeDto = new EmployeeDto
            {
                EmployeeId = mockEmployeeId,
                FirstName = "James",
                LastName = "Lee",
                PhoneNumber = "021727928234",
                Email = "james.lee@teamhr.co.nz",
                Location = "Auckland"
            };

            var employeeEntity = new EmployeeEntity
            {
                EmployeeId = mockEmployeeId,
                FirstName = "James",
                LastName = "Lee",
                PhoneNumber = "021727928234",
                Email = "james.lee@teamhr.co.nz",
                Location = "Auckland"
            };
            // Act
            var employeeDto = employeeEntity.ExtEmployeeDto();

            // Assert
            Assert.Equal(mockEmployeeDto, employeeDto);
        }
    }
}