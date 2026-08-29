using System.ComponentModel.DataAnnotations;

namespace YesDhobi.Api.Models.DTOs
{
    public class VendorSendOtpRequestDto
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string MobileNumber { get; set; }
    }

    public class VendorVerifyOtpRequestDto
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string MobileNumber { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "OTP must be 4-6 digits.")]
        public string Otp { get; set; }
    }

    public class VendorLoginResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public VendorAuthProfileDto Vendor { get; set; }
    }

    public class VendorAuthProfileDto
    {
        public Guid Id { get; set; }
        public string RegistrationId { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string ShopName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
