using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesDhobi.Api.Models;
using YesDhobi.Api.Models.DTOs;
using YesDhobi.Api.Repositories;

namespace YesDhobi.Api.Services
{
    public interface IVendorService
    {
        Task<Vendor> RegisterVendorAsync(VendorRegistrationDto dto);
        Task<Vendor> GetVendorByIdAsync(Guid id);
        Task<IEnumerable<Vendor>> GetAllVendorsAsync();
    }

    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _repository;

        public VendorService(IVendorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Vendor> RegisterVendorAsync(VendorRegistrationDto dto)
        {
            var vendorId = Guid.NewGuid();
            var registrationId = $"VEND-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}";

            var vendor = new Vendor
            {
                Id = vendorId,
                RegistrationId = registrationId,
                Status = "PENDING",
                AgreedToPartnerTerms = dto.AgreedToPartnerTerms,
                AgreedToPaymentTerms = dto.AgreedToPaymentTerms,
                ConsentedToBackgroundVerification = dto.ConsentedToBackgroundVerification,
                SubmittedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (dto.PersonalDetails != null)
            {
                vendor.PersonalDetail = new VendorPersonalDetail
                {
                    VendorId = vendorId,
                    FullName = dto.PersonalDetails.FullName,
                    MobileNumber = dto.PersonalDetails.MobileNumber,
                    WhatsappNumber = dto.PersonalDetails.WhatsappNumber,
                    WhatsappSameAsMobile = dto.PersonalDetails.WhatsappSameAsMobile,
                    EmailAddress = dto.PersonalDetails.EmailAddress,
                    DateOfBirth = dto.PersonalDetails.DateOfBirth,
                    Gender = dto.PersonalDetails.Gender,
                    PersonalPincode = dto.PersonalDetails.PersonalPincode,
                    PersonalCity = dto.PersonalDetails.PersonalCity,
                    PersonalState = dto.PersonalDetails.PersonalState,
                    CurrentAddress = dto.PersonalDetails.CurrentAddress,
                    AadhaarNumber = dto.PersonalDetails.AadhaarNumber,
                    ProfilePhotoUrl = dto.PersonalDetails.ProfilePhotoUrl
                };
            }

            if (dto.BusinessDetails != null)
            {
                vendor.BusinessDetail = new VendorBusinessDetail
                {
                    VendorId = vendorId,
                    ShopName = dto.BusinessDetails.ShopName,
                    IsExistingFranchise = dto.BusinessDetails.IsExistingFranchise,
                    FranchiseName = dto.BusinessDetails.FranchiseName,
                    BusinessType = dto.BusinessDetails.BusinessType,
                    YearsOfExperience = dto.BusinessDetails.YearsOfExperience,
                    NumberOfWorkers = dto.BusinessDetails.NumberOfWorkers,
                    HasOwnShop = dto.BusinessDetails.HasOwnShop,
                    ShopAreaSqft = dto.BusinessDetails.ShopAreaSqft,
                    NumberOfWashingMachines = dto.BusinessDetails.NumberOfWashingMachines,
                    DailyCapacityKg = dto.BusinessDetails.DailyCapacityKg,
                    GstNumber = dto.BusinessDetails.GstNumber,
                    PanNumber = dto.BusinessDetails.PanNumber,
                    StandardDeliveryTime = dto.BusinessDetails.StandardDeliveryTime,
                    OffersExpressDelivery = dto.BusinessDetails.OffersExpressDelivery,
                    ExpressDeliveryChargePercentage = dto.BusinessDetails.ExpressDeliveryChargePercentage
                };
            }

            if (dto.Location != null)
            {
                TimeSpan? whFrom = null;
                if (TimeSpan.TryParse(dto.Location.WorkingHoursFrom, out var pf)) whFrom = pf;

                TimeSpan? whTo = null;
                if (TimeSpan.TryParse(dto.Location.WorkingHoursTo, out var pt)) whTo = pt;

                vendor.Location = new VendorLocation
                {
                    VendorId = vendorId,
                    PickupAddress = dto.Location.PickupAddress,
                    Landmark = dto.Location.Landmark,
                    Pincode = dto.Location.Pincode,
                    City = dto.Location.City,
                    State = dto.Location.State,
                    Latitude = dto.Location.Latitude,
                    Longitude = dto.Location.Longitude,
                    ServiceRadiusKm = dto.Location.ServiceRadiusKm,
                    WorkingHoursFrom = whFrom,
                    WorkingHoursTo = whTo
                };
            }

            if (dto.BankDetails != null)
            {
                vendor.BankDetail = new VendorBankDetail
                {
                    VendorId = vendorId,
                    BankAccountHolderName = dto.BankDetails.BankAccountHolderName,
                    BankName = dto.BankDetails.BankName,
                    BankAccountNumber = dto.BankDetails.BankAccountNumber,
                    BankIfscCode = dto.BankDetails.BankIfscCode,
                    BankAccountType = dto.BankDetails.BankAccountType,
                    CancelledChequePassbookUrl = dto.BankDetails.CancelledChequePassbookUrl
                };
            }

            if (dto.Documents != null)
            {
                vendor.Document = new VendorDocument
                {
                    VendorId = vendorId,
                    AadhaarFrontUrl = dto.Documents.AadhaarFrontUrl,
                    AadhaarBackUrl = dto.Documents.AadhaarBackUrl,
                    PanFrontUrl = dto.Documents.PanFrontUrl,
                    ShopPhotoUrl = dto.Documents.ShopPhotoUrl,
                    GstCertificateUrl = dto.Documents.GstCertificateUrl,
                    TradeLicenseUrl = dto.Documents.TradeLicenseUrl,
                    LabourLicenseUrl = dto.Documents.LabourLicenseUrl
                };
            }

            if (dto.Services != null)
            {
                vendor.VendorServices = dto.Services.Select(s => new Models.VendorService
                {
                    VendorId = vendorId,
                    ServiceId = s.ServiceId,
                    Price = s.Price,
                    IsEnabled = s.IsEnabled
                }).ToList();
            }

            if (dto.Equipments != null)
            {
                vendor.VendorEquipments = dto.Equipments.Select(e => new VendorEquipment
                {
                    VendorId = vendorId,
                    EquipmentId = e.EquipmentId,
                    Quantity = e.Quantity
                }).ToList();
            }

            if (dto.ServiceAreaIds != null)
            {
                vendor.VendorServiceAreas = dto.ServiceAreaIds.Select(zId => new VendorServiceArea
                {
                    VendorId = vendorId,
                    ZoneId = zId
                }).ToList();
            }

            if (dto.WorkingDayIds != null)
            {
                vendor.VendorWorkingDays = dto.WorkingDayIds.Select(dId => new VendorWorkingDay
                {
                    VendorId = vendorId,
                    DayId = dId
                }).ToList();
            }

            return await _repository.CreateVendorAsync(vendor);
        }

        public async Task<Vendor> GetVendorByIdAsync(Guid id)
        {
            return await _repository.GetVendorByIdAsync(id);
        }

        public async Task<IEnumerable<Vendor>> GetAllVendorsAsync()
        {
            return await _repository.GetVendorsAsync();
        }
    }
}
