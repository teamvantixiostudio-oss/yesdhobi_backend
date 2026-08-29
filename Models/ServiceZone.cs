using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("service_zones")]
    public class ServiceZone
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("zone_name")]
        public string ZoneName { get; set; }

        [StringLength(100)]
        [Column("city")]
        public string City { get; set; } = "New Delhi";

        [StringLength(100)]
        [Column("state")]
        public string State { get; set; } = "Delhi";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
