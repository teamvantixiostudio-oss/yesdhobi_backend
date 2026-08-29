using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YesDhobi.Api.Data;
using YesDhobi.Api.Models.DTOs;

namespace YesDhobi.Api.Services
{
    public interface IAuthService
    {
        Task<bool> SendOtpAsync(string mobileNumber);
        Task<VendorLoginResponseDto> VerifyOtpAndLoginAsync(string mobileNumber, string otp);
    }

    public class AuthService : IAuthService
    {
        private readonly YesDhobiDbContext _context;
        private readonly IConfiguration _config;

        // Hardcoded OTP for development/testing purposes
        private const string DEV_OTP = "1234";

        public AuthService(YesDhobiDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        /// <summary>
        /// Simulates sending an OTP to the vendor's mobile number.
        /// Returns false if no vendor is registered with that number.
        /// </summary>
        public async Task<bool> SendOtpAsync(string mobileNumber)
        {
            // Lookup vendor by mobile number in personal details
            var exists = await _context.VendorPersonalDetails
                .AnyAsync(v => v.MobileNumber == mobileNumber);

            // In production: trigger SMS gateway here.
            // For now, we just confirm the number exists.
            return exists;
        }

        /// <summary>
        /// Verifies OTP (hardcoded as 1234 for dev) and returns a JWT + vendor profile on success.
        /// </summary>
        public async Task<VendorLoginResponseDto> VerifyOtpAndLoginAsync(string mobileNumber, string otp)
        {
            // Step 1: Validate OTP (hardcoded for development)
            if (otp != DEV_OTP)
                return null;

            // Step 2: Find vendor by mobile number
            var personalDetail = await _context.VendorPersonalDetails
                .Include(p => p.Vendor)
                    .ThenInclude(v => v.BusinessDetail)
                .Include(p => p.Vendor)
                    .ThenInclude(v => v.Location)
                .FirstOrDefaultAsync(p => p.MobileNumber == mobileNumber);

            if (personalDetail == null)
                return null;

            var vendor = personalDetail.Vendor;

            // Step 3: Build JWT token
            var expiresAt = DateTime.UtcNow.AddHours(
                _config.GetValue<int>("Jwt:ExpiresInHours", 24));

            var token = GenerateJwtToken(vendor.Id, mobileNumber, vendor.Status, expiresAt);

            // Step 4: Build and return login response
            return new VendorLoginResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt,
                Vendor = new VendorAuthProfileDto
                {
                    Id = vendor.Id,
                    RegistrationId = vendor.RegistrationId,
                    Status = vendor.Status,
                    FullName = personalDetail.FullName,
                    MobileNumber = personalDetail.MobileNumber,
                    EmailAddress = personalDetail.EmailAddress,
                    ProfilePhotoUrl = personalDetail.ProfilePhotoUrl,
                    ShopName = vendor.BusinessDetail?.ShopName,
                    City = vendor.Location?.City,
                    State = vendor.Location?.State
                }
            };
        }

        private string GenerateJwtToken(Guid vendorId, string mobileNumber, string status, DateTime expiresAt)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, vendorId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("mobile", mobileNumber),
                new Claim("status", status ?? "PENDING"),
                new Claim("role", "Vendor")
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
