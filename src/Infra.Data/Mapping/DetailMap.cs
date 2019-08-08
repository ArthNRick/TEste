using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TR.Infra.Data.Mapping
{
    public class DetailMap : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {

            builder.ToTable("Details");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId).IsRequired();

            builder.Property(c => c.Type).IsRequired();

            builder.Property(c => c.Value).IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(b => b.Details)
                .HasForeignKey(p => p.UserId);


        }


    }
}
