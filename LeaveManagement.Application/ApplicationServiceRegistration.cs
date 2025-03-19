using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}