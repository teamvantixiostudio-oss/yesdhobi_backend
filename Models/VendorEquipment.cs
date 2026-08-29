using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_equipments")]
    public class VendorEquipment
    {
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Column("equipment_id")]
        public int EquipmentId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; } = 1;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; }
    }
}
