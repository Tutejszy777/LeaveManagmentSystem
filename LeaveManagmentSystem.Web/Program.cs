using LeaveManagementSystem.Application;
using LeaveManagementSystem.Application.Services.EmailDIR;
using LeaveManagementSystem.Application.Services.LeaveAllocationsDir;
using LeaveManagementSystem.Application.Services.LeaveRequestDIR;
using LeaveManagementSystem.Application.Services.LeaveTypesDIR;
using LeaveManagementSystem.Application.Services.PeriodDIR;
using LeaveManagementSystem.Application.Services.Users;
using LeaveManagementSystem.Common.Static;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());          changed to:
ApplicationServicesRegistration.AddApplicationServices(builder.Services);

//builder.Services.AddScoped<ILeaveTypeServices, LeaveTypeServices>();
//builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
//builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
//builder.Services.AddScoped<IPeriodService, PeriodService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddTransient<IEmailSender, EmailSender>();           moved to : ApplicationSerivcesRegistration class

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminSupervisorOnly", policy =>
    {
        policy.RequireRole(Roles.Administrator, Roles.Supervisor);
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDefaultIdentity<AppicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
