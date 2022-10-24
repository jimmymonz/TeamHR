using Microsoft.AspNetCore.Mvc.Testing;

namespace TeamhrIntegrationTests.Fixtures
{
    public class IntegrationTestsFixture : IDisposable
    {
        public HttpClient TestClient { get; set; }
        public Guid testId { get; set; }

        public IntegrationTestsFixture()
        {
            var appFactory = new WebApplicationFactory<Program>();

            TestClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
            TestClient.Dispose();
        }
    }
}
