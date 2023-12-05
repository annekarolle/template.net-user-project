﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreFIAP.Entity;

namespace StoreFIAP.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.Name).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Password).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.IsActived).HasColumnType("BIT").IsRequired();
            builder.Property(u => u.Permitions).HasConversion<int>().IsRequired();


            builder.Property(u => u.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.DesactivedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.UpdatedDate).HasColumnType("DATETIME").IsRequired();

        }
    }
}
