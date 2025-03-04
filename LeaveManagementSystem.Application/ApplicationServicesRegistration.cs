using LeaveManagementSystem.Application.Services.EmailDIR;
using LeaveManagementSystem.Application.Services.LeaveAllocationsDir;
using LeaveManagementSystem.Application.Services.LeaveRequestDIR;
using LeaveManagementSystem.Application.Services.LeaveTypesDIR;
using LeaveManagementSystem.Application.Services.PeriodDIR;
using LeaveManagementSystem.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ILeaveTypeServices, LeaveTypeServices>();
        services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
        services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        services.AddScoped<IPeriodService, PeriodService>();
        services.AddScoped<IUserService, UserService>();
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
