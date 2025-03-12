namespace Application.Model.User;

public class LoginUserModel
{
    public string Email { get; set; }

    public string Password { get; set; }
}

public class LoginResponseModel
{
    public string Email { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public Guid Id { get; set; }
}

