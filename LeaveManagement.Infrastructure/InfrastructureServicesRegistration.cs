using LeaveManagement.Application.Contracts.Email;
using LeaveManagement.Application.Contracts.Logging;
using LeaveManagement.Application.Models;
using LeaveManagenemt.Infrastructure.EmailService;
using LeaveManagenemt.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagenemt.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigurationInfrastructureService(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
      return services;  
    }
}