using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_locations")]
    public class VendorLocation
    {
        [Key]
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Required]
        [Column("pickup_address")]
        public string PickupAddress { get; set; }

        [StringLength(200)]
        [Column("landmark")]
        public string Landmark { get; set; }

        [Required]
        [StringLength(10)]
        [Column("pincode")]
        public string Pincode { get; set; }

        [Required]
        [StringLength(100)]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        [Column("state")]
        public string State { get; set; }

        [Column("latitude", TypeName = "decimal(10, 7)")]
        public decimal? Latitude { get; set; }

        [Column("longitude", TypeName = "decimal(10, 7)")]
        public decimal? Longitude { get; set; }

        [Column("service_radius_km", TypeName = "decimal(5, 2)")]
        public decimal ServiceRadiusKm { get; set; } = 5.0m;

        [Column("working_hours_from")]
        public TimeSpan? WorkingHoursFrom { get; set; } = new TimeSpan(8, 0, 0);

        [Column("working_hours_to")]
        public TimeSpan? WorkingHoursTo { get; set; } = new TimeSpan(19, 0, 0);

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
