using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDhobi.Api.Models.DTOs;
using YesDhobi.Api.Services;

namespace YesDhobi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _service;

        public VendorsController(IVendorService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] VendorRegistrationDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.RegisterVendorAsync(request);
                return CreatedAtAction(nameof(GetVendor), new { id = result.Id }, new { result.Id, result.RegistrationId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.ToString() });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendor(Guid id)
        {
            var vendor = await _service.GetVendorByIdAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            try
            {
                var vendors = await _service.GetAllVendorsAsync();
                return Ok(vendors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving vendors.", details = ex.Message });
            }
        }
    }
}
