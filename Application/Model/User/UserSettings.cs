namespace Application.Model.User;

public class UserSettings
{
    public int OtpExpirationTimeInSeconds { get; set; } = 300;
    public int OtpResendTimeInSeconds { get; set; } = 60;
    public int RefreshTokenExpirationDays { get; set; }
}

