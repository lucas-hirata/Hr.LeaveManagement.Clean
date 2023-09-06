﻿using Hr.LeaveManagement.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hr.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType
            {
                Id = 1,
                Name = "Vacation",
                DefaultDays = 10,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            }
        );

        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
