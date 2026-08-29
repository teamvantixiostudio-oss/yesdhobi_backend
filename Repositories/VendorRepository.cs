using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YesDhobi.Api.Data;
using YesDhobi.Api.Models;

namespace YesDhobi.Api.Repositories
{
    public interface IVendorRepository
    {
        Task<Vendor> CreateVendorAsync(Vendor vendor);
        Task<Vendor> GetVendorByIdAsync(Guid vendorId);
        Task<IEnumerable<Vendor>> GetVendorsAsync();
    }

    public class VendorRepository : IVendorRepository
    {
        private readonly YesDhobiDbContext _context;

        public VendorRepository(YesDhobiDbContext context)
        {
            _context = context;
        }

        public async Task<Vendor> CreateVendorAsync(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<Vendor> GetVendorByIdAsync(Guid vendorId)
        {
            return await _context.Vendors
                .Include(v => v.PersonalDetail)
                .Include(v => v.BusinessDetail)
                .Include(v => v.Location)
                .Include(v => v.Document)
                .Include(v => v.BankDetail)
                .Include(v => v.VendorServices).ThenInclude(vs => vs.Service)
                .Include(v => v.VendorEquipments).ThenInclude(ve => ve.Equipment)
                .Include(v => v.VendorServiceAreas).ThenInclude(vsa => vsa.Zone)
                .Include(v => v.VendorWorkingDays).ThenInclude(vwd => vwd.WorkingDay)
                .FirstOrDefaultAsync(v => v.Id == vendorId);
        }

        public async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            return await _context.Vendors
                .Include(v => v.PersonalDetail)
                .Include(v => v.BusinessDetail)
                .Include(v => v.Location)
                .Include(v => v.Document)
                .Include(v => v.BankDetail)
                .Include(v => v.VendorServices).ThenInclude(vs => vs.Service)
                .Include(v => v.VendorEquipments).ThenInclude(ve => ve.Equipment)
                .Include(v => v.VendorServiceAreas).ThenInclude(vsa => vsa.Zone)
                .Include(v => v.VendorWorkingDays).ThenInclude(vwd => vwd.WorkingDay)
                .ToListAsync();
        }
    }
}
