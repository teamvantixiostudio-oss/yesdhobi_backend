using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesDhobi.Api.Models;
using YesDhobi.Api.Models.DTOs;
using YesDhobi.Api.Repositories;

namespace YesDhobi.Api.Services
{
    public interface ICatalogService
    {
        Task<List<ServiceDto>> GetServicesAsync();
        Task<ServiceDto> CreateServiceAsync(ServiceDto dto);
        Task<ServiceDto> UpdateServiceAsync(int id, ServiceDto dto);
        Task DeleteServiceAsync(int id);

        Task<List<EquipmentDto>> GetEquipmentsAsync();
        Task<EquipmentDto> CreateEquipmentAsync(EquipmentDto dto);
        Task<EquipmentDto> UpdateEquipmentAsync(int id, EquipmentDto dto);
        Task DeleteEquipmentAsync(int id);

        Task<List<ServiceZoneDto>> GetServiceZonesAsync();
        Task<ServiceZoneDto> CreateServiceZoneAsync(ServiceZoneDto dto);
        Task<ServiceZoneDto> UpdateServiceZoneAsync(int id, ServiceZoneDto dto);
        Task DeleteServiceZoneAsync(int id);

        Task<List<WorkingDayDto>> GetWorkingDaysAsync();
        Task<WorkingDayDto> CreateWorkingDayAsync(WorkingDayDto dto);
        Task<WorkingDayDto> UpdateWorkingDayAsync(int id, WorkingDayDto dto);
        Task DeleteWorkingDayAsync(int id);
    }

    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;

        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
        }

        // Services
        public async Task<List<ServiceDto>> GetServicesAsync()
        {
            var services = await _repository.GetServicesAsync();
            return services.Select(s => new ServiceDto { Id = s.Id, Code = s.Code, Name = s.Name, Description = s.Description, Unit = s.Unit, DefaultPrice = s.DefaultPrice }).ToList();
        }
        public async Task<ServiceDto> CreateServiceAsync(ServiceDto dto)
        {
            var service = new Service { Code = dto.Code, Name = dto.Name, Description = dto.Description, Unit = dto.Unit, DefaultPrice = dto.DefaultPrice };
            await _repository.CreateServiceAsync(service);
            dto.Id = service.Id;
            return dto;
        }
        public async Task<ServiceDto> UpdateServiceAsync(int id, ServiceDto dto)
        {
            var service = await _repository.GetServiceByIdAsync(id);
            if (service == null) return null;
            service.Code = dto.Code; service.Name = dto.Name; service.Description = dto.Description; service.Unit = dto.Unit; service.DefaultPrice = dto.DefaultPrice;
            await _repository.UpdateServiceAsync(service);
            return dto;
        }
        public async Task DeleteServiceAsync(int id) => await _repository.DeleteServiceAsync(id);

        // Equipments
        public async Task<List<EquipmentDto>> GetEquipmentsAsync()
        {
            var equipments = await _repository.GetEquipmentsAsync();
            return equipments.Select(e => new EquipmentDto { Id = e.Id, Name = e.Name, Description = e.Description }).ToList();
        }
        public async Task<EquipmentDto> CreateEquipmentAsync(EquipmentDto dto)
        {
            var equipment = new Equipment { Name = dto.Name, Description = dto.Description };
            await _repository.CreateEquipmentAsync(equipment);
            dto.Id = equipment.Id;
            return dto;
        }
        public async Task<EquipmentDto> UpdateEquipmentAsync(int id, EquipmentDto dto)
        {
            var equipment = await _repository.GetEquipmentByIdAsync(id);
            if (equipment == null) return null;
            equipment.Name = dto.Name; equipment.Description = dto.Description;
            await _repository.UpdateEquipmentAsync(equipment);
            return dto;
        }
        public async Task DeleteEquipmentAsync(int id) => await _repository.DeleteEquipmentAsync(id);

        // ServiceZones
        public async Task<List<ServiceZoneDto>> GetServiceZonesAsync()
        {
            var zones = await _repository.GetServiceZonesAsync();
            return zones.Select(z => new ServiceZoneDto { Id = z.Id, ZoneName = z.ZoneName, City = z.City, State = z.State }).ToList();
        }
        public async Task<ServiceZoneDto> CreateServiceZoneAsync(ServiceZoneDto dto)
        {
            var zone = new ServiceZone { ZoneName = dto.ZoneName, City = dto.City, State = dto.State };
            await _repository.CreateServiceZoneAsync(zone);
            dto.Id = zone.Id;
            return dto;
        }
        public async Task<ServiceZoneDto> UpdateServiceZoneAsync(int id, ServiceZoneDto dto)
        {
            var zone = await _repository.GetServiceZoneByIdAsync(id);
            if (zone == null) return null;
            zone.ZoneName = dto.ZoneName; zone.City = dto.City; zone.State = dto.State;
            await _repository.UpdateServiceZoneAsync(zone);
            return dto;
        }
        public async Task DeleteServiceZoneAsync(int id) => await _repository.DeleteServiceZoneAsync(id);

        // WorkingDays
        public async Task<List<WorkingDayDto>> GetWorkingDaysAsync()
        {
            var days = await _repository.GetWorkingDaysAsync();
            return days.Select(d => new WorkingDayDto { Id = d.Id, DayName = d.DayName, DayCode = d.DayCode }).ToList();
        }
        public async Task<WorkingDayDto> CreateWorkingDayAsync(WorkingDayDto dto)
        {
            var day = new WorkingDay { Id = dto.Id, DayName = dto.DayName, DayCode = dto.DayCode }; // Note: ID might be manually assigned per schema
            await _repository.CreateWorkingDayAsync(day);
            return dto;
        }
        public async Task<WorkingDayDto> UpdateWorkingDayAsync(int id, WorkingDayDto dto)
        {
            var day = await _repository.GetWorkingDayByIdAsync(id);
            if (day == null) return null;
            day.DayName = dto.DayName; day.DayCode = dto.DayCode;
            await _repository.UpdateWorkingDayAsync(day);
            return dto;
        }
        public async Task DeleteWorkingDayAsync(int id) => await _repository.DeleteWorkingDayAsync(id);
    }
}
