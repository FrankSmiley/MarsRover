using Microsoft.AspNetCore.Mvc;
using NASA.Api.Services;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NASA.Api.Controllers
{
    [ApiController]    
    public class MarsRoverController : ControllerBase
    {
        private readonly INasaApi _nasaApi;

        public MarsRoverController(INasaApi nasaApi)
        {
            _nasaApi = nasaApi;
        }

        [HttpGet("photos")]
        public async Task<IActionResult> Photos(DateTime photoDate)
        {           

            try
            {
                Log.Information("Getting photos for {photoDate}", photoDate);               

                var response = await _nasaApi.GetPhotos(photoDate);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                Log.Error("Mars Rover Get exception {ex}", ex.Message);

                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Type = HttpStatusCode.BadRequest.ToString(),
                    Title = $"An argument exception happened on argument {ex.ParamName}",
                    Detail = ex.Message,
                    Instance = HttpContext.Request.Path
                };

                return BadRequest(problemDetails);
            }
        }
    }
}
