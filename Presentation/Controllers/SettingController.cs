using Application.Model.Setting;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingController : ControllerBase
{
    private readonly ISettingService _settingService;
    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    [HttpGet("GetAllSettings")]
    public async Task<IActionResult> GetAllSettings()
    {
        var res = await _settingService.GetAllSettingsAsync();
        return Ok(res);
    }

    [HttpGet("GetSetting/{id}")]
    public async Task<IActionResult> GetSetting(Guid id)
    {
        var res = await _settingService.GetByIdSettingAsync(id);
        return Ok(res);
    }

    [HttpPost("CreateSetting")]
    public async Task<IActionResult> CreateSetting(SettingCM settingCM)
    {
        var res = await _settingService.CreateSettingAsync(settingCM);
        return Ok(res);
    }

    [HttpPut("UpdateSetting")]
    public async Task<IActionResult> UpdateSetting(SettingUM settingUM)
    {
        var res = await _settingService.UpdateSettingAsync(settingUM);
        return Ok(res);
    }

    [HttpDelete("DeleteSetting")]
    public async Task<IActionResult> DeleteSetting(Guid id)
    {
        var res = await _settingService.DeleteSettingAsync(id);
        return Ok(res);
    }
}
