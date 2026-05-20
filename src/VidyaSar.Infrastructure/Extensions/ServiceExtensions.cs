using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VidyaSar.Application.Interfaces;
using VidyaSar.Application.Services;
using VidyaSar.Infrastructure.Data;
using VidyaSar.Infrastructure.Repositories;
using VidyaSar.Infrastructure.Security;

namespace VidyaSar.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        // Database
        // ✅ With this - auto retries on transient failures
        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection"), npgsqlOpt =>
            {
                npgsqlOpt.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorCodesToAdd: null
                );
                npgsqlOpt.CommandTimeout(60);
            }));

        // Repositories
        services.AddScoped<IUserRepository,          UserRepository>();
        services.AddScoped<IUniversityRepository,    UniversityRepository>();
        services.AddScoped<ICollegeRepository,       CollegeRepository>();
        services.AddScoped<IEducationGroupRepository, EducationGroupRepository>();
        services.AddScoped<ISessionRepository,       SessionRepository>();
        services.AddScoped<IConfigurationRepository, ConfigurationRepository>();

        // Services
        services.AddScoped<IJwtService,             JwtService>();
        services.AddScoped<IAuthService,            AuthService>();
        services.AddScoped<ICommonService,          CommonService>();
        services.AddScoped<IUniversityService,      UniversityService>();
        services.AddScoped<IInstituteService,       InstituteService>();
        services.AddScoped<IEducationGroupService,  EducationGroupService>();
        services.AddScoped<ISessionService,         SessionService>();

        return services;
    }
}
