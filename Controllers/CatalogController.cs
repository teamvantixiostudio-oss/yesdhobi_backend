using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDhobi.Api.Models.DTOs;
using YesDhobi.Api.Services;

namespace YesDhobi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            _service = service;
        }

        // Services
        [HttpGet("services")]
        public async Task<IActionResult> GetServices() => Ok(await _service.GetServicesAsync());
        
        [HttpPost("services")]
        public async Task<IActionResult> CreateService([FromBody] ServiceDto dto) => Ok(await _service.CreateServiceAsync(dto));
        
        [HttpPut("services/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceDto dto)
        {
            var result = await _service.UpdateServiceAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        [HttpDelete("services/{id}")]
        public async Task<IActionResult> DeleteService(int id) { await _service.DeleteServiceAsync(id); return NoContent(); }


        // Equipments
        [HttpGet("equipments")]
        public async Task<IActionResult> GetEquipments() => Ok(await _service.GetEquipmentsAsync());
        
        [HttpPost("equipments")]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentDto dto) => Ok(await _service.CreateEquipmentAsync(dto));
        
        [HttpPut("equipments/{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, [FromBody] EquipmentDto dto)
        {
            var result = await _service.UpdateEquipmentAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        [HttpDelete("equipments/{id}")]
        public async Task<IActionResult> DeleteEquipment(int id) { await _service.DeleteEquipmentAsync(id); return NoContent(); }


        // Zones
        [HttpGet("zones")]
        public async Task<IActionResult> GetZones() => Ok(await _service.GetServiceZonesAsync());
        
        [HttpPost("zones")]
        public async Task<IActionResult> CreateZone([FromBody] ServiceZoneDto dto) => Ok(await _service.CreateServiceZoneAsync(dto));
        
        [HttpPut("zones/{id}")]
        public async Task<IActionResult> UpdateZone(int id, [FromBody] ServiceZoneDto dto)
        {
            var result = await _service.UpdateServiceZoneAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        [HttpDelete("zones/{id}")]
        public async Task<IActionResult> DeleteZone(int id) { await _service.DeleteServiceZoneAsync(id); return NoContent(); }


        // Working Days
        [HttpGet("working-days")]
        public async Task<IActionResult> GetWorkingDays() => Ok(await _service.GetWorkingDaysAsync());
        
        [HttpPost("working-days")]
        public async Task<IActionResult> CreateWorkingDay([FromBody] WorkingDayDto dto) => Ok(await _service.CreateWorkingDayAsync(dto));
        
        [HttpPut("working-days/{id}")]
        public async Task<IActionResult> UpdateWorkingDay(int id, [FromBody] WorkingDayDto dto)
        {
            var result = await _service.UpdateWorkingDayAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        [HttpDelete("working-days/{id}")]
        public async Task<IActionResult> DeleteWorkingDay(int id) { await _service.DeleteWorkingDayAsync(id); return NoContent(); }
    }
}
