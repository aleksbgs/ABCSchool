using Domain.Entities;
using Finbuckle.MultiTenant.Abstractions;
using Infrastructure.Tenancy;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(IMultiTenantContextAccessor<AbcSchoolTenantInfo> tenantInfoContextAccessor,
        DbContextOptions<ApplicationDbContext> options) : base(tenantInfoContextAccessor, options)
    {

    }

    public DbSet<School> Schools => Set<School>();
    
}