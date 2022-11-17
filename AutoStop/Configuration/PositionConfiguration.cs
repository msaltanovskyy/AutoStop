﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtilerCourseWork.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "Driver",
                NormalizedName = "DRIVER"
            },
            new IdentityRole
            {
                Id = "3",
                Name = "Companion",
                NormalizedName = "COPMANION"
            });
        }
    }
}
