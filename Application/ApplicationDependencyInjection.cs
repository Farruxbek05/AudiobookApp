using Application.Common.Email;
using Application.Helpers.GenerateJwt;
using Application.Helpers.PasswordHashers;
using Application.MappingProfiles;
using Application.Service;
using Application.Service.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        services.RegisterCashing();

        services.Configure<JwtOption>(configuration.GetSection("JwtSettings"));
        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBookmarkService, BookmarkService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<ISubscriptionService, SubscriptionService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();



    }
    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }


    private static void RegisterCashing(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}

