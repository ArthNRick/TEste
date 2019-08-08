using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LastName");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.HasMany(p => p.Details).WithOne();

        }
    }
}
