using SkateShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SkateShop.Infrastructure.Mappings
{
    internal sealed class UserMapping : Mapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(u => u.Name)
               .HasColumnName("name")
               .IsRequired();

            builder.Property(u => u.Email)
               .HasColumnName("email")
               .IsRequired();

            builder.Property(u => u.Password)
               .HasColumnName("password")
               .IsRequired();

            builder.Property(u => u.IsAdmin)
               .HasColumnName("is_admin")
               .IsRequired();

            builder.HasMany(u => u.Permissions)
                .WithOne(p => p.User);

            base.Configure(builder);
        }
    }
}
