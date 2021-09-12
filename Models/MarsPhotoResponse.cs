using System.Collections.Generic;

namespace NASA.Api.Models
{
    public class MarsPhotoResponse
    {
        MarsPhotoResponse()
        {
            Photos = new List<Photo>();
        }
        public IEnumerable<Photo> Photos { get; set; }
    }
}
