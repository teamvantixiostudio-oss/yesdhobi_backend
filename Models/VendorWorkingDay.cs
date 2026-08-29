using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_working_days")]
    public class VendorWorkingDay
    {
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Column("day_id")]
        public int DayId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
        [ForeignKey(nameof(DayId))]
        public WorkingDay WorkingDay { get; set; }
    }
}
