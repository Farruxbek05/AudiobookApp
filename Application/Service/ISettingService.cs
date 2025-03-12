using Application.Model;
using Application.Model.Setting;

namespace Application.Service;

public interface ISettingService
{
    Task<ApiResult<SettingCMResponse>> CreateSettingAsync(SettingCM model);
    Task<ApiResult<SettingRM>> GetByIdSettingAsync(Guid id);
    Task<ApiResult<IEnumerable<SettingRM>>> GetAllSettingsAsync();
    Task<ApiResult<SettingUMResponse>> UpdateSettingAsync(SettingUM model);
    Task<ApiResult<bool>> DeleteSettingAsync(Guid id);
}

