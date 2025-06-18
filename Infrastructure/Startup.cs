using Finbuckle.MultiTenant;
using Infrastructure.Context;
using Infrastructure.Tenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfraStructureServices(this IServiceCollection services,
        IConfiguration config)
    {
        return services
            .AddDbContext<TenantDbContext>(options => options
                .UseSqlServer(config.GetConnectionString("DefaultConnection")))
            .AddMultiTenant<AbcSchoolTenantInfo>()
            .WithHeaderStrategy(TenancyConstants.TenantIdName)
            .WithClaimStrategy(TenancyConstants.TenantIdName)
            .WithEFCoreStore<TenantDbContext, AbcSchoolTenantInfo>()
            .Services
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));


    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        return app
            .UseMultiTenant();
    }
}