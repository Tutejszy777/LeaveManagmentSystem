using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagmentSystem.Data.Configurations
{
    public class AppicationUserConfiguration : IEntityTypeConfiguration<AppicationUser>
    {
        public void Configure(EntityTypeBuilder<AppicationUser> builder)
        {
            var hasher = new PasswordHasher<AppicationUser>();
            builder.HasData(
                new AppicationUser
                {
                    Id = "1020cc48-2bbf-4762-95f6-95da846e04ac",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    EmailConfirmed = true,
                    FirstName = "default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1990, 12, 23)
                }
            );
        }
    }
}
