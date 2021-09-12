using System;

namespace NASA.Api.Models
{    
    public class Photo
    {
        public int Id { get; set; }

        public int Sol { get; set; }

        public string Img_src { get; set; }

        public DateTime Earth_Date { get; set; }     

        public Camera Camera { get; set; }

        public Rover Rover { get; set; }
    }
}
