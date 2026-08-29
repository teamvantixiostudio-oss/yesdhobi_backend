using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("vendor_bank_details")]
    public class VendorBankDetail
    {
        [Key]
        [Column("vendor_id")]
        public Guid VendorId { get; set; }

        [Required]
        [StringLength(150)]
        [Column("bank_account_holder_name")]
        public string BankAccountHolderName { get; set; }

        [Required]
        [StringLength(150)]
        [Column("bank_name")]
        public string BankName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("bank_account_number")]
        public string BankAccountNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Column("bank_ifsc_code")]
        public string BankIfscCode { get; set; }

        [Required]
        [StringLength(20)]
        [Column("bank_account_type")]
        public string BankAccountType { get; set; }

        [Required]
        [Column("cancelled_cheque_passbook_url")]
        public string CancelledChequePassbookUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
