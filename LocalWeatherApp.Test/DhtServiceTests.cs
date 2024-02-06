using LocalWeatherApp.Interfaces;
using LocalWeatherApp.Models;
using LocalWeatherApp.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System.Net;
using NUnit.Framework.Constraints;

namespace LocalWeatherApp.Test
{
    [TestFixture]
    public class DhtServiceTests
    {
        private Mock<IHttpClient> _mockHttpClient;
        private Mock<IConfigurationWrapper> _mockConfiguration;
        private DhtService _dhtService;

        [SetUp]
        public void SetUp()
        {
            _mockHttpClient = new Mock<IHttpClient>();
            _mockConfiguration = new Mock<IConfigurationWrapper>();
            _dhtService = new DhtService(_mockHttpClient.Object, _mockConfiguration.Object);
        }

        [Test]
        public async Task GetDHTDataAsync_ReturnsData_WhenResponseIsSuccessful()
        {
            // Arrange
            var expectedData = new List<DhtData> { new DhtData() };
            var serializedData = JsonConvert.SerializeObject(expectedData);
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedData)
            };
            _mockHttpClient.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(responseMessage);
            _mockConfiguration.Setup(x => x.GetValue(It.IsAny<string>())).Returns("test");

            // Act
            var result = await _dhtService.GetDHTDataAsync();

            // Assert   
            Assert.That(result.Count, Is.EqualTo(expectedData.Count));
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i].Id, Is.EqualTo(expectedData[i].Id));
            }
        }

    }
}