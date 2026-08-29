using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_services")]
    public class VendorService
    {
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Column("service_id")]
        public int ServiceId { get; set; }

        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; } = 0.00m;

        [Column("is_enabled")]
        public bool IsEnabled { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
    }
}
