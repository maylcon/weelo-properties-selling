using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertiesSelling.Core.Definitions.Service;
using PropertiesSelling.Core.Dtos;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PropertiesSelling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateOwner createRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse("Query error! - Model is not valid", createRequest, 400));
                }

                var responseCreate = await _ownerService.CreateOwner(createRequest);

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
        public async Task<IActionResult> Put(UpdateOwner updateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse("Query error! - Model is not valid", updateRequest, 400));
                }

                var responseUpdate = await _ownerService.UpdateOwner(updateRequest);

                return Ok(new ApiResponse("Query done!", responseUpdate, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex, 400));
            }

        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var responseGetOwners = await _ownerService.GetAllOwner();
                return Ok(new ApiResponse("Query done!", responseGetOwners, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse("Query error!", ex, 400));
            }
        }

    }
}

