using Application.Model;
using Application.Model.User;
using Application.Service;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    public UsersController(
        IUserService userService, IEmailService emailService)
    {
        this._userService = userService;
        this._emailService = emailService;
    }

    [HttpPost("registration")]
    public async Task<ActionResult<CreateUserResponseModel>> PostUserAsync(
        CreateUserModel userForCreationDto)
    {
        var createdUser = await this._userService
            .SignUpAsync(userForCreationDto);

        return Created("", createdUser);
    }

    [HttpPost("login")]
    public async Task<ApiResult<LoginResponseModel>> LoginAsync(LoginUserModel loginModel)
    {
        var result = await _userService.LoginAsync(loginModel);

        return result;
    }

    [HttpPost("ValidateAndRefreshToken")]
    public async Task<IActionResult> ValidateAndRefreshToken(Guid id, string refreshToken)
    {
        return Ok(await _userService.ValidateAndRefreshToken(id, refreshToken));
    }

    [HttpPost("SendOtpCode")]
    public async Task<ApiResult<bool>> SendOtpCode(Guid userId)
    {
        var result = await _userService.SendOtpCode(userId);

        return result;
    }

    [HttpPost("ResendOtpCode")]
    public async Task<ApiResult<bool>> ResendOtpCode(Guid userId)
    {
        var result = await _userService.ResendOtpCode(userId);

        return result;
    }

    [HttpPost("VerifyOtpAsync")]
    public async Task<ApiResult<bool>> VerifyOtpAsync(string otpCode, Guid userId)
    {
        var result = await _userService.VerifyOtpAsync(otpCode, userId);

        return result;
    }

    [HttpPost("SendEmail")]
    public async Task<IActionResult> SendEmail(string email, string otp)
    {
        return Ok(await _emailService.SendEmailAsync(email, otp));
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken(Guid id, string refreshToken)
    {
        return Ok(await _userService.ValidateAndRefreshToken(id, refreshToken));
    }
    [HttpGet("GetUserProfile")]
    public async Task<ApiResult<ProfileDTO>> GetUserProfileAsync(Guid userid)
    {
        var result = await _userService.GetUserProfileAsync(userid);
        return result;
    }
}

