using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendors")]
    public class Vendor
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        [Column("registration_id")]
        public string RegistrationId { get; set; }

        [StringLength(20)]
        [Column("status")]
        public string Status { get; set; } = "PENDING";

        [Column("agreed_to_partner_terms")]
        public bool AgreedToPartnerTerms { get; set; }

        [Column("agreed_to_payment_terms")]
        public bool AgreedToPaymentTerms { get; set; }

        [Column("consented_to_background_verification")]
        public bool ConsentedToBackgroundVerification { get; set; }

        [Column("submitted_at")]
        public DateTime? SubmittedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public VendorPersonalDetail PersonalDetail { get; set; }
        public VendorBusinessDetail BusinessDetail { get; set; }
        public VendorLocation Location { get; set; }
        public VendorDocument Document { get; set; }
        public VendorBankDetail BankDetail { get; set; }

        public ICollection<VendorService> VendorServices { get; set; }
        public ICollection<VendorEquipment> VendorEquipments { get; set; }
        public ICollection<VendorServiceArea> VendorServiceAreas { get; set; }
        public ICollection<VendorWorkingDay> VendorWorkingDays { get; set; }
    }
}
