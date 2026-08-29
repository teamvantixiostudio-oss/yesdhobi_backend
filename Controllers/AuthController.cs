using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDhobi.Api.Models.DTOs;
using YesDhobi.Api.Services;

namespace YesDhobi.Api.Controllers
{
    [ApiController]
    [Route("api/auth/vendor")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Step 1 — Request OTP for a registered vendor mobile number.
        /// POST /api/auth/vendor/send-otp
        /// </summary>
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] VendorSendOtpRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var exists = await _authService.SendOtpAsync(request.MobileNumber);

                if (!exists)
                    return NotFound(new
                    {
                        success = false,
                        message = "No vendor account found with this mobile number. Please complete registration first."
                    });

                return Ok(new
                {
                    success = true,
                    message = $"OTP has been sent to +91-{request.MobileNumber}."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to process OTP request.", details = ex.Message });
            }
        }

        /// <summary>
        /// Step 2 — Verify OTP and receive JWT token on success.
        /// POST /api/auth/vendor/verify-otp
        /// </summary>
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VendorVerifyOtpRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.VerifyOtpAndLoginAsync(request.MobileNumber, request.Otp);

                if (result == null)
                    return Unauthorized(new
                    {
                        success = false,
                        message = "Invalid OTP or mobile number. Please try again."
                    });

                return Ok(new
                {
                    success = true,
                    message = "Login successful.",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Login failed due to a server error.", details = ex.Message });
            }
        }
    }
}
