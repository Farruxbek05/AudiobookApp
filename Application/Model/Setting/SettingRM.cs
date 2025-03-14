namespace Application.Model.Setting;

public class SettingRM : BaseResponceModel
{
    public Guid UserId { get; set; }
    public bool NotificationsEnabled { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
}
