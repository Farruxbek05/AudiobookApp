using Application.Model;
using Application.Model.Setting;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Service.Impl;

public class SettingService : ISettingService
{
    private readonly IMapper _mapper;
    private readonly AudiobookDbContext _dbContext;

    public SettingService(IMapper mapper, AudiobookDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }

    public async Task<ApiResult<SettingCMResponse>> CreateSettingAsync(SettingCM model)
    {
        var setting = _mapper.Map<Setting>(model);
        setting.CreatedOn = DateTime.UtcNow;
        _dbContext.Settings.Add(setting);
        await _dbContext.SaveChangesAsync();

        return ApiResult<SettingCMResponse>.Success(new SettingCMResponse { Id = setting.Id });
    }

    public async Task<ApiResult<bool>> DeleteSettingAsync(Guid id)
    {
        var setting = _dbContext.Settings.FirstOrDefault(t => t.Id == id);
        if (setting == null)
        {
            return ApiResult<bool>.Failure(new List<string> { "Setting not found" });
        }

        _dbContext.Settings.Remove(setting);
        await _dbContext.SaveChangesAsync();

        return ApiResult<bool>.Success(true);
    }

    public async Task<ApiResult<IEnumerable<SettingRM>>> GetAllSettingsAsync()
    {
        var settings = await _dbContext.Settings
                                       .AsNoTracking()
                                       .ProjectTo<SettingRM>(_mapper.ConfigurationProvider)
                                       .ToListAsync();
        return ApiResult<IEnumerable<SettingRM>>.Success(settings);
    }

    public async Task<ApiResult<SettingRM>> GetByIdSettingAsync(Guid id)
    {
        var setting = await _dbContext.Settings
                                       .AsNoTracking()
                                       .ProjectTo<SettingRM>(_mapper.ConfigurationProvider)
                                       .FirstOrDefaultAsync(c => c.Id == id);

        if (setting == null)
        {
            return ApiResult<SettingRM>.Failure(new List<string> { "Setting not found" });
        }

        return ApiResult<SettingRM>.Success(setting);
    }

    public async Task<ApiResult<SettingUMResponse>> UpdateSettingAsync(SettingUM model)
    {
        var setting = await _dbContext.Settings.FirstOrDefaultAsync(s => s.Id == model.Id);

        if (setting == null)
        {
            return ApiResult<SettingUMResponse>.Failure(new List<string> { "Setting not found" });
        }

        _mapper.Map(model, setting);
        setting.UpdatedOn = DateTime.UtcNow;
        _dbContext.Settings.Update(setting);
        await _dbContext.SaveChangesAsync();

        return ApiResult<SettingUMResponse>.Success(new SettingUMResponse { Id = setting.Id });
    }
}

