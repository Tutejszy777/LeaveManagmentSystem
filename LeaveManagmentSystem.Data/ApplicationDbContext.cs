using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeaveManagmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // SEEDING MOVED TO DATA.CONFIGURATIONS
            {
                //builder.Entity<IdentityRole>().HasData(
                //    new IdentityRole
                //    {
                //        Id = "fd0fe901-72d4-4063-ac2c-88b12855c8a3",
                //        Name = "Employee",
                //        NormalizedName = "EMPLOYEE"
                //    },
                //    new IdentityRole
                //    {
                //        Id = "3df47690-0eb7-44bb-b6f8-2a107522f0b3",
                //        Name = "Supervisor",
                //        NormalizedName = "SUPERVISOR"
                //    },
                //    new IdentityRole
                //    {
                //        Id = "27c631a7-9a60-4c21-adb4-7f0ce88396d7",
                //        Name = "Administrator",
                //        NormalizedName = "ADMINISTRATOR"
                //    });

                //var hasher = new PasswordHasher<AppicationUser>();
                //builder.Entity<AppicationUser>().HasData(
                //    new AppicationUser
                //    {
                //        Id = "1020cc48-2bbf-4762-95f6-95da846e04ac",
                //        Email = "admin@localhost.com",
                //        NormalizedEmail = "ADMIN@LOCALHOST.COM",
                //        UserName = "admin@localhost.com",
                //        NormalizedUserName = "ADMIN@LOCALHOST.COM",
                //        PasswordHash = hasher.HashPassword(null, "Admin@123"),
                //        EmailConfirmed = true,
                //        FirstName = "default",
                //        LastName = "Admin",
                //        DateOfBirth = new DateOnly(1990, 12, 23)
                //    }
                //);

                //builder.Entity<IdentityUserRole<string>>().HasData(
                //    new IdentityUserRole<string>
                //    {
                //        RoleId = "27c631a7-9a60-4c21-adb4-7f0ce88396d7",
                //        UserId = "1020cc48-2bbf-4762-95f6-95da846e04ac"
                //    }
                //);
            }

            // INSTEAD OF THOSE LINE THEl Upper buider used
            //builder.ApplyConfiguration(new LeaveRequestStatusConfiguration());   
            //builder.ApplyConfiguration(new IdentityRoleConfiguration());
            //builder.ApplyConfiguration(new AppicationUserConfiguration());
            //builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<Period> Periods { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

    }
}
