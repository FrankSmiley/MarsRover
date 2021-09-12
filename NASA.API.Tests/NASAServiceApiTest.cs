using FluentAssertions;
using Moq;
using NASA.Api.Models;
using NASA.Api.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NASA.API.Tests
{
    public class NASAServiceApiTest
    {
        private readonly Mock<INasaApi> _nasaApi;       

        public NASAServiceApiTest()
        {
            _nasaApi = new Mock<INasaApi>();            
        }

        [Fact]
        public async Task GetPhotos_Returns_PhotoCollection()
        {
            var photoDate = new DateTime(2018, 4, 30);
            var response = new Mock<MarsPhotoResponse>();
            
            response.SetupAllProperties();

            _nasaApi.Setup(n => n.GetPhotos(It.IsAny<DateTime>())).ReturnsAsync(response.Object);
            var photos = await _nasaApi.Object.GetPhotos(photoDate);

            photos.Should().Equals(response);
        }

        [Fact]
        public async Task GetPhotos_Returns_EmptyCollection()
        {
            var photoDate = new DateTime(2018, 4, 30);
            var response = new MarsPhotoResponse();
                        

            _nasaApi.Setup(n => n.GetPhotos(It.IsAny<DateTime>())).ReturnsAsync(response);
            var photos = await _nasaApi.Object.GetPhotos(photoDate);

            photos.Photos.Equals(0);
        }        
    }	
}
