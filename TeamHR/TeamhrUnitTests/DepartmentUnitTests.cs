using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using teamhr_api.Controllers;
using teamhr_api.DAO;
using teamhr_api.DTOs;
using teamhr_api.Repository;
using teamhr_api.Services;


namespace TeamhrUnitTests
{
    public class DepartmentUnitTests
    {
        private readonly Mock<IDepartmentRepository> departmentRepoStub = new();

        [Fact]
        public void ExtDepartmentDto_WithDepartmentEntity_ReturnDepartmentDto()
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
            var result = departmentEntity.ExtDepartmentDto();

            // Assert
            result.Equals(mockDepartmentDto);
        }

        private DepartmentDto testDepartmentData()
        {
            return new()
            {
                DepartmentId = Guid.NewGuid(),
                DepartmentName = "Mock Department",
                DepartmentDescription = "Mock Department Description"
            };
        }

        [Fact]
        // Naming convention: UnitOfWork_StateUnderTest_ExpectedBehaviour
        public void GetDepartmentById_WithExistentDepartment_ReturnsExpectedDepartment()
        {
            // Arrange
            var expectedDepartment = testDepartmentData();

            departmentRepoStub.Setup(repo => repo.GetDepartmentById(It.IsAny<Guid>())).Returns(expectedDepartment);

            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);

            // Act
            var result = mockDepartmentController.GetDepartmentById(Guid.NewGuid());

            // Assert
            result.Result.Equals(expectedDepartment);
        }

        [Fact]
        public void GetDepartmentById_WithNonExistentDepartment_ReturnsNotFound()
        {
            // Arrange
            departmentRepoStub.Setup(repo => repo.GetDepartmentById(It.IsAny<Guid>())).Returns((DepartmentDto)null);
            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);

            // Act
            var result = mockDepartmentController.GetDepartmentById(Guid.NewGuid());

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetAllDepartments_WithExistentDepartments_ReturnsAllDepartments()
        {
            // Arrange
            var expectedDepartments = new[]
            {
                 testDepartmentData(), testDepartmentData(), testDepartmentData()
            };
            departmentRepoStub.Setup(repo => repo.GetAllDepartments()).Returns(expectedDepartments);
            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);

            // Act
            var result = mockDepartmentController.GetAllDepartments();

            // Assert
            result.Result.Equals(expectedDepartments);
        }

        [Fact]
        public void PostNewDepartment_WithDepartmentToCreate_ReturnsCreatedDepartment()
        {
            // Arrange
            var newDepartment = new CreateDepartmentDto()
            {
                DepartmentName = "Mock Department",
                DepartmentDescription = "Mock Department Description"
            };

            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);

            // Act
            var result = mockDepartmentController.PostNewDepartment(newDepartment);

            // Assert
            var createdDepartment = (result.Result as CreatedResult).Value as DepartmentDto;
            newDepartment.Should().BeEquivalentTo(createdDepartment, options => options.ComparingByMembers<DepartmentDto>().ExcludingMissingMembers());
            createdDepartment.DepartmentId.Should().NotBeEmpty();
        }

        [Fact]
        public void UpdateDepartment_WithExistingDepartment_ReturnsUpDatedDepartment()
        {
            // Arrange
            var existingDepartment = testDepartmentData();
            departmentRepoStub.Setup(repo => repo.GetDepartmentById(It.IsAny<Guid>())).Returns(existingDepartment);

            var departmentIdToUpdate = existingDepartment.DepartmentId;
            var departmentToUpdate = new UpdateDepartmentDto()
            {
                DepartmentName = "Update Mock Department",
                DepartmentDescription = "Update Mock Department Description"
            };

            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);
            // Act
            var result = mockDepartmentController.PatchDepartmentById(departmentIdToUpdate, departmentToUpdate);

            // Assert
            result.Result.Equals(departmentIdToUpdate);
        }

        [Fact]
        public void UpdateDepartment_WithNonExixtentDepartment_ReturnsNoFound()
        {
            // Arrange
            var existingDepartment = testDepartmentData();
            departmentRepoStub.Setup(repo => repo.GetDepartmentById(It.IsAny<Guid>())).Returns(existingDepartment);

            var departmentToUpdate = new UpdateDepartmentDto()
            {
                DepartmentName = "Update Mock Department",
                DepartmentDescription = "Update Mock Department Description"
            };

            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);
            // Act
            var result = mockDepartmentController.PatchDepartmentById(Guid.NewGuid(), departmentToUpdate);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void DeleteDepartmentById_WithExixtentDepartment_ReturnsOKResult()
        {
            // Arrange
            var existingDepartment = testDepartmentData();
            departmentRepoStub.Setup(repo => repo.GetDepartmentById(It.IsAny<Guid>())).Returns(existingDepartment);

            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);

            // Act
            var result = mockDepartmentController.DeleteDepartmentById(existingDepartment.DepartmentId);

            // Assert
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void DeleteDepartmentById_WithNonExixtentDepartment_ReturnsNotFound()
        {
            // Arrange
            var existingDepartment = testDepartmentData();
            departmentRepoStub.Setup(repo => repo.GetDepartmentById(It.IsAny<Guid>())).Returns((DepartmentDto)null);

            var mockDepartmentController = new DepartmentController(departmentRepoStub.Object);

            // Act
            var result = mockDepartmentController.DeleteDepartmentById(Guid.NewGuid());

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}