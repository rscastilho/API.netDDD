using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(n => n.Name).IsRequired().HasMaxLength(60);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);

        }
    }
}