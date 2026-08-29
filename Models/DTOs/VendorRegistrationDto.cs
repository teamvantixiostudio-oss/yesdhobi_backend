using System;
using System.Collections.Generic;

namespace YesDhobi.Api.Models.DTOs
{
    public class VendorRegistrationDto
    {
        public bool AgreedToPartnerTerms { get; set; }
        public bool AgreedToPaymentTerms { get; set; }
        public bool ConsentedToBackgroundVerification { get; set; }

        public VendorPersonalDetailDto PersonalDetails { get; set; }
        public VendorBusinessDetailDto BusinessDetails { get; set; }
        public VendorLocationDto Location { get; set; }
        public VendorBankDetailDto BankDetails { get; set; }
        public VendorDocumentDto Documents { get; set; }

        public List<VendorServiceDto> Services { get; set; }
        public List<VendorEquipmentDto> Equipments { get; set; }
        public List<int> ServiceAreaIds { get; set; }
        public List<int> WorkingDayIds { get; set; }
    }

    public class VendorPersonalDetailDto
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public bool WhatsappSameAsMobile { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PersonalPincode { get; set; }
        public string PersonalCity { get; set; }
        public string PersonalState { get; set; }
        public string CurrentAddress { get; set; }
        public string AadhaarNumber { get; set; }
        public string ProfilePhotoUrl { get; set; }
    }

    public class VendorBusinessDetailDto
    {
        public string ShopName { get; set; }
        public bool IsExistingFranchise { get; set; }
        public string FranchiseName { get; set; }
        public string BusinessType { get; set; }
        public int YearsOfExperience { get; set; }
        public int NumberOfWorkers { get; set; }
        public bool HasOwnShop { get; set; }
        public decimal ShopAreaSqft { get; set; }
        public int NumberOfWashingMachines { get; set; }
        public decimal DailyCapacityKg { get; set; }
        public string GstNumber { get; set; }
        public string PanNumber { get; set; }
        public string StandardDeliveryTime { get; set; }
        public bool OffersExpressDelivery { get; set; }
        public decimal ExpressDeliveryChargePercentage { get; set; }
    }

    public class VendorLocationDto
    {
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal ServiceRadiusKm { get; set; }
        public string WorkingHoursFrom { get; set; } // string formatted "HH:mm:ss"
        public string WorkingHoursTo { get; set; } // string formatted "HH:mm:ss"
    }

    public class VendorBankDetailDto
    {
        public string BankAccountHolderName { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIfscCode { get; set; }
        public string BankAccountType { get; set; }
        public string CancelledChequePassbookUrl { get; set; }
    }

    public class VendorDocumentDto
    {
        public string AadhaarFrontUrl { get; set; }
        public string AadhaarBackUrl { get; set; }
        public string PanFrontUrl { get; set; }
        public string ShopPhotoUrl { get; set; }
        public string GstCertificateUrl { get; set; }
        public string TradeLicenseUrl { get; set; }
        public string LabourLicenseUrl { get; set; }
    }

    public class VendorServiceDto
    {
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class VendorEquipmentDto
    {
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}
