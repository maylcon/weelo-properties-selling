﻿using AutoWrapper.Wrappers;
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

        [HttpPost("createProperty")]
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
                return BadRequest(new ApiResponse("Query error!", ex.Message, 400));
            }
        }

        [HttpPut("updateProperty")]
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

                await _propertyService.UpdateProperty(updateRequest);

                return Ok(new ApiResponse("Query done!", "Property update", 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex.Message, 400));
            }
        }

        [HttpGet("fetchPropertyByFilters")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAllByFilters ([FromQuery] SearchProperty filter)
        {

            var properties = this._propertyService.GetAllPropertiesByFilters(filter);

            return Ok(properties);

        }

        [HttpPut("updatePriceProperty")]
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

                await _propertyService.UpdatePriceProperty(updateRequest);

                return Ok(new ApiResponse("Query done!", "Price property update", 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex.Message, 400));
            }
        }
    }
}
