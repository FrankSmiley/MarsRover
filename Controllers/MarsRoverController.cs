using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using NASA.Api.Models;
using NASA.Api.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NASA.Api.Controllers
{
    [ApiController]
    [Route("photos")]
    public class MarsRoverController : ControllerBase
    {
        private readonly INasaApi _nasaApi;

        public MarsRoverController(INasaApi nasaApi)
        {
            _nasaApi = nasaApi;
        }
        
        [HttpGet]
        public async Task<IActionResult> Photos(DateTime photoDate)
        {           

            try
            { 
                var response = await _nasaApi.GetPhotos(photoDate);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
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
