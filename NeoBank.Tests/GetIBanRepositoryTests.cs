using Moq;
using NeoBank.Configurations;
using NeoBank.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoBank.Tests
{
    public class GetIBanRepositoryTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactory;

        public GetIBanRepositoryTests()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("IBAN")
            };
            var httpClient = new Mock<HttpClient>();
            httpClient.Setup(client => client.GetAsync("Finance/Iban/NL"))
                .ReturnsAsync(httpResponseMessage);

            _httpClientFactory.Setup(c => c.CreateClient("Randommer"))
                .Returns(httpClient.Object);
        }

        [Fact]
        public async void GetIBan_Should_Return_String()
        {
            // Arrange
            var repository = new GetIBanRepository(_httpClientFactory.Object);

            // Act
            var result = await repository.GetIBAN("NL");

            // Assert
            Assert.Equal("IBAN", result);
        }
    }
}
