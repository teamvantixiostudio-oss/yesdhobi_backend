using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_documents")]
    public class VendorDocument
    {
        [Key]
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Required]
        [Column("aadhaar_front_url")]
        public string AadhaarFrontUrl { get; set; }

        [Required]
        [Column("aadhaar_back_url")]
        public string AadhaarBackUrl { get; set; }

        [Required]
        [Column("pan_front_url")]
        public string PanFrontUrl { get; set; }

        [Column("shop_photo_url")]
        public string ShopPhotoUrl { get; set; }

        [Column("gst_certificate_url")]
        public string GstCertificateUrl { get; set; }

        [Column("trade_license_url")]
        public string TradeLicenseUrl { get; set; }

        [Column("labour_license_url")]
        public string LabourLicenseUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
