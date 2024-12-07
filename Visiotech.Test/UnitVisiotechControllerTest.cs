using Microsoft.AspNetCore.Mvc.Testing;

namespace Visiotech.Test
{
    public class UnitVisiotechControllerTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UnitVisiotechControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetManagersIds_API()
        {
            var response = await _client.GetAsync("VisioTech/managers/ids");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            
            Assert.Contains("[1,2,3]", content);
        }

        [Fact]
        public async Task GetManagersTaxNumbers_API()
        {
            var response = await _client.GetAsync("VisioTech/managers/taxnumbers");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Assert.Contains("[\"143618668\",\"78903228\",\"132254524\"]", content);
        }       
    }
}