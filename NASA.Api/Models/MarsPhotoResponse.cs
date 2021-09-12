using System.Collections.Generic;

namespace NASA.Api.Models
{
    public class MarsPhotoResponse
    {
        public MarsPhotoResponse()
        {
            Photos = new List<Photo>();
        }
        public IEnumerable<Photo> Photos { get; set; }
    }
}
