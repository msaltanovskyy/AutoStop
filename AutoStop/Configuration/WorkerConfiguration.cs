using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtilerCourseWork.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<IdentityUser>
    {

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var account1 = new IdentityUser
            {
                Id = "1",
                UserName = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var account2 = new IdentityUser
            {
                Id = "2",
                UserName = "driver@gmail.com",
                NormalizedEmail = "DRIVER@GMAIL.COM",
                Email = "driver@gmail.com",
                NormalizedUserName = "DRIVER@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var account3 = new IdentityUser
            {
                Id = "3",
                UserName = "companion@gmail.com",
                NormalizedEmail = "companion@GMAIL.COM",
                Email = "companion@gmail.com",
                NormalizedUserName = "COMPANION@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            var hasher = new PasswordHasher<IdentityUser>();
            account1.PasswordHash = hasher.HashPassword(account1, "Admin1@");
            account2.PasswordHash = hasher.HashPassword(account2, "Driver1@");
            account3.PasswordHash = hasher.HashPassword(account3, "Companion1@");
            builder.HasData(account1, account2, account3);

            
        }
    }
}
