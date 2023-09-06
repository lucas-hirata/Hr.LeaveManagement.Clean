using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Persistence.DatabaseContext;
using Hr.LeaveManagement.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.LeaveManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

        return services;
    }
}