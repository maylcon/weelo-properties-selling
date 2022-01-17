using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertiesSelling.Core.Definitions.Service;
using PropertiesSelling.Core.Dtos.PropertyImage;
using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PropertiesSelling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageService _propertyImageService;

        public PropertyImageController(IPropertyImageService propertyImageService)
        {
            _propertyImageService = propertyImageService;
        }

        [HttpPost("AddImage")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddImageProperty ([FromForm] CreatePropertyImage createRequest, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse("Query error! - Model is not valid", createRequest, 400));
                }

                if (file == null || !file.ContentType.Contains("image"))
                {
                    return BadRequest(new ApiResponse("Image error! - Image is required", file, 400));
                }

                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    createRequest.File = ms.ToArray();
                }

                var responseCreateImage = await _propertyImageService.InsertImageAsync(createRequest);

                return Ok(new ApiResponse("Query done!", responseCreateImage, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex, 400));
            }

            
        }
    }
}
