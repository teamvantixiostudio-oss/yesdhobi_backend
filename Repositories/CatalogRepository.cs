using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YesDhobi.Api.Data;
using YesDhobi.Api.Models;

namespace YesDhobi.Api.Repositories
{
    public interface ICatalogRepository
    {
        Task<List<Service>> GetServicesAsync();
        Task<Service> GetServiceByIdAsync(int id);
        Task<Service> CreateServiceAsync(Service service);
        Task<Service> UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);

        Task<List<Equipment>> GetEquipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task<Equipment> UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);

        Task<List<ServiceZone>> GetServiceZonesAsync();
        Task<ServiceZone> GetServiceZoneByIdAsync(int id);
        Task<ServiceZone> CreateServiceZoneAsync(ServiceZone zone);
        Task<ServiceZone> UpdateServiceZoneAsync(ServiceZone zone);
        Task DeleteServiceZoneAsync(int id);

        Task<List<WorkingDay>> GetWorkingDaysAsync();
        Task<WorkingDay> GetWorkingDayByIdAsync(int id);
        Task<WorkingDay> CreateWorkingDayAsync(WorkingDay day);
        Task<WorkingDay> UpdateWorkingDayAsync(WorkingDay day);
        Task DeleteWorkingDayAsync(int id);
    }

    public class CatalogRepository : ICatalogRepository
    {
        private readonly YesDhobiDbContext _context;

        public CatalogRepository(YesDhobiDbContext context)
        {
            _context = context;
        }

        // Services
        public async Task<List<Service>> GetServicesAsync() => await _context.Services.ToListAsync();
        public async Task<Service> GetServiceByIdAsync(int id) => await _context.Services.FindAsync(id);
        public async Task<Service> CreateServiceAsync(Service service) { _context.Services.Add(service); await _context.SaveChangesAsync(); return service; }
        public async Task<Service> UpdateServiceAsync(Service service) { _context.Services.Update(service); await _context.SaveChangesAsync(); return service; }
        public async Task DeleteServiceAsync(int id) { var item = await _context.Services.FindAsync(id); if (item != null) { _context.Services.Remove(item); await _context.SaveChangesAsync(); } }

        // Equipments
        public async Task<List<Equipment>> GetEquipmentsAsync() => await _context.Equipments.ToListAsync();
        public async Task<Equipment> GetEquipmentByIdAsync(int id) => await _context.Equipments.FindAsync(id);
        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment) { _context.Equipments.Add(equipment); await _context.SaveChangesAsync(); return equipment; }
        public async Task<Equipment> UpdateEquipmentAsync(Equipment equipment) { _context.Equipments.Update(equipment); await _context.SaveChangesAsync(); return equipment; }
        public async Task DeleteEquipmentAsync(int id) { var item = await _context.Equipments.FindAsync(id); if (item != null) { _context.Equipments.Remove(item); await _context.SaveChangesAsync(); } }

        // ServiceZones
        public async Task<List<ServiceZone>> GetServiceZonesAsync() => await _context.ServiceZones.ToListAsync();
        public async Task<ServiceZone> GetServiceZoneByIdAsync(int id) => await _context.ServiceZones.FindAsync(id);
        public async Task<ServiceZone> CreateServiceZoneAsync(ServiceZone zone) { _context.ServiceZones.Add(zone); await _context.SaveChangesAsync(); return zone; }
        public async Task<ServiceZone> UpdateServiceZoneAsync(ServiceZone zone) { _context.ServiceZones.Update(zone); await _context.SaveChangesAsync(); return zone; }
        public async Task DeleteServiceZoneAsync(int id) { var item = await _context.ServiceZones.FindAsync(id); if (item != null) { _context.ServiceZones.Remove(item); await _context.SaveChangesAsync(); } }

        // WorkingDays
        public async Task<List<WorkingDay>> GetWorkingDaysAsync() => await _context.WorkingDays.ToListAsync();
        public async Task<WorkingDay> GetWorkingDayByIdAsync(int id) => await _context.WorkingDays.FindAsync(id);
        public async Task<WorkingDay> CreateWorkingDayAsync(WorkingDay day) { _context.WorkingDays.Add(day); await _context.SaveChangesAsync(); return day; }
        public async Task<WorkingDay> UpdateWorkingDayAsync(WorkingDay day) { _context.WorkingDays.Update(day); await _context.SaveChangesAsync(); return day; }
        public async Task DeleteWorkingDayAsync(int id) { var item = await _context.WorkingDays.FindAsync(id); if (item != null) { _context.WorkingDays.Remove(item); await _context.SaveChangesAsync(); } }
    }
}
