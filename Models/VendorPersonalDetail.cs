using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_personal_details")]
    public class VendorPersonalDetail
    {
        [Key]
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Required]
        [StringLength(150)]
        [Column("full_name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        [Column("mobile_number")]
        public string MobileNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Column("whatsapp_number")]
        public string WhatsappNumber { get; set; }

        [Column("whatsapp_same_as_mobile")]
        public bool WhatsappSameAsMobile { get; set; } = true;

        [Required]
        [StringLength(255)]
        [Column("email_address")]
        public string EmailAddress { get; set; }

        [Column("date_of_birth", TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        [Column("gender")]
        public string Gender { get; set; }

        [Required]
        [StringLength(10)]
        [Column("personal_pincode")]
        public string PersonalPincode { get; set; }

        [Required]
        [StringLength(100)]
        [Column("personal_city")]
        public string PersonalCity { get; set; }

        [Required]
        [StringLength(100)]
        [Column("personal_state")]
        public string PersonalState { get; set; }

        [Required]
        [Column("current_address")]
        public string CurrentAddress { get; set; }

        [Required]
        [StringLength(12)]
        [Column("aadhaar_number")]
        public string AadhaarNumber { get; set; }

        [Column("profile_photo_url")]
        public string ProfilePhotoUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
