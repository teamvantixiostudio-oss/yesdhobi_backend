using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_service_areas")]
    public class VendorServiceArea
    {
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Column("zone_id")]
        public int ZoneId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
        [ForeignKey(nameof(ZoneId))]
        public ServiceZone Zone { get; set; }
    }
}
