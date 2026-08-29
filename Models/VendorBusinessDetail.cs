using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_business_details")]
    public class VendorBusinessDetail
    {
        [Key]
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Required]
        [StringLength(200)]
        [Column("shop_name")]
        public string ShopName { get; set; }

        [Column("is_existing_franchise")]
        public bool IsExistingFranchise { get; set; } = false;

        [StringLength(150)]
        [Column("franchise_name")]
        public string FranchiseName { get; set; }

        [Required]
        [StringLength(100)]
        [Column("business_type")]
        public string BusinessType { get; set; }

        [Column("years_of_experience")]
        public int YearsOfExperience { get; set; } = 0;

        [Column("number_of_workers")]
        public int NumberOfWorkers { get; set; } = 0;

        [Column("has_own_shop")]
        public bool HasOwnShop { get; set; } = true;

        [Column("shop_area_sqft", TypeName = "decimal(10, 2)")]
        public decimal ShopAreaSqft { get; set; } = 0.00m;

        [Column("number_of_washing_machines")]
        public int NumberOfWashingMachines { get; set; } = 0;

        [Column("daily_capacity_kg", TypeName = "decimal(10, 2)")]
        public decimal DailyCapacityKg { get; set; } = 0.00m;

        [StringLength(15)]
        [Column("gst_number")]
        public string GstNumber { get; set; }

        [Required]
        [StringLength(10)]
        [Column("pan_number")]
        public string PanNumber { get; set; }

        [StringLength(50)]
        [Column("standard_delivery_time")]
        public string StandardDeliveryTime { get; set; } = "48 Hours";

        [Column("offers_express_delivery")]
        public bool OffersExpressDelivery { get; set; } = false;

        [Column("express_delivery_charge_percentage", TypeName = "decimal(5, 2)")]
        public decimal ExpressDeliveryChargePercentage { get; set; } = 0.00m;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
