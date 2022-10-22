using Newtonsoft.Json;
using System.Net.Http.Headers;
using teamhr_api.DTOs;
using TeamhrIntegrationTests.Attributes;
using TeamhrIntegrationTests.Fixtures;

namespace TeamhrIntegrationTests
{
    [TestCaseOrderer("TeamhrIntegrationTests.Orderers.PriorityOrderer", "TeamhrIntegrationTests")]

    public class ControllerTests : IClassFixture<IntegrationTestsFixture>
    {
        private static IntegrationTestsFixture _testfixture;

        public ControllerTests(IntegrationTestsFixture testfixture)
        {
            _testfixture = testfixture;
        }

        [Fact, TestPriority(1)]
        public async Task PostNewDepartment_ReturnCreated_AndHasExpectedProperies()
        {
            // Arrange
            var testRequest = new CreateDepartmentDto
            {
                DepartmentName = "Test Department",
                DepartmentDescription = "Depatment created during integration test"
            };

            // Act
            var response = await _testfixture.TestClient.PostAsJsonAsync("api/department", testRequest);
            var returnedPost = await response.Content.ReadFromJsonAsync<DepartmentDto>();
            _testfixture.testId = returnedPost.DepartmentId;

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            returnedPost.DepartmentName.Should().Be(testRequest.DepartmentName);
            returnedPost.DepartmentDescription.Should().Be(testRequest.DepartmentDescription);
        }

        [Fact, TestPriority(2)]
        public async Task GetAllDepartments_ReturnOk()
        {
            // Arrange

            // Actkjghjhjg
            var response = await _testfixture.TestClient.GetAsync("api/departments");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, TestPriority(2)]
        public async Task GetDepartmentById_ReturnOk()
        {
            // Arrange
            var testIdString = _testfixture.testId.ToString();

            // Act
            var response = await _testfixture.TestClient.GetAsync($"api/department/{testIdString}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, TestPriority(2)]
        public async Task PatchDepartmentById_ReturnOk()
        {
            // Arrange
            var testRequest = new CreateDepartmentDto
            {
                DepartmentName = "Test Department Update",
                DepartmentDescription = "Depatment updated during integration test"
            };

            var testIdString = _testfixture.testId.ToString();

            // Converts CreateDepartmentDto to ByteArrayContent which can be passed to PatchAsync
            var testRequestSerialised = JsonConvert.SerializeObject(testRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(testRequestSerialised);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act
            var response = await _testfixture.TestClient.PatchAsync($"api/department/{testIdString}", byteContent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, TestPriority(3)]
        public async Task DeleteDepartmentById_ReturnOk()
        {
            // Arrange
            var testIdString = _testfixture.testId.ToString();

            // Act
            var response = await _testfixture.TestClient.DeleteAsync($"api/department/{testIdString}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
