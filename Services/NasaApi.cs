using Flurl;
using Flurl.Http;
using NASA.Api.Models;
using System;
using System.Threading.Tasks;

namespace NASA.Api.Services
{
    public class NasaApi : INasaApi
    {
        public async Task<MarsPhotoResponse> GetPhotos(DateTime date)
        {
            var response = await "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos"
               .SetQueryParam("earth_date", DateTime.Now.AddYears(-6))
               .SetQueryParam("api_key", "DEMO_KEY")
               .GetJsonAsync<MarsPhotoResponse>();

            return response;
        }
    }
}
