using Microsoft.AspNetCore.Http;

namespace Application.Model.User;

public class CreateUserModel
{
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string Password { get; set; }
    public IFormFile? ProfilePicture { get; set; }
}

public class CreateUserResponseModel : BaseResponceModel { }
