using Microsoft.EntityFrameworkCore;
using YesDhobi.Api.Models;

namespace YesDhobi.Api.Data
{
    public class YesDhobiDbContext : DbContext
    {
        public YesDhobiDbContext(DbContextOptions<YesDhobiDbContext> options) : base(options)
        {
        }

        // Master Catalogs
        public DbSet<Service> Services { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<ServiceZone> ServiceZones { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }

        // Core Vendor
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorPersonalDetail> VendorPersonalDetails { get; set; }
        public DbSet<VendorBusinessDetail> VendorBusinessDetails { get; set; }
        public DbSet<VendorLocation> VendorLocations { get; set; }
        public DbSet<VendorDocument> VendorDocuments { get; set; }
        public DbSet<VendorBankDetail> VendorBankDetails { get; set; }

        // Junction Tables
        public DbSet<VendorService> VendorServices { get; set; }
        public DbSet<VendorEquipment> VendorEquipments { get; set; }
        public DbSet<VendorServiceArea> VendorServiceAreas { get; set; }
        public DbSet<VendorWorkingDay> VendorWorkingDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Keys for Junction Tables
            modelBuilder.Entity<VendorService>()
                .HasKey(vs => new { vs.VendorId, vs.ServiceId });

            modelBuilder.Entity<VendorEquipment>()
                .HasKey(ve => new { ve.VendorId, ve.EquipmentId });

            modelBuilder.Entity<VendorServiceArea>()
                .HasKey(vsa => new { vsa.VendorId, vsa.ZoneId });

            modelBuilder.Entity<VendorWorkingDay>()
                .HasKey(vwd => new { vwd.VendorId, vwd.DayId });

            // Ensure 1-to-1 relationships and prevent cascade delete issues if needed
            // By default EF Core will configure cascade delete for required relationships, which matches our SQL schema.

            // Optional: View mapping if we want to query it
            // modelBuilder.Entity<ViewVendorRegistration>().ToView("view_vendor_registrations").HasNoKey();
        }
    }
}
