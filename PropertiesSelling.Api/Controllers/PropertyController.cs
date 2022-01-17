using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertiesSelling.Core.Definitions.Service;
using PropertiesSelling.Core.Dtos.Property;
using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PropertiesSelling.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProperty(CreateProperty createRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse("Query error! - Model is not valid", createRequest, 400));
                }

                var responseCreate = await _propertyService.CreateProperty(createRequest);

                return Ok(new ApiResponse("Query done!", responseCreate, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex, 400));
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProperty (UpdateProperty updateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse("Query error! - Model is not valid", updateRequest, 400));
                }

                var responseUpdate = await _propertyService.UpdateProperty(updateRequest);

                return Ok(new ApiResponse("Query done!", responseUpdate, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex, 400));
            }
        }

        [HttpGet("Filter")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllByFilters ([FromQuery] SearchProperty filter)
        {

            var properties = this._propertyService.GetAllPropertiesByFilters(filter);

            return Ok(properties);

        }

        [HttpPut("Price")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePrice (UpdatePriceProperty updateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse("Query error! - Model is not valid", updateRequest, 400));
                }

                var responseUpdate = await _propertyService.UpdatePriceProperty(updateRequest);

                return Ok(new ApiResponse("Query done!", responseUpdate, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex, 400));
            }
        }
    }
}
