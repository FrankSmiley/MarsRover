using NASA.Api.Models;
using System;
using System.Threading.Tasks;

namespace NASA.Api.Services
{
    public interface INasaApi
    {
        Task<MarsPhotoResponse> GetPhotos(DateTime date);
    }
}
