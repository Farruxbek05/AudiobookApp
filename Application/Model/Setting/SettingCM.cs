namespace Application.Model.Setting;

public class SettingCM
{
    public Guid UserId { get; set; }
    public bool NotificationsEnabled { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
}

public class SettingCMResponse : BaseResponceModel { }
