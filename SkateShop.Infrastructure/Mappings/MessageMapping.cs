using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkateShop.Domain.Entities;

namespace SkateShop.Infrastructure.Mappings
{
    internal sealed class MessageMapping : Mapping<MessageBar>
    {
        public override void Configure(EntityTypeBuilder<MessageBar> builder)
        {
            builder.ToTable("message_bar");

            builder.Property(m => m.Message)
               .HasColumnName("message")
               .IsRequired();

            base.Configure(builder);
        }
    }
}
